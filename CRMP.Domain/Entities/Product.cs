using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMP.Domain.Entities
{public enum category { Téléphones, Cartes, Puces, Accessoires, Equipements, Fibres, ADSL }
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "Catégorie")]
        public category categorie { get; set; }

        [Required(ErrorMessage = "Le champ nom est obligatoire")]
        [MaxLength(25, ErrorMessage = "Longueur maximale est 25 caractères")]
        [Display(Name = "Nom")]
        public string prodName { get; set; }

        [Display(Name = "Etat")]
        public string prodState { get; set; } = "Disponible";

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Le champ description est obligatoire")]
        [MaxLength(500, ErrorMessage = "Longueur maximale est 500 caractères")]
        [Display(Name = "Description")]
        public string prodDesc { get; set; }

        [Required(ErrorMessage = "Le champ prix est obligatoire")]
        [DataType(DataType.Currency)]
        [Display(Name = "Prix")]
        public double prodPrice { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Quantité")]
        public int prodQuantity { get; set; }

        [DataType(DataType.ImageUrl)] // type du champs: image url
        [Display(Name = "Image")] // affiche dans la vue "Image"
        public string prodImage { get; set; }

        //foreign Key properties
        [Display(Name = "Boutique")]
        public int? StoreId { get; set; }
        //navigation properties

        [ForeignKey("StoreId")]
        public virtual Store store { get; set; }

        //public string prodCat { get; set; }
        //public ICollection<Store> Stores { get; set; }

        public Product()
        {

        }
    }
}

