using ManagerRachunkow.Models;
using ManagerRachunkow.ModelsDTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ManagerRachunkow.Extensions;

namespace ManagerRachunkow.Interfaces.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        public UserService(ApplicationDbContext context, ILogger logger, IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
        }

        public ResponseDTO EditUser(UserDTO userDTO)
        {
            logger.LogInformation($"{Strings.WykonanieMetody} EditUser");

            var user = context.ApplicationUser.Where(u => u.Id == userDTO.Id).SingleOrDefault();

            if(user == null)
            {
                return new ResponseDTO
                {
                    Code = 200,
                    Message = Strings.ElementnieIstniejeWBazieDanych,
                    Status = Strings.Status.Error
                };
            }

            user.IsPaid = userDTO.IsPaid;
            user.Email = userDTO.Mail;
            user.UserName = userDTO.Name;
            user.PasswordHash = userDTO.Password;
            user.PhoneNumber = userDTO.TelNumber;

            try
            {
                context.ApplicationUser.Update(user);
                context.SaveChanges();
            }
            catch(Exception Ex)
            {
                return new ResponseDTO
                {
                    Code = 400,
                    Message = Ex.Message,
                    Status = Strings.Status.Error
                };
            }

            return new ResponseDTO
            {
                Code = 200,
                Message = $"{Strings.EdytowanoWBazieDanych} ApplicationUser",
                Status = Strings.Status.Success
            };
        }

        public UsersDTO GetAllUsers()
        {
            logger.LogInformation($"{Strings.WykonanieMetody} GetAllUsers");

            var result = context.ApplicationUser.ToList();

            UsersDTO usersDTO = new UsersDTO();

            foreach(ApplicationUser user in result)
            {
                usersDTO.userList.Add(mapper.Map<UserDTO>(user));
            }

            return usersDTO;
        }

        public ResponseAfterAuthDTO GetIdAndRoleForUserById(string mail)
        {
            logger.LogInformation($"{Strings.WykonanieMetody} GetIdAndRoleForUserId");

            var user = context.ApplicationUser.Where(u => u.Email == mail).SingleOrDefault();
            var roleId = context.UserRoles.Where(r => r.UserId == user.Id).FirstOrDefault().RoleId;
            var roleName = context.Roles.Where(r => r.Id == roleId).SingleOrDefault().Name;
            var isAdmin = (roleName == "Admin");

            return new ResponseAfterAuthDTO
            {
                Code = 200,
                Message = Strings.UzytkownikZalogowany,
                Status = Strings.Status.Success,
                IdUser = user.Id,
                Mail = mail,
                IsAdmin = isAdmin
            };

        }
    }
}
