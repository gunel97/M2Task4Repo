using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2Task4GunelAbdulmajid
{
    public class WatchList
    {
        public WatchList(Movie movie, User user)
        {
            Movie = movie;
            User = user;
        }
        public Movie Movie { get; set; }
        public User User { get; }
    }
}
