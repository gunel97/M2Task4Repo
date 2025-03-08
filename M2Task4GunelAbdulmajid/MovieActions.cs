using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace M2Task4GunelAbdulmajid
{
    public class MovieActions
    {
        private int _sizeMovie = 0;
        private Movie[] _movies = new Movie[5];

        private Genre[] _genres = new Genre[5];
        private int _sizeGenre = 0;

        private WatchList[] _watchListItems = new WatchList[5];
        private int _sizeWatchList = 0;
        public MovieActions()
        {
            _genres[0] = new Genre("drama");
            _sizeGenre++;
            _genres[1] = new Genre("comedy");
            _sizeGenre++;

            _movies[0] = new Movie("movie1", _genres[0], 7.6);
            _movies[0].CountOfViews = 3;
            _sizeMovie++;
            _movies[1] = new Movie("movie2", _genres[1], 8.0);
            _movies[1].CountOfViews = 5;
            _sizeMovie++;
        }
        public void ShowWatchList(User user)
        {
            Console.WriteLine("Your watchlist: ");
            for (int i = 0; i < _sizeWatchList; i++)
            {
                if (_watchListItems[i].User == user)
                {
                    PrintMovieById(_watchListItems[i].Movie.Id);
                }
            }
        }

        public bool IsRepeatedInWatchList(Movie movie, User user)
        {
            for (int i = 0; i < _sizeWatchList; i++)
            {
                if (_watchListItems[i].Movie == movie && _watchListItems[i].User == user)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddWatchList(User user)
        {
            PrintMovies();
            Console.WriteLine("Enter movie name");
            string s = Console.ReadLine();
            Movie movie = FindMovie(s);
            if (movie != null && !IsRepeatedInWatchList(movie, user))
            {
                if (_sizeWatchList >= _watchListItems.Length)
                {
                    WatchList[] tmpWatchList = new WatchList[_watchListItems.Length * 2];
                    Array.Copy(_watchListItems, tmpWatchList, _watchListItems.Length);
                    _watchListItems = tmpWatchList;
                }
                _watchListItems[_sizeWatchList++] = new WatchList(movie, user);
                Console.WriteLine($"Movie {movie.Name} successfully added watchlist");
                ShowWatchList(user);

                return;
            }
            if (IsRepeatedInWatchList(movie, user))
            {
                Console.WriteLine($"Movie {movie.Name} already exists in your watchlist.");
                ShowWatchList(user);

                return;
            }
            else
            {
                Console.WriteLine($"Movie name {s} does not exist!");

                return;
            }
        }

        public void AddGenre()
        {
            Console.WriteLine("Enter new genre: ");
            string newGenre = Console.ReadLine();
            if (IsFoundGenre(newGenre))
                Console.WriteLine("This genre exists!");
            else
            {
                var genre = new Genre(newGenre);
                if (_sizeGenre >= _genres.Length)
                {
                    Genre[] tmpGenres = new Genre[_genres.Length * 2];
                    Array.Copy(_genres, tmpGenres, _genres.Length);
                    _genres = tmpGenres;
                }
                _genres[_sizeGenre++] = genre;
                Console.WriteLine("***** - New Genre Added - *****");
                Console.WriteLine();
                PrintGenres();
            }
        }

        public void RemoveGenre()
        {
            PrintGenres();
            Console.WriteLine("Enter the genre name to remove:");
            string genreName = Console.ReadLine();
            var genre = FindGenre(genreName);
            if (genre != null)
            {
                for (int j = genre.Id; j < _genres.Length - 1; j++)
                {
                    _genres[j] = _genres[j + 1];
                }
                _genres[_sizeGenre - 1] = default;
                _sizeGenre -= 1;
                Console.WriteLine();
                Console.WriteLine("***** - Genre deleted! - *****");
                Console.WriteLine();
                PrintGenres();

                return;
            }
            else
            {
                Console.WriteLine("***** - Genre not found! - *****");
            }
        }

        public void PrintGenres()
        {
            Console.WriteLine($"{"Id",-4} {"Name",-20}");
            for (int i = 0; i < _sizeGenre; i++)
            {
                var item = _genres[i];
                Console.WriteLine(new string('-', 30));
                Console.WriteLine($"{item.Id,-4} {item.Name,-20}");
            }
            Console.WriteLine(new string('-', 30));
            Console.WriteLine();
        }

        public bool IsFoundGenre(string genreName)
        {
            for (int i = 0; i < _sizeGenre; i++)
            {
                if (_genres[i].Name == genreName)
                {
                    return true;
                }
            }
            return false;
        }

        public Genre FindGenre(string genreName)
        {
            for (int i = 0; i < _sizeGenre; i++)
            {
                if (_genres[i].Name == genreName)
                {
                    return _genres[i];
                }
            }
            return null;
        }

        public void PrintMovies()
        {
            Console.WriteLine($"{"Id",-4} {"Name",-20} {"Genre",-10} {"Imdb",-5}, Count of views");

            for (int i = 0; i < _sizeMovie; i++)
            {
                if (_movies[i] == null)
                    continue;
                PrintMovieById(_movies[i].Id);
            }
            Console.WriteLine(new string('-', 60));
            Console.WriteLine();
        }

        public void PrintMovieById(int id)
        {
            for (int i = 0; i < _sizeMovie; i++)
            {
                if (_movies[i].Id == id)
                {
                    Console.WriteLine(new string('-', 60));
                    Console.WriteLine($"{_movies[i].Id,-4} {_movies[i].Name,-20} {_movies[i].Genre.Name,-10} {_movies[i].Imdb,-5} {_movies[i].CountOfViews}");
                }
            }
            Console.WriteLine(new string('-', 60));
        }

        public void AddMovie()
        {
            Genre genre;
            double imdb;
            Console.WriteLine("Enter movie name: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Enter genre: ");
            string genreName = Console.ReadLine();
            if (IsFoundGenre(genreName))
            {
                genre = FindGenre(genreName);
            }
            else
            {
                Console.WriteLine($"Genre {genreName} does not exist");
                return;
            }
            Console.WriteLine("Enter IMDB: ");
            if (!double.TryParse(Console.ReadLine(), out imdb))
            {
                Console.WriteLine("Not correct input");

                return;
            }
            if (FindMovie(name) == null)
            {
                var movie = new Movie(name, genre, imdb);

                if (_sizeMovie >= _movies.Length)
                {
                    Movie[] tmpMovies = new Movie[_movies.Length * 2];
                    Array.Copy(_movies, tmpMovies, _movies.Length);
                    _movies = tmpMovies;
                }
                _movies[_sizeMovie++] = movie;
                Console.WriteLine("***** - Movie added successfully - *****");
                Console.WriteLine();
                PrintMovies();
            }
            else
            {
                Console.WriteLine($"Movie {name} already exists!");
            }
        }

        public Movie FindMovie(string movieName)
        {
            for (int i = 0; i < _sizeMovie; i++)
            {
                if (_movies[i].Name == movieName)
                {
                    return _movies[i];
                }
            }
            return null;
        }

        public void SearchMovie()
        {
            Console.WriteLine("Enter movie name: ");
            string s = Console.ReadLine();
            Movie movie = FindMovie(s);
            if (movie != null)
            {
                PrintMovieById(movie.Id);

                return;
            }
            else
            {
                Console.WriteLine($"Movie {s} does not exist.");

                return;
            }
        }

        public void RemoveMovie()
        {
            PrintMovies();
            Console.WriteLine("Enter the movie name that you want to delete: ");
            string s = Console.ReadLine();
            var movie = FindMovie(s);
            if (movie != null)
            {
                for (int i = movie.Id; i < _sizeMovie - 1; i++)
                {
                    _movies[i] = _movies[i + 1];
                }
                _movies[_sizeMovie - 1] = default;
                _sizeMovie -= 1;
                Console.WriteLine($"Movie {movie.Name} was deleted!");
                PrintMovies();
            }
            else
            {
                Console.WriteLine($"Movie {s} does not exist!");

                return;
            }
        }

        public void WatchMovie()
        {
            PrintMovies();
            Console.WriteLine("Enter the movie name: ");
            string s = Console.ReadLine();
            var movie = FindMovie(s);
            if (movie != null)
            {
                movie.CountOfViews++;
                Console.WriteLine($"Watched movie {movie.Name}");

                return;
            }
            else
            {
                Console.WriteLine($"Movie {s} does not exist!");

                return;
            }
        }

        //public void MostViewMovie()
        //{
        //    int max = 0;
        //    int maxI = 0;
        //    for (int i = 0; i < _sizeMovie; i++)
        //    {
        //        if (_movies[i].CountOfViews > max)
        //        {
        //            max = _movies[i].CountOfViews;
        //            maxI = i;
        //        }
        //    }
        //    PrintMovieById(_movies[maxI].Id);
        //}
        public void MostViewedMovie()
        {
            Movie[] tmpMovies = new Movie[_sizeMovie];
            int index = 0;
            foreach (var item in _movies)
            {
                if (item != null)
                {
                    tmpMovies[index++] = item;
                }
            }
            for (int i = 0; i < index; i++)
            {
                for (int j = 0; j < index - 1 - i; j++)
                {
                    if (tmpMovies[j + 1].CountOfViews > tmpMovies[j].CountOfViews)
                    {
                        var tmp = tmpMovies[j + 1];
                        tmpMovies[j + 1] = tmpMovies[j];
                        tmpMovies[j] = tmp;
                    }
                }
            }
            Console.WriteLine($"{"Id",-4} {"Name",-20} {"Genre",-10} {"Imdb",-5} Count of views");
            for (int i = 0; i < tmpMovies.Length; i++)
            {
                if (tmpMovies[i] == null)
                    continue;

                Console.WriteLine(new string('-', 60));
                Console.WriteLine($"{tmpMovies[i].Id,-4} {tmpMovies[i].Name,-20} {tmpMovies[i].Genre.Name,-10} {tmpMovies[i].Imdb,-10} {tmpMovies[i].CountOfViews}");

            }
        }

        public void FilterMovieByGenre()
        {
            PrintGenres();
            Console.WriteLine("Enter genre: ");
            string s = Console.ReadLine();
            Genre genre = FindGenre(s);
            if (genre != null)
            {
                for (int i = 0; i < _sizeMovie; i++)
                {
                    if (_movies[i].Genre.Name == s)
                        PrintMovieById(_movies[i].Id);
                }

                return;
            }
            else
            {
                Console.WriteLine($"Genre {s} does not exist");
                return;
            }

        }
    }
}