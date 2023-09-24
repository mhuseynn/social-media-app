using Models;
using social_media_app.Models;
using System.Net;
using System.Net.Mail;
/*
 
 Bu tapshiriqda programin
AdminNamespace
UserNamespace
PostNameSpace bolmelisiniz
//etdiyiniz elaveler uchun 
meselen:mail uchun networknamespace yarada bilersiniz

Admin=>id,username,email,password,Posts,Notifications
User=>id,name,surname,age,email,password
Post=>id,Content,CreationDateTime,LikeCount,ViewCount

Notification=>id,Text,DateTime,FromUser(bu hansi user terefinden bu bildirishin geldiyidir)

Demeli sistemde 2 teref var User ve Admin
1.program achilanda user ve ya admin kimi daxil olmasi sorushulur
2.her ikisi de username(ve ya email) ve password daxil edirler
3.User yalniz umumi postlara baxa biler ve
Like ede biler(baxmaq ve like procesini ID esasinda apara bilersiniz)
Meselen :posta baxish uchun id ni daxil edin ve like uchun
Id daxil edin
her defe posta baxildiqca ve ya like edildikce postun baxish sayi ve like sayi artir
ve her defe de admine bildirish gelir her baxish ve ya like edilende
(BU SISTEMI DAHA DA TEKMILLESHDIRIB MAIL SISTEMI
YARADA BILERSINIZ MESELEN 
her defe notificationlar yaransin hem Admin klasindaki notification elave olunsun hem de mail olaraq admine gonderile biler)
 
 */


User._static_id = 0;
Admin._static_id = 0;
Post._static_id = 0;
Notification._static_id = 0;

static void menu_print(string[] menu, int a)
{
    Console.Clear();
    for (int i = 0; i < menu.Length; i++)
    {

        if (i == a)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.WriteLine(menu[i]);
    }
}
static bool only_one_like_check(User user, string id)
{
    foreach (var item in user.liked_ids)
    {

        if (item == Convert.ToInt32(id))
        {
            return false;
        }

    }
    return true;
}

User test = new("huseyn", "huseyn", "mehdiyev", "23", "h@gmail.com", "huseyn123");
Post post1 = new("ilk post", DateTime.Now);

Database database = new Database();
database.add_user(test);

Admin admin = new("admin", "socialmediaapp585@gmail.com", "admin123");
admin.add_post(post1);

string[] menu = { "\n\n\n\t\t\t\t Admin", "\t\t\t\tSign in", "\t\t\t\tSign up" };
string[] user_menu = { "\n\n\n\t\t\t\t All posts", "\t\t\t\tLike and View post", "\t\t\t<=Back" };
string[] admin_menu = { "\n\n\n\t\t\t\t Show all users", "\t\t\t\t Delete User", "\t\t\t\tDelete Post", "\t\t\t\tShare Post", "\t\t\t\tNotifications", "\t\t\t\t<=Back", };

