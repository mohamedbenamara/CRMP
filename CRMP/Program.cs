using CRMP  .Data;
using CRMP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMP
{
    class Program
    {
        static void Main(string[] args)
        {
            CRMContext crm = new CRMContext();
            Product p = new Product()
            {

                prodName = "Please"

            };
            crm.Products.Add(p);
            crm.SaveChanges();
        }
    }
}
