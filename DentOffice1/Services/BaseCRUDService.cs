using AutoMapper;
using DentOffice.WebAPI.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Services
{
    public class BaseCRUDService<T, TSearch, TDatabase, TInsert, TUpdate> : BaseService<T, TSearch, TDatabase>, ICRUDService<T, TSearch, TInsert, TUpdate> where TDatabase :class 
    {
        public BaseCRUDService(eDentOfficeContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public bool Delete(int id)
        {
            var entitiy = _context.Set<TDatabase>().Find(id);
            if (entitiy != null)
            {
                _context.Set<TDatabase>().Remove(entitiy);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
                   
        public virtual T Insert(TInsert request)
        {
            var entity = _mapper.Map<TDatabase>(request);
            _context.Add(entity);

            _context.SaveChanges();

            return _mapper.Map<T>(entity);
        }


        public virtual T Update(int id, TUpdate request)
        {
            var entity = _context.Set<TDatabase>().Find(id);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<T>(entity);
        }

    }
}
