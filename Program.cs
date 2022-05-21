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
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Role);                
                if (item.Marks!=null)
                {
                    foreach (var mark in item.Marks)
                    {
                        Console.Write(mark+' ');
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("_______-");
            }
            //1.ilość rekordów w tablicy
            Console.WriteLine("1:"+users.Count);



            //2.Listę nazw użytkowników
            var names = from user in users
                        select user.Name;
            Console.WriteLine("2:");
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }


            //3.Posortowanych użytkowników po nazwach
            var groupByName = users.OrderBy(x => x.Name);
            Console.WriteLine("3:");
            foreach (var item in groupByName)
            {
                Console.WriteLine(item.Name);
            }


            //4.Listę dostępnych ról użytkowników
            Console.WriteLine("4");
            var listOfRoles = from person in users
                              group person by person.Role into newGroup
                              orderby newGroup.Key
                              select newGroup;
            
            foreach (var item in listOfRoles)
            {
                Console.WriteLine(item.new);
            }

        }
    }
}
