using System.Runtime.CompilerServices;

namespace M2Task4GunelAbdulmajid
{
    internal class Program
    {
        static User[] Users = [new ("admin1", "1234", Role.Admin),
                new ("user1","1234",Role.User)];
        static void Main(string[] args)
        {
            bool LoggedIn = false;
            User user;
            var movieActions = new MovieActions();
            do
            {
                do
                {
                    Console.BackgroundColor = default;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = Console.ReadLine();
                    user = GetUser(username, password);
                }
                while (user.UserName == "undefined");
                if (user.Role == Role.Admin)
                {
                    LoggedIn = true;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"Welcome Admin -  {user.UserName}!");
                    do
                    {
                        Console.WriteLine("Choose command:");
                        Console.WriteLine("1 - Add Movie");
                        Console.WriteLine("2 - Remove Movie");
                        Console.WriteLine("3 - Add Genre");
                        Console.WriteLine("4 - Remove Genre");
                        Console.WriteLine("5 - Most Viewed Movie");
                        Console.WriteLine("6 - Log Out");
                        Console.WriteLine("7 - EXIT");

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
                                LoggedIn = false;
                                break;
                            case "7":

                                return;
                            default:
                                Console.WriteLine("Not correct command");
                                break;
                        }
                    }
                    while (LoggedIn);
                }
                else
                {
                    LoggedIn = true;
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
                        Console.WriteLine("5 - Log Out");
                        Console.WriteLine("6 - EXIT");

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
                                LoggedIn = false;
                                break;
                            case "6":

                                return;
                            default:
                                Console.WriteLine("Not correct command");
                                break;
                        }
                    }
                    while (LoggedIn);
                }
            }
            while (!LoggedIn);
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