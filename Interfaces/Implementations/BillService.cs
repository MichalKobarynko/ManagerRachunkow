using AutoMapper;
using ManagerRachunkow.Extensions;
using ManagerRachunkow.Models;
using ManagerRachunkow.ModelsDTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerRachunkow.Interfaces.Implementations
{
    public class BillService : IBillService
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        public BillService(
            ApplicationDbContext context,
            ILogger logger,
            IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
        }

        public ResponseDTO AddBill(BillDTO billDTO)
        {
            logger.LogInformation($"{Strings.WykonanieMetody} AddBill");

            try
            {
                var bill = mapper.Map<Bill>(billDTO);
                context.Bill.Add(bill);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                return new ResponseDTO()
                {
                    Code = 400,
                    Message = ex.Message,
                    Status = $"{Strings.BladPodczasWykonywaniaMetody} AddBill"
                };
            }

            return new ResponseDTO()
            {
                Code = 200,
                Message = $"{Strings.DodanoDoBazyDanych} nowy rachunek",
                Status = Strings.Status.Success
            };
        }

        public ResponseDTO DeleteBill(string mail)
        {
            logger.LogInformation($"{Strings.WykonanieMetody} DeleteBill");

            var billToRemove = context.Bill.Where(b => b.User.Email == mail).SingleOrDefault();

            if(billToRemove == null)
            {
                return new ResponseDTO
                {
                    Code = 400,
                    Message = Strings.ElementnieIstniejeWBazieDanych,
                    Status = Strings.Status.Error
                };
            }

            try
            {
                context.Bill.Remove(billToRemove);
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
                Message = $"{Strings.UsunietoZBazyDanych} rachunek",
                Status = Strings.Status.Error
            };

        }

        public ResponseDTO EditBill(BillDTO billDTO)
        {
            logger.LogInformation($"{Strings.WykonanieMetody} EditBill");

            if(context.Bill.Where(b => b.Name == billDTO.Name).Count() == 0)
            {
                return new ResponseDTO
                {
                    Code = 400,
                    Message = Strings.ElementnieIstniejeWBazieDanych,
                    Status = Strings.Status.Error
                };
            }

            try
            {
                context.Bill.Update(mapper.Map<Bill>(billDTO));
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
                Message = $"{Strings.EdytowanoWBazieDanych} rachunek",
                Status = Strings.Status.Error
            };
        }

        public BillsDTO GetAllBillByUser(string mail)
        {
            var result = context.Bill.Where(b => b.User.Email == mail).ToList();

            BillsDTO billsDTO = new BillsDTO();

            foreach(Bill bill in result)
            {
                billsDTO.billList.Add(mapper.Map<BillDTO>(bill));
            }

            billsDTO.billList = billsDTO.billList
                .OrderBy(o => o.Year)
                .Reverse()
                .ToList();

            return billsDTO;
        }
    }
}
