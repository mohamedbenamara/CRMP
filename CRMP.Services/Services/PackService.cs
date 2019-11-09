using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRMP.Domain.Entities;
using CRMP.Data.Infrastructure;
using Service.Pattern;
using CRMP.Services.IServices;


namespace CRMP.Services.Services
{
   public class PackService : Service<Pack>, IPackService
    {

        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(Factory);
        public PackService() : base(UTK)
        {

        }

    }
}
