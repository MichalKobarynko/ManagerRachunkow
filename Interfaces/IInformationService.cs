using ManagerRachunkow.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerRachunkow.Interfaces
{
    public interface IInformationService
    {
        ResponseDTO AddInformation(InformationDTO infoDTO);
        ResponseDTO EditInformation(InformationDTO infoDTO);
        ResponseDTO DeleteInformation(string mail);
        InformationsDTO GetAllByUser(string userId);
    }
}
