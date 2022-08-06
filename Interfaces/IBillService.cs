using ManagerRachunkow.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerRachunkow.Interfaces
{
    public interface IBillService
    {
        ResponseDTO AddBill(BillDTO billDTO);
        ResponseDTO EditBill(BillDTO billDTO);
        ResponseDTO DeleteBill(string mail);
        BillsDTO GetAllBillByUser(string mail);
    }
}
