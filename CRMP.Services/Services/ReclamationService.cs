using CRMP.Data.Infrastructure;
using CRMP.Domain.Entities;
using CRMP.Services.IServices;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMP.Services.Services
{
    public class ReclamationService : Service<Reclamation>, IReclamationService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(Factory);
        public ReclamationService() : base(UTK)
        {

        }
    }
}
