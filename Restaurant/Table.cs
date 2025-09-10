using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo_resteau
{
    public class Table
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Places { get; set; }

        public List<Commande> Commandes { get; set; } = new List<Commande>();
    }
}