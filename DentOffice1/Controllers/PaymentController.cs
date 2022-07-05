using DentOffice.Model.Requests;
using DentOffice.WebAPI.Database;
using DentOffice.WebAPI.Services;
using DentOffice.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private static IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public Model.Payment Insert(PaymentInsertRequest termin)
        {
            return _paymentService.Insert(termin);
        }

    }
}
