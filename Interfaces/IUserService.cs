using ManagerRachunkow.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerRachunkow.Interfaces
{
    public interface IUserService
    {
        UsersDTO GetAllUsers(); 
        ResponseDTO EditUser(UserDTO userDTO);
        ResponseAfterAuthDTO GetIdAndRoleForUserById(string mail);
    }
}
