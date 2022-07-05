using AutoMapper;
using DentOffice.Model.Requests;
using DentOffice.WebAPI.Database;
using DentOffice.WebAPI.Exceptions;
using DentOffice.WebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Services
{

    public class PaymentService : IPaymentService
    {
        private readonly eDentOfficeContext _context;
        private readonly IMapper _mapper;

        public PaymentService(eDentOfficeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

      
        public Model.Payment Insert(PaymentInsertRequest request)
        {
            var entity = _mapper.Map<Database.Payment>(request);

            _context.Add(entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Payment>(entity);
        }
       
    }

}
