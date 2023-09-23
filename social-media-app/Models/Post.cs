using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Post
    {
        public static int _static_id { get; set; }
        public int _id { get; set; }

        private string _content;

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public DateTime creation_time { get; set; }

        public int like_count { get; set; }
        public int view_count { get; set; }

        public Post(string content, DateTime date_time)
        {
            _id = _static_id++;
            Content = content;
            creation_time = date_time;
            like_count = 0;
            view_count = 0;
        }

        public void show_post()
        {
            Console.WriteLine("Id: " + _id);
            Console.WriteLine(@" ------------------
|                  |
|                  |
|    Post:)        |
|                  |
|                  |
|                  |
 ------------------");
            Console.WriteLine("like" + like_count + "     " + "view" + view_count);
        }

    }
}
