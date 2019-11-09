using CRMP.Domain.Entities;
using CRMP.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRMP.Data.Infrastructure;
using Service.Pattern;

namespace CRMP.Services.Services
{
   public class PromotionService : Service<Promotion>, IPromotionService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(Factory);

        public PromotionService():base(UTK)
        {
                
        }
     
       
    }
}
