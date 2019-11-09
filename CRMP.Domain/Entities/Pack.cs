using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace CRMP.Domain.Entities
{
    public class Pack
    {

        public int PackId { get; set; }
        [Display(Name = "Name")]
        public string packName { get; set; }

        [Display(Name = "Description")]
        public string packDesc { get; set; }

        [Display(Name = "Price DT")]
        public float packPrice { get; set; }

        [Display(Name = "Image")]
        public string packImage { get; set; }

       [Display(Name = "Product")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product product { get; set; }
        [Display(Name = "Offer")]
            
        public Nullable <int> OfferId { get; set; }
        [ForeignKey("OfferId")]
        public virtual Offer offer { get; set; }

    
   


    }
}
