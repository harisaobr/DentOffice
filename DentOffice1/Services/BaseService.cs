using AutoMapper;
using DentOffice.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Services
{
    public class BaseService<T, TSearch, TDatabase> : IService<T, TSearch> where TDatabase:class
    {
        protected readonly eDentOfficeContext _context;
        protected readonly IMapper _mapper;
        public BaseService(eDentOfficeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       
        public virtual IList<T> GetAll(TSearch search = default)
        {
            var result = _context.Set<TDatabase>().ToList();
            return _mapper.Map<IList<T>>(result);
        }

        public virtual T GetById(int id)
        {
            var entity = _context.Set<TDatabase>().Find(id);

            return _mapper.Map<T>(entity);
        }
    }
}
