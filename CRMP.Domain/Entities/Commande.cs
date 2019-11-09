using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMP.Domain.Entities
{
    public class Commande
    {

        public int CommandeId { get; set; }
        [Display(Name = "Quantité du produit")]
        public int q { get; set; }
        [Display(Name = "Nom de l'utilisateur")]
        public string UserId { get; set; }
       // [ForeignKey("UserId")]
        public virtual UserProfil User { get; set; }
        [Display(Name = "Nom du produit")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [Display(Name = "Prix Total (DT)")]
        public float total { get; set; }
        //[DefaultValue("non")]
        [Display(Name = "Etat du commande")]
        public string etat { get; set; } = "non confirmé";

    //public virtual ICollection<Product> Products { get; set; }
    public virtual ICollection<UserProfil> Users { get; set; }
        public Commande()
        {

        }
    }
}
