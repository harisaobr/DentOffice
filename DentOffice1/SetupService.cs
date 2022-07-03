using DentOffice.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI
{
    public class SetupService
    {
        public static void Init(eDentOfficeContext context)
        {
            context.Database.Migrate();
        }
    }
}
