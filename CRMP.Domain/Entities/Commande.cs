using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMP.Domain.Entities
{
    public class Commande
    {
        public int CommandeId { get; set; }
        public int cmdNum { get; set; }
        public DateTime cmdDate { get; set; }
        public float cmdMontant { get; set; }


        public int? userId { get; set; }
        [ForeignKey("userId")]
        public virtual User user { get; set; }

        public int? productId { get; set; }
        [ForeignKey("productId")]
        public virtual Product product { get; set; }
        public Commande()
        {

        }
    }
}
