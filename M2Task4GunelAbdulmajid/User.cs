using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2Task4GunelAbdulmajid
{
    public class User
    {
        private static int _autoIncrementedId = 0;
        public User(string username, string password, Role role)
        {
            UserName = username;
            Password = password;
            Role = role;
            Id = _autoIncrementedId++;
        }
        public int Id { get; }
        public string UserName { get; }
        public string Password { get; }
        public Role Role { get; }
    }
}
