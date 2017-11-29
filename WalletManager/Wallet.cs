using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletManager
{
    class Wallet
    {
        #region Static Methods
        /// <summary>
        /// Returns all user's wallets
        /// </summary>
        /// <returns></returns>
        public static List<Wallet> All()
        {
            List<Wallet> wallets = new List<Wallet>();

            DataTable walletsDB = DB.Instance.ExecQuery($"SELECT * FROM Wallets WHERE user_id = {Session.Instance.GetUser().id}");

            for (int i = 0; i < walletsDB.Rows.Count; i++)
            {
                wallets.Add(new Wallet((int)walletsDB.Rows[i][0], (string)walletsDB.Rows[i][1], (int)walletsDB.Rows[i][2], (decimal)walletsDB.Rows[i][3]));
            }

            return wallets;
        }
        #endregion

        #region Instance Methods
        public int id { get; }
        public string name { get; }
        public int user_id { get; }
        public decimal balabce { get; }

        /// <summary>
        /// Creates an instance of class Wallet
        /// </summary>
        /// <param name="_id">Wallet's id</param>
        /// <param name="_name">Wallet's name</param>
        /// <param name="_user_id">Wallet's user id</param>
        /// <param name="_balance">Wallet's balance</param>
        public Wallet(int _id, string _name, int _user_id, decimal _balance)
        {
            id = _id;
            name = _name;
            user_id = _user_id;
            balabce = _balance;
        }

        public decimal GetBalance()
        {
            // SQL command
            string sql = $"SELECT balance FROM Wallets WHERE id = {id}";

            // Execute command in DB
            return (Convert.ToDecimal(DB.Instance.ExecQuery(sql).Rows[0][0]));
        }
        #endregion

        /// <summary>
        /// Returns wallet's name.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name;
        }
    }
}
