using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_06
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            ListofUsers newusers = new ListofUsers();
            int numberOfUsers = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfUsers; i++)
            {

                users.Add(newusers.Generator());
            }
            foreach (var item in users)
            {
                Console.WriteLine("USER NAME: "+item.Name);
                Console.WriteLine("USER ROLE: "+item.Role);
                Console.WriteLine("USER AGE: "+item.Age);
                if (item.Marks != null)
                {
                    Console.WriteLine("USER MARKS");
                    var oceny = string.Join(", ", item.Marks);
                    Console.WriteLine(oceny);                   
                }
                Console.WriteLine("CREATED AT: "+item.CreatedAt);
                Console.WriteLine("REMOVED AT: "+item.RemovedAt);

                Console.WriteLine("------------------------");
            }
            //1.ilość rekordów w tablicy
            Console.WriteLine("1:" + users.Count);
            Console.WriteLine("------------------------");


            //2.Listę nazw użytkowników
            var names = from user in users
                        select user.Name;
            Console.WriteLine("2:");
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------");

            //3.Posortowanych użytkowników po nazwach
            var groupByName = users.OrderBy(x => x.Name);
            Console.WriteLine("3:");
            foreach (var item in groupByName)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("------------------------");

            //4.Listę dostępnych ról użytkowników
            Console.WriteLine("4:");
            var listOfRoles = from person in users
                              group person by person.Role;
                                         
            foreach (var item in listOfRoles)
            {
                Console.WriteLine(item.Key);
            }
            Console.WriteLine("------------------------");


            //5.Listy pogrupowanych użytkowników po rolach
            Console.WriteLine("5:");

            var roleAndName = users.OrderBy(x => x.Role);
            foreach (var item in roleAndName)
            {
                Console.WriteLine(item.Role+" "+item.Name);
            }
            Console.WriteLine("------------------------");


            //6.Ilość rekordów, dla których podano oceny (nie null i więcej niż 0)
            Console.WriteLine("6:");
            var zOcenami = from person in users
                           where person.Marks != null
                           select person;
            Console.WriteLine(zOcenami.Count());
            Console.WriteLine("------------------------");

            //7.Sumę, ilość i średnią wszystkich ocen studentów
            Console.WriteLine("7:");
            //suma
            
                          


            //8.Najlepszą ocenę
            Console.WriteLine("8:");
            






        }
    }
}
