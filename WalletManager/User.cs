using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletManager
{
    class User
    {
        public int id { get; }
        public string name { get; }
        public string email { get; }
        public string password { get; }
        public decimal balance { get; }

        public User(int _id, string _name, string _email, string _password, decimal _balance)
        {
            id = _id;
            name = _name;
            email = _email;
            password = _password;
            balance = _balance;
        }
    }
}