while (true)
{
    int a = 0;
    ConsoleKeyInfo key;

    while (true)
    {
        menu_print(menu, a);
        key = Console.ReadKey();

        if (key.Key == ConsoleKey.UpArrow)
        {
            if (a > 0)
                a--;
            else
                a = 2;
        }
        else if (key.Key == ConsoleKey.DownArrow)
        {
            if (a < 2)
                a++;
            else
                a = 0;
        }
        if (key.Key == ConsoleKey.Enter)
        {
            break;
        }
    }
    #region Admin
    if (a == 0)
    {
        Console.Clear();
        #region Admin username and password check
        while (true)
        {

            Console.Write("Admin username: ");
            string username = Console.ReadLine();
            Console.Write("Admin password: ");
            string password = Console.ReadLine();
            if (username == admin.Username && password == admin.Password)
            {
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Try again!!!");
            }

        }
        #endregion

        #region Admin menu
        int b = 0;
        ConsoleKeyInfo admin_key;
        while (true)
        {
            while (true)
            {
                menu_print(admin_menu, b);
                admin_key = Console.ReadKey();

                if (admin_key.Key == ConsoleKey.UpArrow)
                {
                    if (b > 0)
                        b--;
                    else
                        b = 5;
                }
                else if (admin_key.Key == ConsoleKey.DownArrow)
                {
                    if (b < 5)
                        b++;
                    else
                        b = 0;
                }
                if (admin_key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
            #endregion

            if (b == 0)
            {
                Console.Clear();
                try
                {
                    database.show_users();
                    Console.Write("\nPress any key to continue...");
                    Console.ReadKey();
                }
                catch (Exception)
                {
                    Console.Write("No Users\nPress any key to continue...");
                    Console.ReadKey();
                }

            }
            if (b == 1)
            {
                Console.Clear();
                Console.Write("User id(for delete): ");
                string id = Console.ReadLine();
                database.delete_user_by_id(Convert.ToInt32(id));
                Console.Write("Press any key to continue...");
                Console.ReadKey();

            }
            if (b == 2)
            {
                Console.Clear();
                Console.Write("Id: ");
                string id_ = Console.ReadLine();
                admin.remove_post_by_id(Convert.ToInt32(id_));
            }
            if (b == 3)
            {
                Console.Clear();
                Console.Write("Post Content: ");
                string content = Console.ReadLine();
                Post post = new(content, DateTime.Now);
                admin.add_post(post);
            }
            if (b == 4)
            {
                Console.Clear();
                if (admin.notifications == null)
                {
                    Console.Write("Not notification.Press any key to continue...");
                    Console.ReadKey();
                }
                foreach (var item in admin.notifications)
                {
                    item.show();
                    Console.WriteLine();
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }

            }
            if (b == 5)
            {
                break;
            }
        }

    }
    #endregion

    #region Sign  in
    if (a == 1)
    {
        string username, password;

        while (true)
        {

            Console.Write("User username: ");
            username = Console.ReadLine();
            Console.Write("User password: ");
            password = Console.ReadLine();
            if (database.search_user(username, password) != null)
            {
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("User not found.Try again!!!");
            }

        }
        int c = 0;
        ConsoleKeyInfo user_key;
        while (true)
        {
            while (true)
            {
                menu_print(user_menu, c);
                user_key = Console.ReadKey();

                if (user_key.Key == ConsoleKey.UpArrow)
                {
                    if (c > 0)
                        c--;
                    else
                        c = 2;
                }
                else if (user_key.Key == ConsoleKey.DownArrow)
                {
                    if (c < 2)
                        c++;
                    else
                        c = 0;
                }
                if (user_key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
            if (c == 0)
            {
                Console.Clear();
                admin.show_posts();
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
            if (c == 1)
            {
                Console.Clear();
                Console.Write("Id(for like post): ");
                string id = Console.ReadLine();
                if (database.search_user(username, password) != null)
                {
                    if (only_one_like_check(database.search_user(username, password), id))
                    {
                        Notification notification = new Notification($"{id} id  post viewed and liked by {username}", DateTime.Now, username);
                        admin.notifications.Add(notification);
                        database.search_user(username, password).liked_ids.Add(Convert.ToInt32(id));
                        admin.like_view_post_by_id(id);
                        Service1 service1 = new Service1();
                        service1.SendEmail("socialmediaapp585@gmail.com", "Notification", $"username {username} liked post id: {id}");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("It is liked");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
            }
            if (c == 2)
            {
                break;
            }
        }
    }
    #endregion

    #region Sign up
    if (a == 2)
    {
        #region Sign up
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1.Password must be more than 8 character\n2.email format must be @gmail.com\n3.age must be more than 13");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Sign up");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Surname: ");
            string surname = Console.ReadLine();
            Console.Write("Age: ");
            string age = (Console.ReadLine());
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            try
            {
                User user = new User(username, name, surname, age, email, password);
                database.add_user(user);
                break;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Try again!!!\n");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
        }


        #endregion
    }
    #endregion
}


