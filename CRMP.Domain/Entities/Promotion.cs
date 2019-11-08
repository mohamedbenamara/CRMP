using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMP.Domain.Entities
{
    public class Promotion
    {

        public int PromotionId { get; set; }
        public string promoDesc { get; set; }

        public DateTime promoDateD { get; set; }
        public DateTime promoDateF { get; set; }
        public float promoPrice { get; set; }
    }
}
