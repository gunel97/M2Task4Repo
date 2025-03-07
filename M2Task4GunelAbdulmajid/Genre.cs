using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2Task4GunelAbdulmajid
{
    public class Genre
    {
        private static int _autoIncrementedId = 0;
        public Genre(string name)
        {
            Name = name;
            Id=_autoIncrementedId++;
        }
        public string Name { get; set; }
        public int Id { get; }
        

    }
}
