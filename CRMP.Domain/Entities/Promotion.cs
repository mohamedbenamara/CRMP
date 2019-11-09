using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRMP.Domain.Entities
{
    public class Promotion
    {

        public int PromotionId { get; set; }
        [Display(Name = "Name")]
        public string promoDesc { get; set; }
        [Display(Name = "Start Date")]
        public DateTime promoDateD { get; set; }
        [Display(Name = "End Date")]
        public DateTime promoDateF { get; set; }
        [Display(Name = "Pourcentage %")]
        public int promoPrice { get; set; }
        [Display(Name = "Product")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product product { get; set; }

    }
}
