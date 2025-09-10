using exo_resteau;
using Microsoft.EntityFrameworkCore;
using Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo_resteau
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Table> Tables { get; set; }

        public DbSet<Utilisateur> Utilisateurs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Server=localhost;Database=projet_restaurant;User=root;Password=mysql";
            optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
        }
    }
}