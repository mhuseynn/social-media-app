using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Admin
    {
        public static int _static_id { get; set; }
        public int _id { get; set; }

        private string _username;

        public string Username
        {
            get { return _username; }
            set
            {
                if (value.Length >= 3)
                    _username = value;
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                if (value.EndsWith("@gmail.com") && value.Length > 10)
                    _email = value;
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                if (value.Length >= 8)
                    _password = value;
            }
        }
        public List<Post> posts { get; set; }

        public List<Notification> notifications { get; set; }
        public Admin(string username, string email, string password)
        {
            posts = new List<Post>();
            notifications = new List<Notification>();
            _id = _static_id++;
            Username = username;
            Email = email;
            Password = password;
        }

        public void add_post(Post post)
        {
            posts.Add(post);
        }

        public void remove_post_by_id(int id)
        {
            foreach (var item in posts)
            {
                if (item._id == id)
                {
                    posts.Remove(item);
                    return;
                }
            }
            Console.WriteLine("Not found!!!");
        }

        public void show_posts()
        {
            foreach (var item in posts)
            {
                item.show_post();
                Console.WriteLine();
            }
        }

        public void like_view_post_by_id(string id)
        {
            foreach (var item in posts)
            {
                if (item._id == Convert.ToInt32(id))
                {
                    item.like_count++;
                    item.view_count++;
                    return;
                }

            }
            Console.WriteLine("Not found!!Press any key to continue...");
            Console.ReadKey();
        }
    }
}
