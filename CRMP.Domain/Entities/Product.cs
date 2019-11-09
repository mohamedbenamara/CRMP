using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMP.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        public string prodName { get; set; }
        public string prodDesc { get; set; }
        public float prodPrice { get; set; }
        public int prodQuantity { get; set; }
        public string prodImage { get; set; }
        public string prodCat { get; set; }
        public virtual ICollection<Commande> Commandes { get; set; }
        public Product()
        {

        }
    }
}
