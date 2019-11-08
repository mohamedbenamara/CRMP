using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMP.Domain.Entities
{
    public class Store
    {
        public int StoreId { get; set; }
        public string storeName { get; set; }
        public string storeaddress { get; set; }
        public string storeNum { get; set; }
        public string storeDesc { get; set; }

        public Store()
        {

        }
    }
}
