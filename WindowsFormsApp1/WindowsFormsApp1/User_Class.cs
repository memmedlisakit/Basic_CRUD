using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class User_Class
    {
        // class static property
        public static int id_count = 1555;
        public static List<User_Class> users = new List<User_Class>();

        // object property non static
        public int Id;
        public string Name;
        public string Surname;
        public int Age;
        public bool Gender;
        public DateTime Created_Date;

        public User_Class(string name, string surname, int age, bool gender)
        { 
            Id = id_count;
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
            Created_Date = DateTime.Now;
            id_count++; 
            users.Add(this);
            
        }

 
    }
}
