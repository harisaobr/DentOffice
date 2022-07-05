using DentOffice.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Services.Interfaces
{
    public interface IPaymentService
    {
        Model.Payment Insert(PaymentInsertRequest termin);

    }
}
