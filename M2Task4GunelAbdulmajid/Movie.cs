using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2Task4GunelAbdulmajid
{
    public class Movie
    {
        private static int _autoIncrementedId = 0;
        public Movie(string name, Genre genre, double imdb)
        {
            Name = name;
            Genre = genre;
            Imdb = imdb;
            Id = _autoIncrementedId++;
            CountOfViews = 0;
        }
        public int Id { get; }
        public string Name {  get; set; }
        public Genre  Genre { get; set; }
        public int CountOfViews { get; set; }
        public double Imdb {  get; set; }
        
        
    }
}
