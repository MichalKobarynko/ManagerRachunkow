using ManagerRachunkow.Extensions;
using ManagerRachunkow.Interfaces;
using ManagerRachunkow.ModelsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerRachunkow.Controllers
{
    public class BillController : Controller
    {
        private readonly IBillsService billService;
        private readonly ILogger<BillController> logger;

        public BillController(
            IBillsService billService,
            ILogger<BillController> logger
            )
        {
            this.billService = billService;
            this.logger = logger;
        }

        [HttpPost]
        [Route("/api/bill/add")]
        public IActionResult AddBill([FromBody]BillDTO billDTO)
        {
            logger.LogInformation($"{Strings.WykonanieMetodyKontrolera} {nameof(BillController)}: AddBill");
            return Ok(billService.AddBill(billDTO));
        }

        [HttpPut]
        [Route("/api/bill/edit")]
        public IActionResult EditBill([FromBody]BillDTO billDTO)
        {
            logger.LogInformation($"{Strings.WykonanieMetodyKontrolera} {nameof(BillController)}: EditBill");
            return Ok(billService.EditBill(billDTO));
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("/api/bill/delete/{mail}")]
        public IActionResult DeleteBill(string mail)
        {
            logger.LogInformation($"{Strings.WykonanieMetodyKontrolera} {nameof(BillController): DeleteBill}");
            return Ok(billService.DeleteBill(mail));
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("/api/bill.getAll/{mail}")]
        public IActionResult GetBillByUser(string email)
        {
            logger.LogInformation($"{Strings.WykonanieMetodyKontrolera} {nameof(BillController)}: GetAll");
            return Ok(billService.GetAllBillByUser(email));
        }
    }
}
