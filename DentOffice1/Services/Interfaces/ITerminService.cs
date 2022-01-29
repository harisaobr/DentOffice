using DentOffice.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Services.Interfaces
{
    public interface ITerminService
    {
        IList<Model.Termin> GetAll(TerminSearchRequest search = default);
        Model.Termin GetById(int id);
        Model.Termin Insert(TerminInsertRequest termin);
        Model.Termin Update(int id, TerminInsertRequest request);

    }
}
