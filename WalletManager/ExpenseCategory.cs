using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletManager
{
    class ExpenseCategory
    {
        #region Static Methods
        /// <summary>
        /// Returns all user's expense categories
        /// </summary>
        /// <returns></returns>
        public static List<ExpenseCategory> All()
        {
            List<ExpenseCategory> categories = new List<ExpenseCategory>();

            DataTable categoriesDB = DB.Instance.ExecQuery($"SELECT * FROM Expenses_Categories WHERE user_id = {Session.Instance.GetUser().id}");

            for (int i = 0; i < categoriesDB.Rows.Count; i++)
            {
                categories.Add(new ExpenseCategory((int)categoriesDB.Rows[i][0], (string)categoriesDB.Rows[i][1], (int)categoriesDB.Rows[i][2]));
            }

            return categories;
        }
        #endregion

        #region Instance Methods
        public int id { get; }
        public string name { get; }
        public int user_id { get; }

        /// <summary>
        /// Creates an instance of class ExpenseCategory
        /// </summary>
        /// <param name="_id">Category id</param>
        /// <param name="_name">Category name</param>
        /// <param name="_user_id">Category user id</param>
        public ExpenseCategory(int _id, string _name, int _user_id)
        {
            id = _id;
            name = _name;
            user_id = _user_id;
        }
        #endregion

        /// <summary>
        /// Returns category name
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name;
        }
    }
}
