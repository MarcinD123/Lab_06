using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_06
{
    public class User
    {
        public User(string name, string role, int age, int[] marks, DateTime? createdAt, DateTime? removedAt)
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
        public DateTime? CreatedAt { get; set; }
        public DateTime? RemovedAt { get; set; }
    }


}
