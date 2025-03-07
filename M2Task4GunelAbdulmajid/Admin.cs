using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2Task4GunelAbdulmajid
{
    public class Admin
    {
        private int _autoIncrementedId = 0;
        public Admin(string name, string password, Role role)
        {
            Id=_autoIncrementedId++;
            Name=name;
            Password=password;
            Role = role;
        }
        public int Id {  get;}
        public string Name {  get;}
        public string Password {  get;}
        public Role Role { get;}
    }
}
