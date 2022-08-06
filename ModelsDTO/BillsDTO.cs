using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerRachunkow.ModelsDTO
{
    public class BillsDTO
    {
        public List<BillDTO> billList { get; set; }
        public BillsDTO()
        {
            billList = new List<BillDTO>();
        }
    }
}
