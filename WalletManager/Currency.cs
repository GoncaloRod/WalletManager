using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletManager
{
    class Currency
    {
        #region Static Methods
        /// <summary>
        /// Returns all currencies in DB.
        /// </summary>
        /// <returns></returns>
        public static List<Currency> All()
        {
            List<Currency> currencies = new List<Currency>();

            DataTable currenciesDB = DB.Instance.ExecQuery("SELECT * FROM Currencies");

            for (int i = 0; i < currenciesDB.Rows.Count; i++)
            {
                currencies.Add(new Currency((int)currenciesDB.Rows[i][0], (string)currenciesDB.Rows[i][1], (string)currenciesDB.Rows[i][2]));
            }

            return currencies;
        }
        #endregion

        #region Instance Methods
        public int id { get; }
        public string code { get; }
        public string symbol { get; }

        /// <summary>
        /// Creates an instance of class Currecy
        /// </summary>
        /// <param name="_id">Currency's id</param>
        /// <param name="_code">Currency's code</param>
        /// <param name="_symbol">Currency's symbol</param>
        public Currency(int _id, string _code, string _symbol)
        {
            id = _id;
            code = _code;
            symbol = _symbol;
        }
        #endregion

        /// <summary>
        /// Returns currency ISO 4217 code
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return code;
        }
    }
}
