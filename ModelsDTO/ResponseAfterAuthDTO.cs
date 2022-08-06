using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerRachunkow.ModelsDTO
{
    public class ResponseAfterAuthDTO : ResponseDTO
    {
        public bool IsAdmin { get; set; }
        public string IdUser { get; set; }
        public string Mail { get; set; }
    }
}
