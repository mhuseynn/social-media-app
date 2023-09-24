using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class User
    {
        public static int _static_id { get; set; }
        public int _id { get; set; }
        //----------------------------------------------------------------
        //----------------------------------------------------------------
        private string _username;

        public string User_name
        {
            get { return _username; }
            set
            {
                if (value.Length >= 3)
                    _username = value;
                else
                    throw new Exception("False username");
            }
        }
        //----------------------------------------------------------------
        //----------------------------------------------------------------
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length >= 3)
                    _name = value;
                else
                    throw new Exception("False name");
            }
        }


        private string _surname;

        public string Surname
        {
            get { return _surname; }
            set
            {
                if (value.Length >= 3)
                    _surname = value;
                else
                    throw new Exception("False surname");
            }
        }

        //----------------------------------------------------------------
        //----------------------------------------------------------------
        private string _age;

        public string Age
        {
            get { return _age; }
            set
            {
                if (Convert.ToUInt32(value) >= 13)
                    _age = value;
                else
                    throw new Exception("False age");
            }
        }
        //----------------------------------------------------------------
        //----------------------------------------------------------------
        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                if (value.EndsWith("@gmail.com") && value.Length > 10)
                    _email = value;
                else
                    throw new Exception("False email");
            }
        }
        //----------------------------------------------------------------
        //----------------------------------------------------------------
        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                if (value.Length >= 8)
                    _password = value;
                else
                    throw new Exception("False password");
            }
        }

        public List<int> liked_ids { get; set; }

        public User(string username, string name, string surname, string age, string email, string password)
        {
            _id = _static_id++;
            User_name = username;
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;
            Password = password;
            liked_ids = new List<int>();
        }

        public void show()
        {
            Console.WriteLine("id: " + _id);
            Console.WriteLine("Name: "+Name);
            Console.WriteLine("Surname: "+Surname);
            Console.WriteLine("username: " + _username);
            Console.WriteLine("email: "+Email);
            Console.WriteLine("age: "+Age);
            Console.WriteLine("password: "+"********");
            Console.WriteLine();
        }
    }
}
