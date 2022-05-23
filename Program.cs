using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

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
                User.Write(item);
            }
            //1.ilość rekordów w tablicy
            Console.WriteLine("1.Ilość rekordów w tablicy:" + users.Count);
            Console.WriteLine("------------------------");


            //2.Listę nazw użytkowników
            var names = from user in users
                        select user.Name;
            Console.WriteLine("2.Lista nazw użytkowników:");
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------");

            //3.Posortowanych użytkowników po nazwach
            var groupByName = users.OrderBy(x => x.Name);
            Console.WriteLine("3.Lista posortowanych użytkowników po nazwach:");
            foreach (var item in groupByName)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("------------------------");

            //4.Listę dostępnych ról użytkowników
            Console.WriteLine("4.Lista dostępnych ról użytkowników");
            var listOfRoles = from person in users
                              group person by person.Role;

            foreach (var item in listOfRoles)
            {
                Console.WriteLine(item.Key);
            }
            Console.WriteLine("------------------------");


            //5.Listy pogrupowanych użytkowników po rolach
            Console.WriteLine("5.Lista pogrupowanych użytkowników po rolach:");

            var roleAndName = users.OrderBy(x => x.Role);
            foreach (var item in roleAndName)
            {
                Console.WriteLine(item.Role + " " + item.Name);
            }
            Console.WriteLine("------------------------");


            //6.Ilość rekordów, dla których podano oceny (nie null i więcej niż 0)
            Console.WriteLine("6.Ilość rekordów, dla których podano oceny (nie null i więcej niż 0)");
            var zOcenami = from person in users
                           where person.Marks != null
                           select person;
            Console.WriteLine("OSOBY Z OCENAMI: " + zOcenami.Count());
            Console.WriteLine("------------------------");

            //7.Sumę, ilość i średnią wszystkich ocen studentów
            Console.WriteLine("7.Suma, ilość i średnia wszystkich ocen studentów:");
            var sumaocen = zOcenami.Sum(item => item.Marks.Sum());
            Console.WriteLine("SUMA: " + sumaocen);
            var iloscocen = zOcenami.Sum(item => item.Marks.Length);
            Console.WriteLine("ILOŚĆ OCEN: " + iloscocen);
            Console.WriteLine("ŚREDNIA: " + (double)sumaocen / iloscocen);



            //8.Najlepszą ocenę
            Console.WriteLine("8.Najlepsza ocena:");
            if (zOcenami.Count() > 0)
            {
                var najlepszaOcena = zOcenami.Max(x => x.Marks.Max());
                //var jedna = najlepszaOcena.Max();
                Console.WriteLine("NAJLEPSZA OCENA: " + najlepszaOcena);
            }
            else
            {
                Console.WriteLine("BRAK");
            }
            Console.WriteLine("------------------------");

            //9.Najgorszą ocenę
            Console.WriteLine("9.Najgorsza ocena");
            if (zOcenami.Count() > 0)
            {
                var najgorsza = zOcenami.Min(x => x.Marks.Min());
                Console.WriteLine("NAJGORSZA OCENA: " + najgorsza);
            }
            else
            {
                Console.WriteLine("BRAK");
            }
            Console.WriteLine("------------------------");



            //11.Listę studentów, którzy posiadają najmniej ocen
            Console.WriteLine("11.Lista studentów, którzy posiadają najmniej ocen");

            var najmniejOcen = from person in zOcenami
                               orderby person.Marks.Count()
                               select new { person.Name, person.Marks.Length };
            foreach (var item in najmniejOcen)
            {
                Console.WriteLine(item.Name + " " + item.Length);
            }
            Console.WriteLine("------------------------");
            //string listaStudentów = string.Join(", ", najmniejOcen); 
            //Console.WriteLine(listaStudentów);
            //Console.WriteLine("------------------------");

            //12.Listę studentów, którzy posiadają najwięcej ocen
            Console.WriteLine("12. Lista studentów, którzy posiadają najwięcej ocen");
            var najwiecejOcen = from person in zOcenami
                                orderby person.Marks.Count()
                                descending
                                select new { person.Name, person.Marks.Length };
            foreach (var item in najwiecejOcen)
            {
                Console.WriteLine(item.Name + " " + item.Length);
            }
            Console.WriteLine("------------------------");
            //13.Listę obiektów zawierających tylko nazwę i średnią ocenę (mapowanie na inny obiekt)
            Console.WriteLine("13. Lista obiektów zawierających tylko nazwę i średnią ocenę: ");
            var nazwaISrednia = from person in zOcenami

                                select new { person.Name, X = (double)person.Marks.Sum() / person.Marks.Length };
            foreach (var item in nazwaISrednia)
            {
                Console.WriteLine("IMIE: " + item.Name + " ŚREDNIA: " + item.X);
            }
            Console.WriteLine("------------------------");

            //14. Studentów posortowanych od najlepszego
            Console.WriteLine("14. Lista studentów posortowanych od najlepszego");
            var najlepsi = from person in nazwaISrednia
                           orderby person.X
                           descending
                           select person.Name;


            foreach (var item in najlepsi)
            {
                Console.WriteLine("IMIE: " + item);
            }
            Console.WriteLine("------------------------");

            //10.Najlepszy student

            Console.WriteLine("10. Najlepszy student:");
            var najlepsi2 = from person in nazwaISrednia
                            orderby person.X
                            descending
                            select new { person.Name, person.X };

            var najlepszy3 = najlepsi2.Take(1);
            foreach (var item in najlepszy3)
            {
                Console.WriteLine(item.Name + " " + item.X);
            }
            Console.WriteLine("------------------------");

            //15Średnią ocenę wszystkich studentów
            //zrobione w pkt7.

            //16. Listę użytkowników pogrupowanych po miesiącach daty utworzenia (np. 2022-02, 2022-03, 2022-04, itp.)
            Console.WriteLine("16.Lista użytkowników pogrupowanych po miesiącach daty utworzenia (np. 2022-02, 2022-03, 2022-04, itp:");
            var miesiace = users.GroupBy(x => x.CreatedAt.Month).OrderBy(x => x.Key);
            foreach (var item in miesiace)
            {
                Console.WriteLine("MIESIAC-" + item.Key);
                foreach (var ins in item)
                {
                    Console.WriteLine(ins.Name + " " + ins.CreatedAt);
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------------------");


            //17.Listę użytkowników, którzy nie zostali usunięci (data usunięcia nie została ustawiona)
            Console.WriteLine("17.Lista użytkowników, którzy nie zostali usunięci (data usunięcia nie została ustawiona)");

            var nieUsunieci = from person in users
                              where person.RemovedAt == null
                              select person.Name;
            string res = string.Join(", ", nieUsunieci);
            Console.WriteLine(res);
            Console.WriteLine("------------------------");

            //18.Najnowszego studenta (najnowsza data utworzenia)
            var najnowszy2 = users.OrderBy(x => x.CreatedAt).Take(1);
            Console.WriteLine("18. Najnowszy student:");
            var najnowszy = from person in users
                            orderby person.CreatedAt
                            descending
                            select person;
            //Console.WriteLine(najnowszy2);
            foreach (var item in najnowszy2)
            {
                Console.WriteLine(item.Name + " " + item.CreatedAt);
            }
            Console.WriteLine("------------------------");


            Console.WriteLine("SERIALIZACJA XML USERA:");
            //serializacja xml usera
            string xmlserialized;
            
            XmlSerializer serializer = new XmlSerializer(typeof(User));           
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.Serialize(stream, users[0]);

                stream.Flush();
                xmlserialized = Encoding.UTF8.GetString(stream.ToArray());

                Console.WriteLine(xmlserialized);
                Console.WriteLine("------------------------");
            //deserializacja xml usera
            }

            Console.WriteLine("DESERIALIACJA XML USERA:");
            byte[] bytes = Encoding.UTF8.GetBytes(xmlserialized);
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                User deserializedUser = (User)serializer.Deserialize(stream);
                User.Write(deserializedUser);
               
            }
            Console.WriteLine("------------------------");


            string xmlArrayOfUsers;
            //serializacja xml listy
            Console.WriteLine("SERIALIZACJA LISTY:");
            XmlSerializer listSerializer = new XmlSerializer(users.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                listSerializer.Serialize(stream, users);
                
                stream.Flush();
                xmlArrayOfUsers = Encoding.UTF8.GetString(stream.ToArray());
                Console.WriteLine(xmlArrayOfUsers);
            }

            //deserializacja xml listy 

            Console.WriteLine("DESERIALIACJA LISTY XML");
            bytes = Encoding.UTF8.GetBytes(xmlArrayOfUsers);
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                List<User> deserializedList = (List<User>)listSerializer.Deserialize(stream);
                foreach (var item in deserializedList)
                {
                    User.Write(item);
                }
            }


        }






    }
}
