using Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo_resteau
{
    public class Commande
    {
        public int Id { get; set; }
        public string Numero { get; set; }


        public List<Menu> Menus { get; set; } = new List<Menu>();
        public List<Article> Articles { get; set; } = new List<Article>();

        public int UtilisateurId { get; set; }

        public Utilisateur Utilisateur { get; set; }

        public int TableId { get; set; }
        public Table Table { get; set; }
    }
}