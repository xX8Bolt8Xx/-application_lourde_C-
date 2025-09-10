using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo_resteau
{
    public class Article
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public float Prix { get; set; }

        public List<Menu> Menus { get; set; } = new List<Menu>();
        public List<Commande> Commandes { get; set; } = new List<Commande> { };
    }
}