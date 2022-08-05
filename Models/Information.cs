using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerRachunkow.Models
{
    public class Information
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public ApplicationUser User { get; set; }
    }
}
