using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_06
{
    [Serializable]
    public class User
    {
        public User(string name, string role, int age, int[] marks, DateTime createdAt, DateTime? removedAt)
        {
            Name = name;
            Role = role;
            Age = age;
            Marks = marks;
            CreatedAt = createdAt;
            RemovedAt = removedAt;
        }

        public string Name { get; set; }
        public string Role { get; set; }
        public int Age { get; set; }
        public int[] Marks { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? RemovedAt { get; set; }
        public User()
        {

        }
        public static void Write(User item)
        {
            Console.WriteLine("USER NAME: " + item.Name);
            Console.WriteLine("USER ROLE: " + item.Role);
            Console.WriteLine("USER AGE: " + item.Age);
            if (item.Marks != null)
            {
                Console.WriteLine("USER MARKS");
                var oceny = string.Join(", ", item.Marks);
                Console.WriteLine(oceny);
            }
            Console.WriteLine("CREATED AT: " + item.CreatedAt);
            Console.WriteLine("REMOVED AT: " + item.RemovedAt);

            Console.WriteLine("------------------------");
        }
    }


}
