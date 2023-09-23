using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Notification
    {
        public static int _static_id { get; set; }
        public int _id { get; set; }

        public string text { get; set; }

        public DateTime creation_time { get; set; }
        public string from_user { get; set; }

        public Notification(string text, DateTime creation_time,string user_name)
        {
            _id= _static_id++;
            this.text = text;
            this.creation_time = creation_time;
            this.from_user = user_name;
        }

        public void show()
        {
            Console.WriteLine("id" + _id);
            Console.WriteLine("From user"+from_user);
            Console.WriteLine("Creation time"+creation_time);
            Console.WriteLine("Notification"+text);
        }
    }
}
