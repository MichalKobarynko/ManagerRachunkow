using ManagerRachunkow.Extensions;
using ManagerRachunkow.Interfaces;
using ManagerRachunkow.ModelsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerRachunkow.Controllers
{
    public class InformationController : Controller
    {
        private readonly IInformationsService informationService;
        private readonly ILogger<InformationController> logger;

        public InformationController(IInformationsService informationService, ILogger<InformationController> logger)
        {
            this.informationService = informationService;
            this.logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("/api/information/add")]
        public IActionResult AddInformation([FromBody] InformationDTO informationDTO)
        {
            logger.LogInformation($"{Strings.WykonanieMetodyKontrolera} {nameof(InformationController)}");

            return Ok(informationService.AddInformation(informationDTO)); ;
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("/api/information/edit")]
        public IActionResult EditInformation([FromBody] InformationDTO informationDTO)
        {
            logger.LogInformation($"{Strings.WykonanieMetodyKontrolera} {nameof(InformationController): EditInformation}");

            return Ok(informationService.EditInformation(informationDTO));
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("/api/information/delete/{informationId}")]
        public IActionResult DeleteInformation(string informationId)
        {
            logger.LogInformation($"{Strings.WykonanieMetodyKontrolera} {nameof(InformationController)}: DeleteInformation");

            return Ok(informationService.DeleteInformation(informationId));
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("/api/information.getAll/{userId}")]
        public IActionResult GetAllByUser(string userId)
        {
            logger.LogInformation($"{Strings.WykonanieMetodyKontrolera} {nameof(InformationController)}: GetAll");

            return Ok(informationService.GetAllByUser(userId));
        }
    }
}
