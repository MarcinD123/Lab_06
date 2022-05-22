using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Lab_06
{
     class ListofUsers
    {
        public string[] Names = new string[] { "Janusz", "Andrzej", "Władysław", "Domino", "Franciszek", "Mariusz", "Mateusz", "Damian", "Rafał", "Kamil", "Marek", "Michał", "Szymon", "Dariusz", "Tomasz" };
        
        public string[] Role = new string[] { "ADMIN", "MODERATOR", "TEACHER", "STUDENT" };

        public int xd { get; set; }
        public User Generator()
        {
            Random rnd = new Random();
            var name = Names[rnd.Next(Names.Length)];

            string rola; ;

            int szansaNaRole = rnd.Next(0,100);
            //Console.WriteLine(szansaNaRole);
            if (szansaNaRole>90)
            {
                rola = "ADMIN";
            }
            else if(szansaNaRole<=90&szansaNaRole>75)
            { rola = "MODERATOR"; }
            else if (szansaNaRole<=75&szansaNaRole>50)
            {
                rola = "TEACHER";
            }
            else
            {
                rola = "STUDENT";
            }

            var age = rnd.Next(20, 80);

            int[] oceny = new int[rnd.Next(5, 10)];
            for (int i = 0; i < oceny.Length; i++)
            {
                oceny[i] = rnd.Next(1, 7);
                Thread.Sleep(5);
            }

            if (rola!="STUDENT")
            {
                oceny = null;
            }
            
            //Thread.Sleep(10);
            DateTime created = new DateTime(1990, 1, 1).AddDays(rnd.Next(20, 5000));
            DateTime? deleted = new DateTime(2000, 1, 1).AddDays(rnd.Next(20, 5000));
            if (rnd.Next()%5==0)
            {
                deleted = null;
            }
            User user = new User(name, rola, age, oceny, created, deleted);
            
            return user;
            
        }
    }
}
