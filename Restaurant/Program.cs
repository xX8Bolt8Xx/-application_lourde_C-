using Restaurant;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace exo_resteau
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("---------- MENU ---------");
            Console.WriteLine("1 - Créer une table");
            Console.WriteLine("2 - Créer un article");
            Console.WriteLine("3 - Créer un menu");
            Console.WriteLine("4 - Créer un utilisateur");
            Console.WriteLine("5 - Créer une commande");

            int choix = 0;

            choix = Convert.ToInt32(Console.ReadLine());

            switch (choix)
            {
                case 1:
                    Console.WriteLine("Saisir le nombre de place de la table");
                    int nbPlaceTable = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Saisir le numero de la table");
                    int numeroTable = Convert.ToInt32(Console.ReadLine());
                    var table = new Table { Numero = numeroTable, Places = nbPlaceTable };
                    var db1 = new RestaurantContext();
                    db1.Add(table);
                    db1.SaveChanges();
                    break;

                case 2:
                    Console.WriteLine("Saisir le nom de l'article");
                    string nom = Console.ReadLine();
                    Console.WriteLine("Saisir le prix de l'article");
                    float prix = Convert.ToSingle(Console.ReadLine());
                    var article = new Article { Nom = nom, Prix = prix };
                    var db2 = new RestaurantContext();
                    db2.Add(article);
                    db2.SaveChanges();
                    break;

                case 3:
                    Console.WriteLine("Saisir le nom du menu");
                    string nomMenu = Console.ReadLine();
                    Console.WriteLine("Saisir le prix du menu");
                    float prixMenu = Convert.ToSingle(Console.ReadLine());

                    var db3 = new RestaurantContext();

                    var menu = new Menu { Nom = nomMenu, Prix = prixMenu, Articles = returnArticle(db3) };

                    db3.Add(menu);
                    db3.SaveChanges();
                    break;
                case 4:
                    Console.WriteLine("Saisir votre prenom");
                    string prenomUtilisateur = Console.ReadLine();
                    Console.WriteLine("Saisir votre nom");
                    string nomUtilisateur = Console.ReadLine();
                    var utilisateur = new Utilisateur { Nom = nomUtilisateur, Prenom = prenomUtilisateur };
                    var db4 = new RestaurantContext();
                    db4.Add(utilisateur);
                    db4.SaveChanges();
                    break;
                case 5:
                    Console.WriteLine("Saisir le numero de la Commande");
                    string numeroCommande = Console.ReadLine();

                    var db5 = new RestaurantContext();

                    var commande = new Commande { Numero = numeroCommande, Menus = returnMenu(db5), Articles = returnArticle(db5), Table = returnTable(db5), Utilisateur = returnUtilisateur(db5) };
                    db5.Add(commande);
                    db5.SaveChanges();
                    break;
            }
        }

        public static List<Article> returnArticle(RestaurantContext db)
        {
            var allArticles_db3 = db.Articles.ToList();
            Console.WriteLine("Voici les articles disponibles :");
            foreach (var art in allArticles_db3)
            {
                Console.WriteLine($"{art.Id} - {art.Nom} : {art.Prix} $");
            }
            List<Article> choixListArticle = new List<Article>();
            int choixIdArticle = Convert.ToInt32(Console.ReadLine());
            choixListArticle.Add(db.Find<Article>(choixIdArticle));
            return choixListArticle;
        }
        public static List<Menu> returnMenu(RestaurantContext db)
        {
            var allMenus_db5 = db.Menus.ToList();
            Console.WriteLine("Voici les menus disponibles :");
            foreach (var men in allMenus_db5)
            {
                Console.WriteLine($"{men.Id} - {men.Nom} : {men.Prix} $");
            }
            List<Menu> choixListMenu = new List<Menu>();
            int choixIdMenu = Convert.ToInt32(Console.ReadLine());
            choixListMenu.Add(db.Find<Menu>(choixIdMenu));
            return choixListMenu;
        }
        public static Table returnTable(RestaurantContext db)
        {
            var allTables_db1 = db.Tables.ToList();
            Console.WriteLine("Voici les tables disponibles :");
            foreach (var tab in allTables_db1)
            {
                Console.WriteLine($"{tab.Id} - {tab.Numero} : {tab.Places} places");
            }
            int choixIdTable = Convert.ToInt32(Console.ReadLine());
            var tableChoisie = db.Find<Table>(choixIdTable);
            return tableChoisie;
        }
        public static Utilisateur returnUtilisateur(RestaurantContext db)
        {
            var allUtilisateurs_db4 = db.Utilisateurs.ToList();
            Console.WriteLine("Voici les utilisateurs disponibles :");
            foreach (var uti in allUtilisateurs_db4)
            {
                Console.WriteLine($"{uti.Id} - {uti.Prenom} {uti.Nom}");
            }
            int choixIdUtilisateur = Convert.ToInt32(Console.ReadLine());
            var utilisateurChoisie = db.Find<Utilisateur>(choixIdUtilisateur);
            return utilisateurChoisie;
        }   
    }
}