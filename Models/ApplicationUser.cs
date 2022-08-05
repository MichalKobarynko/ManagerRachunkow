using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerRachunkow.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool isPaid { get; set; }
        public IEnumerable<Bill> Bills { get; set; }
        public IEnumerable<Information> Informations { get; set; }
    }
}
