using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        public int currency_id { get; }

        public User(int _id, string _name, string _email, string _password, int _currency_id)
        {
            id = _id;
            name = _name;
            email = _email;
            password = _password;
            currency_id = _currency_id;
        }

        /// <summary>
        /// Add a wallet to user account
        /// </summary>
        /// <param name="name">Name of the wallet</param>
        /// <param name="startingBalance">Balance when the account is created</param>
        public void AddWallet(string name, decimal startingBalance)
        {
            // SQL command with paramenters
            string sql = "INSERT INTO Wallets(name, user_id, balance) VALUES(@name, @user_id, @balance)";

            // Parameters for SQL command
            List<SqlParameter> paramenters = new List<SqlParameter>
            {
                new SqlParameter(){ ParameterName = "@name", SqlDbType = SqlDbType.VarChar, Value = name },
                new SqlParameter(){ ParameterName = "@user_id", SqlDbType = SqlDbType.Int, Value = id},
                new SqlParameter(){ ParameterName = "balance", SqlDbType = SqlDbType.Money, Value = startingBalance }
            };

            // Execute command in DB
            DB.Instance.ExecSQL(sql, paramenters);
        }

        /// <summary>
        /// Returns sum of user's wallets balance.
        /// </summary>
        /// <returns></returns>
        public decimal TotalBalance()
        {
            // Check if user have wallets
            if ((int)DB.Instance.ExecQuery($"SELECT COUNT(*) FROM Wallets WHERE user_id = {id}").Rows[0][0] == 0) return 0;

            // Get sum of user's wallets balance
            return (decimal)DB.Instance.ExecQuery($"SELECT SUM(balance) FROM Wallets WHERE user_id = {id}").Rows[0][0];
        }

        public string GetUserCurrencySymbol()
        {
             return DB.Instance.ExecQuery($"SELECT symbol FROM Currencies WHERE id = {currency_id}").Rows[0][0].ToString();
        }
    }
}
