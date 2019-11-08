using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace CRMP.Domain.Entities
{
    public class Devis
    {
        public int DevisId { get; set; }
        public string devisEtat { get; set; }
        public DateTime devisDate { get; set; }
        public int? CommandeId { get; set; }
        [ForeignKey("CommandeId")]
        public virtual Commande commande { get; set; }

        public int? userId { get; set; }
        [ForeignKey("userId")]
        public virtual User user { get; set; }
        public Devis()
        {

        }
    }
}
