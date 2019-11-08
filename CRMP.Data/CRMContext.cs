using CRMP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMP.Data
{
   public class CRMContext: DbContext
    {

        public CRMContext():base("name=MaChaine")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Reclamation> Reclamations { get; set; }

        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Devis> Devis { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Pack> Packs { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ventes> Ventes { get; set; }
        public DbSet<Stand> Stands { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Vehicule> Vehicules { get; set; }
        public DbSet<UserProfil> UserProfil { get; set; }




    }
}
