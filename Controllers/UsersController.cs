using ManagerRachunkow.Extensions;
using ManagerRachunkow.Interfaces;
using ManagerRachunkow.ModelsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerRachunkow.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly ILogger<UsersController> logger;

        public UsersController(IUsersService usersService, ILogger<UsersController> logger)
        {
            this.usersService = usersService;
            this.logger = logger;
        }

        [HttpGet]
        [Route("/api/users/getAll")]
        public IActionResult GetAllUsers()
        {
            logger.LogInformation($"{Strings.WykonanieMetodyKontrolera} {nameof(UsersController): GetAllUsers}");

            return Ok(usersService.GetAllUsers());
        }

        [HttpPut]
        [Route("/api/users/edit/")]
        public ActionResult EditUser([FromBody]UserDTO userDTO)
        {
            logger.LogInformation($"{Strings.WykonanieMetodyKontrolera} {nameof(UsersController)}: EditUser");

            return Ok(usersService.EditUser(userDTO));
        }
    }
}
