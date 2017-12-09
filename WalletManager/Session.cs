using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WalletManager
{
    class Session
    {
        private static Session instance;

        public static Session Instance
        {
            get
            {
                if (instance == null) instance = new Session();

                return instance;
            }
        }

        private User user;

        /// <summary>
        /// Attempt to login. If credentials are correct return true, if not reutrn false.
        /// </summary>
        /// <param name="email">User's email</param>
        /// <param name="password">User's password</param>
        public bool Attempt(string email, string password)
        {
            // SQL command with parameters
            string sql = "SELECT * FROM Users WHERE email LIKE @email AND password LIKE @password";
            // Parameters for SQL command
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter(){ ParameterName = "@email", SqlDbType = SqlDbType.VarChar, Value = email},
                new SqlParameter(){ ParameterName = "@password", SqlDbType = SqlDbType.VarChar, Value = password}
            };

            DataTable userDB = DB.Instance.ExecQuery(sql, parameters);

            if (userDB.Rows.Count != 0)
            {
                user = new User((int)userDB.Rows[0][0], (string)userDB.Rows[0][1], (string)userDB.Rows[0][2], (string)userDB.Rows[0][3], (int)userDB.Rows[0][4]);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns logged user. If user is not logged return null.
        /// </summary>
        /// <returns></returns>
        public User GetUser()
        {
            return user;
        }

        /// <summary>
        /// Destroys session.
        /// </summary>
        public void LogOut()
        {
            user = null;
        }
    }
}
