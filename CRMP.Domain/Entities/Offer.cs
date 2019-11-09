using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum Type
{
    Prepayees,
    Postpayees

}
namespace CRMP.Domain.Entities
{

    public enum type { Mobile, Internet};
    public class Offer
    {

       public int OfferId { get; set; }
        [Display(Name="Name")]
        public string offerName { get; set; }
        [Display(Name = "Description")]
        public string offerDesc { get; set; }

      

        [Display(Name = "Price DT")]
        public float offerprice { get; set; }

        [Display(Name = "Type")]
        public type offerType { get; set; }
       
        [Display(Name = "Image")]
        public string ImageOffer { get; set; }
        public virtual ICollection<Pack> Packs{ get; set; }

        public int countAff { get; set; }






    }
}