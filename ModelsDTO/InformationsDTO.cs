using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerRachunkow.ModelsDTO
{
    public class InformationsDTO
    {
        public List<InformationDTO> informationList { get; set; }
        public InformationsDTO()
        {
            informationList = new List<InformationDTO>();
        }
    }
}
