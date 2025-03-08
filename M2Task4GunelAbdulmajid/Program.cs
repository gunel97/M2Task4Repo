using System.Runtime.CompilerServices;

namespace M2Task4GunelAbdulmajid
{
    internal class Program
    {
        static User[] Users = [new ("admin1", "1234", Role.Admin),
                new ("user1","1234",Role.User)];
        static void Main(string[] args)
        {
            User user;
            var movieActions = new MovieActions();
            do
            {
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();
                user = GetUser(username, password);
            }
            while (user.UserName == "undefined");
            if (user.Role == Role.Admin)
            {
                Console.BackgroundColor= ConsoleColor.Red;
                Console.ForegroundColor= ConsoleColor.Black;
                Console.WriteLine($"Welcome Admin -  {user.UserName}!");
                do
                {
                    Console.WriteLine("Choose command:");
                    Console.WriteLine("1 - Add Movie");
                    Console.WriteLine("2 - Remove Movie");
                    Console.WriteLine("3 - Add Genre");
                    Console.WriteLine("4 - Remove Genre");
                    Console.WriteLine("5 - Most Viewed Movie");
                    Console.WriteLine("6 - EXIT");

                    string command = Console.ReadLine();
                    switch (command)
                    {
                        case "1":
                            movieActions.AddMovie();
                            break;
                        case "2":
                            movieActions.RemoveMovie();
                            break;
                        case "3":
                            movieActions.AddGenre();
                            break;
                        case "4":
                            movieActions.RemoveGenre();
                            break;
                        case "5":
                            movieActions.MostViewedMovie();
                            break;
                        case "6":
                            
                            return;
                        default:
                            Console.WriteLine("Not correct command");
                            break;
                    }
                }
                while (true);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Welcome User - {user.UserName}!");
                do
                {
                    Console.WriteLine("Choose command:");
                    Console.WriteLine("1 - Watch Movie");
                    Console.WriteLine("2 - Filter Movie by Genre");
                    Console.WriteLine("3 - Add to watchlist");
                    Console.WriteLine("4 - Search Movie");
                    Console.WriteLine("5 - EXIT");

                    string command = Console.ReadLine();
                    switch (command)
                    {
                        case "1":
                            movieActions.WatchMovie();
                            break;
                        case "2":
                            movieActions.FilterMovieByGenre();
                            break;
                        case "3":
                            movieActions.AddWatchList(user);
                            break;
                        case "4":
                            movieActions.SearchMovie();
                            break;
                        case "5":
                            return;
                        default:
                            Console.WriteLine("Not correct command");
                            break;
                    }
                }
                while (true);
            }

            static User GetUser(string username, string password)
            {
                foreach (var user in Users)
                {
                    if (user.UserName == username && user.Password == password)
                    {
                        return user;
                    }
                }

                return new User("undefined", "undefined", (Role)2);
            }
        }
    }
}