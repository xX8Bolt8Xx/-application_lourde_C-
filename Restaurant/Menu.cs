using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo_resteau
{
    public class Menu
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public float Prix { get; set; }

        public List<Article> Articles { get; set; } = new List<Article>();
        public List<Commande> Commandes { get; set; } = new List<Commande>();
    }
}