using ManagerRachunkow.Models;
using ManagerRachunkow.ModelsDTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ManagerRachunkow.Extensions;

namespace ManagerRachunkow.Interfaces.Implementations
{
    public class InformationsService : IInformationsService
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        public InformationsService(
            ApplicationDbContext context, 
            ILogger<InformationsService> logger, 
            IMapper mapper
            )
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
        }

        public ResponseDTO AddInformation(InformationDTO infoDTO)
        {
            logger.LogInformation($"{Strings.WykonanieMetody} AddInformation");

            try
            {
                context.Information.Add(mapper.Map<Information>(infoDTO));
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
                Message = $"{Strings.DodanoDoBazyDanych} Information",
                Status = Strings.Status.Success
            };
        }

        public ResponseDTO DeleteInformation(string email)
        {
            logger.LogInformation($"{Strings.WykonanieMetody} DeleteInformation");

            var informationToRemove = context.Information.Where(i => i.User.Email == email).SingleOrDefault();

            if(informationToRemove == null)
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
                context.Information.Remove(informationToRemove);
                context.SaveChanges();
            }
            catch(Exception Ex)
            {
                return new ResponseDTO
                {
                    Code = 400,
                    Message = Ex.Message,
                    Status = Strings.Status.Success
                };
            }

            return new ResponseDTO
            {
                Code = 200,
                Message = $"{Strings.UsunietoZBazyDanych} Information",
                Status = Strings.Status.Success
            };
        }

        public ResponseDTO EditInformation(InformationDTO infoDTO)
        {
            logger.LogInformation($"{Strings.WykonanieMetody} EditInformation");

            if(context.Information.Where(i => i.Id == infoDTO.Id).Count() == 0)
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
                context.Information.Update(mapper.Map<Information>(infoDTO));
                context.SaveChanges();
            }
            catch (Exception Ex)
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
                Message = $"{Strings.EdytowanoWBazieDanych} Information",
                Status = Strings.Status.Success
            };
        }

        public InformationsDTO GetAllByUser(string mail)
        {
            var result = context.Information.Where(b => b.User.Email == mail);

            InformationsDTO informationsDTO = new InformationsDTO();

            foreach(Information info in result)
            {
                informationsDTO.informationList.Add(mapper.Map<InformationDTO>(info));
            }

            return informationsDTO;
        }
    }
}
