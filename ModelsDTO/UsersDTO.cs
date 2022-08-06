using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerRachunkow.ModelsDTO
{
    public class UsersDTO
    {
        public IList<UserDTO> userList { get; set; }
        public UsersDTO()
        {
            userList = new List<UserDTO>();
        }
    }
}
