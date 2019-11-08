using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMP.Domain.Entities
{
    public class Offer
    {
        public int OfferId { get; set; }
        public string offerName { get; set; }
        public string offerDesc { get; set; }

        public string offerType { get; set; }
        public float offerprice { get; set; }
    }
}
