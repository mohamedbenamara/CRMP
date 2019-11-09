using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMP.Domain.Entities
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }

        [Display(Name = "Image")]
        public string storeImage { get; set; }

        [Required(ErrorMessage = "Le champ nom est obligatoire")]
        [MaxLength(25, ErrorMessage = "Longueur maximale est 25 caractères")]
        [Display(Name = "Nom")]
        public string storeName { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Le champ addresse est obligatoire")]
        [MaxLength(500, ErrorMessage = "Longueur maximale est 500 caractères")]
        [Display(Name = "Addresse")]
        public string storeaddress { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Heure d'ouverture")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime Heure_ouverture { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Heure de fermeture")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime Heure_fermeture { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Téléphone")]
        public string storeNum { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Le champ description est obligatoire")]
        [MaxLength(500, ErrorMessage = "Longueur maximale est 500 caractères")]
        [Display(Name = "Description")]
        public string storeDesc { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        //public virtual ICollection<Product> Products { get; set; }
        public Store()
        {

        }
    }
}
