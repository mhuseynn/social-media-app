using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Database
    {
        public List<User> users { get; set; }

        public Database()
        { 
            users = new List<User>();
        }

        public void add_user(User user)
        {
            users.Add(user);
        }
        public User search_user(string username,string password) 
        {
            foreach (var item in users)
            {
                if (item.User_name==username && item.Password == password) return item;
            }
            return null;
        }
        public void delete_user_by_id(int id)
        {
            foreach (var item in users)
            {
                if(item._id==id)
                {
                    users.Remove(item);
                    return;
                }
            }
            Console.WriteLine("User not found!!!");
        }
        public void show_users()
        {
            if (users != null)
            {
                foreach (var item in users)
                {
                    item.show();
                }
            }
            else
                throw new Exception("No users");

        }

    }
}
