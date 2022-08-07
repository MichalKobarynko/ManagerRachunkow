using ManagerRachunkow.Extensions;
using ManagerRachunkow.Interfaces;
using ManagerRachunkow.Models;
using ManagerRachunkow.ModelsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace ManagerRachunkow.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class RegisterController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ILogger<RegisterController> logger;
        private readonly IMapper mapper;
        private readonly IUsersService usersService;

        public RegisterController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, 
            RoleManager<IdentityRole> roleManager, 
            ILogger<RegisterController> logger, 
            IMapper mapper,
            IUsersService usersService
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.logger = logger;
            this.mapper = mapper;
            this.usersService = usersService;
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<ResponseAfterAuthDTO> Login([FromBody]UserDTO user)
        {
            var result = await signInManager.PasswordSignInAsync(
                user.Mail,
                user.Password,
                false, 
                lockoutOnFailure: true
                );

            if (result.Succeeded)
            {
                logger.LogInformation($"{Strings.UzytkownikZalogowany}");

                return usersService.GetIdAndRoleForUserById(user.Mail);
            }
            else
            {
                logger.LogInformation(Strings.probaLogowaniaNieudana);

                return new ResponseAfterAuthDTO
                {
                    Code = 400,
                    Message = Strings.probaLogowaniaNieudana,
                    Status = Strings.Status.Failed
                };
            }
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<ResponseAfterAuthDTO> Register([FromBody] UserDTO user)
        {
            var newUser = mapper.Map<ApplicationUser>(user);

            var result = await userManager.CreateAsync(newUser, user.Password);

            if(result.Succeeded)
            {
                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    var role = new IdentityRole("Admin");
                    var res = await roleManager.CreateAsync(role);

                    if (res.Succeeded)
                    {
                        await userManager.AddToRoleAsync(newUser, "Admin");
                    }
                    else
                    {
                        if(!await roleManager.RoleExistsAsync("User"))
                        {
                            var role1 = new IdentityRole("user");
                            var result1 = await roleManager.CreateAsync(role1);
                        }
                        await userManager.AddToRoleAsync(newUser, "User");
                    }

                    logger.LogInformation(Strings.DodanoUzytkownika);
                    await signInManager.SignInAsync(newUser, isPersistent: false);
                    logger.LogInformation(Strings.ZalogowanoUzytkownika);

                    return usersService.GetIdAndRoleForUserById(user.Mail);
                }
            }

            logger.LogInformation(Strings.probaLogowaniaNieudana);
            return new ResponseAfterAuthDTO
            {
                Code = 400,
                Message = Strings.probaLogowaniaNieudana,
                Status = Strings.Status.Failed
            };
        }
    }
}
