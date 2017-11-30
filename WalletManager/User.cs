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
        #region Static Methods
        /// <summary>
        /// Returns all users in DB.
        /// </summary>
        /// <returns></returns>
        public static List<User> All()
        {
            List<User> users = new List<User>();

            DataTable usersDB = DB.Instance.ExecQuery("SELECT * FROM Users");

            for (int i = 0; i < usersDB.Rows.Count; i++)
            {
                users.Add(new User((int)usersDB.Rows[i][0], (string)usersDB.Rows[i][1], (string)usersDB.Rows[i][2], (string)usersDB.Rows[i][3], (int)usersDB.Rows[i][4]));
            }

            return users;
        }

        /// <summary>
        /// Creates new user in DB.
        /// </summary>
        /// <param name="_name">New user's name</param>
        /// <param name="_email">New user's email</param>
        /// <param name="_password">New user's password</param>
        /// <param name="_currency_id">New user's curreny id</param>
        /// <returns></returns>
        public static bool Create(string _name, string _email, string _password, int _currency_id)
        {
            // Check if email exists
            // Sql command
            string sql = "SELECT COUNT(*) FROM Users WHERE email = @email";

            // Parameters for Sql command
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter() { ParameterName = "@email", SqlDbType = SqlDbType.VarChar, Value = _email }
            };

            // Validate email
            if ((int)DB.Instance.ExecQuery(sql, parameters).Rows[0][0] > 0)
            {
                return false;
            }

            // Insert user in DB
            // Sql Command
            sql = "INSERT INTO Users(name, email, password, currency_id) VALUES(@name, @email, @password, @currency_id)";

            // Parameters for Sql Command
            parameters = new List<SqlParameter>
            {
                new SqlParameter() {ParameterName = "@name", SqlDbType = SqlDbType.VarChar, Value = _name },
                new SqlParameter() {ParameterName = "@email", SqlDbType = SqlDbType.VarChar, Value = _email },
                new SqlParameter() {ParameterName = "@password", SqlDbType = SqlDbType.VarChar, Value = _password },
                new SqlParameter() {ParameterName = "@currency_id", SqlDbType = SqlDbType.Int, Value = _currency_id }
            };

            // Execute command in DB
            DB.Instance.ExecSQL(sql, parameters);

            return true;
        }
        #endregion

        #region Instance Methods
        public int id { get; }
        public string name { get; }
        public string email { get; }
        public string password { get; }
        public int currency_id { get; }

        /// <summary>
        /// Initializes a instande of User.
        /// </summary>
        /// <param name="_id">User's id</param>
        /// <param name="_name">User's name</param>
        /// <param name="_email">User's email</param>
        /// <param name="_password">User's password</param>
        /// <param name="_currency_id">User's currency id</param>
        public User(int _id, string _name, string _email, string _password, int _currency_id)
        {
            id = _id;
            name = _name;
            email = _email;
            password = _password;
            currency_id = _currency_id;
        }

        /// <summary>
        /// Get all user's walletes
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllWallets()
        {
            // SQL command
            string sql = $"SELECT name AS 'Wallet Name', CONVERT(VARCHAR(100), CONVERT(DECIMAL(20, 2), balance)) + ' ' + (SELECT symbol FROM Currencies WHERE id = {currency_id}) AS 'Wallet Balance' FROM Wallets WHERE user_id = {id}";

            // Execute command in DB
            return DB.Instance.ExecQuery(sql);
        }

        /// <summary>
        /// Get all user's transactions
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllTransactions()
        {
            // SQL commdand
            string sql = $"SELECT Wallets.name AS 'Wallet', CONVERT(VARCHAR(100), CONVERT(DECIMAL(20, 2), value)) + ' ' + (SELECT symbol FROM Currencies WHERE id = {currency_id}) AS 'Value', CONVERT(VARCHAR(100), DATEPART(YYYY, Transactions.date)) + '/' + CONVERT(VARCHAR(100), DATEPART(MM, Transactions.date)) + '/' + CONVERT(VARCHAR(100), DATEPART(DD, Transactions.date)) AS 'Date' FROM Wallets, Transactions WHERE Wallets.user_id = {id} AND Transactions.wallet_id = Wallets.id";

            // Execute command in DB
            return DB.Instance.ExecQuery(sql);
        }

        /// <summary>
        /// Get all user's expensies
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllExpenses()
        {
            // SQL commdand
            string sql = $"SELECT Wallets.name AS 'Wallet', CONVERT(VARCHAR(100), CONVERT(DECIMAL(20, 2), value)) + ' ' + (SELECT symbol FROM Currencies WHERE id = {currency_id}) AS 'Value', CONVERT(VARCHAR(100), DATEPART(YYYY, Transactions.date)) + '/' + CONVERT(VARCHAR(100), DATEPART(MM, Transactions.date)) + '/' + CONVERT(VARCHAR(100), DATEPART(DD, Transactions.date)) AS 'Date', Expenses_Categories.name AS 'Category' FROM Wallets, Transactions, Expenses_Categories, Expenses WHERE Wallets.user_id = {id} AND Transactions.wallet_id = Wallets.id AND Expenses.transaction_id = Transactions.id AND Expenses.category_id = Expenses_Categories.id";

            // Execute command in DB
            return DB.Instance.ExecQuery(sql);
        }

        /// <summary>
        /// Get all user's expensies
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllSalaries()
        {
            // SQL commdand
            string sql = $"SELECT Wallets.name AS 'Wallet', CONVERT(VARCHAR(100), CONVERT(DECIMAL(20, 2), value)) + ' ' + (SELECT symbol FROM Currencies WHERE id = {currency_id}) AS 'Value', CONVERT(VARCHAR(100), DATEPART(YYYY, Transactions.date)) + '/' + CONVERT(VARCHAR(100), DATEPART(MM, Transactions.date)) + '/' + CONVERT(VARCHAR(100), DATEPART(DD, Transactions.date)) AS 'Date', Salaries_Categories.name AS 'Category' FROM Wallets, Transactions, Salaries_Categories, Salaries WHERE Wallets.user_id = {id} AND Transactions.wallet_id = Wallets.id AND Salaries.transaction_id = Transactions.id AND Salaries.category_id = Salaries_Categories.id";

            // Execute command in DB
            return DB.Instance.ExecQuery(sql);
        }

        /// <summary>
        /// Get all user's expenses categires
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllExpensesCategories()
        {
            // SQL command
            string sql = $"SELECT name AS 'Categorie Name' FROM Expenses_Categories WHERE user_id = {id}";

            // Execute command in DB
            return DB.Instance.ExecQuery(sql);
        }

        /// <summary>
        /// Get all user's salaries categires
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllSalariesCategories()
        {
            // SQL command
            string sql = $"SELECT name AS 'Categorie Name' FROM Salaries_Categories WHERE user_id = {id}";

            // Execute command in DB
            return DB.Instance.ExecQuery(sql);
        }

        /// <summary>
        /// Add a wallet to user account.
        /// </summary>
        /// <param name="_name">Name of the wallet</param>
        /// <param name="_startingBalance">Balance when the account is created</param>
        public void AddWallet(string _name, decimal _startingBalance)
        {
            // SQL command with paramenters
            string sql = "INSERT INTO Wallets(name, user_id, balance) VALUES(@name, @user_id, @balance)";

            // Parameters for SQL command
            List<SqlParameter> paramenters = new List<SqlParameter>
            {
                new SqlParameter(){ ParameterName = "@name", SqlDbType = SqlDbType.VarChar, Value = _name },
                new SqlParameter(){ ParameterName = "@user_id", SqlDbType = SqlDbType.Int, Value = id},
                new SqlParameter(){ ParameterName = "@balance", SqlDbType = SqlDbType.Money, Value = _startingBalance }
            };

            // Execute command in DB
            DB.Instance.ExecSQL(sql, paramenters);
        }
        
        /// <summary>
        /// Add a expense to users account
        /// </summary>
        /// <param name="_value">Expense's value</param>
        /// <param name="_date">Expense's date</param>
        /// <param name="_wallet">Expense's wallet</param>
        /// <param name="_category">Expense's category</param>
        public bool AddExpense(decimal _value, DateTime _date, Wallet _wallet, ExpenseCategory _category)
        {
            // Get starting wallet balance
            decimal balance = _wallet.GetBalance();

            // Start SQL transaction
            SqlTransaction transaction = DB.Instance.BegintTransaction();
            
            try
            {
                // -- Subtract value to wallet -- //
                // SQL command with paramenters
                string sql = "UPDATE Wallets SET balance = @balance WHERE id = @id";

                // Parameters for SQL command
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter(){ ParameterName = "@balance", SqlDbType = SqlDbType.Money, Value = balance - _value},
                    new SqlParameter(){ ParameterName = "@id", SqlDbType = SqlDbType.Int, Value = _wallet.id}
                };

                // Execute SQL command in DB
                DB.Instance.ExecSQL(sql, parameters, transaction);

                // -- Create transaction -- //
                // SQL command with paramenters
                sql = "INSERT INTO Transactions(value, date, wallet_id) VALUES(@value, @date, @wallet_id)";

                // Paramerters for SQL command
                parameters = new List<SqlParameter>
                {
                    new SqlParameter(){ ParameterName = "@value", SqlDbType = SqlDbType.Money, Value = -_value},
                    new SqlParameter(){ ParameterName = "@date", SqlDbType = SqlDbType.Date, Value = _date},
                    new SqlParameter(){ ParameterName = "@wallet_id", SqlDbType = SqlDbType.Int, Value = _wallet.id}
                };

                // Execute SQL command in DB
                DB.Instance.ExecSQL(sql, parameters, transaction);

                // -- Create expense -- //
                // Get transaction id
                sql = "SELECT MAX(id) FROM Transactions";

                int transactionId = (int)DB.Instance.ExecQuery(sql, transaction).Rows[0][0];

                // SQl command with parameters
                sql = "INSERT INTO Expenses(category_id, transaction_id) VALUES(@category_id, @transaction_id)";

                // Parameters for SQL command
                parameters = new List<SqlParameter>()
                {
                    new SqlParameter(){ ParameterName = "@category_id", SqlDbType = SqlDbType.Int, Value = _category.id},
                    new SqlParameter(){ ParameterName = "@transaction_id", SqlDbType = SqlDbType.Int, Value = transactionId}
                };

                // Execute SQL command in DB
                DB.Instance.ExecSQL(sql, parameters, transaction);

                // Commit transaction
                transaction.Commit();

                return true;
            }
            catch (Exception)
            {
                // Rollback transaction
                transaction.Rollback();

                return false;
            }
        }

        /// <summary>
        /// Add a salary to users account
        /// </summary>
        /// <param name="_value">Expense's value</param>
        /// <param name="_date">Expense's date</param>
        /// <param name="_wallet">Expense's wallet</param>
        /// <param name="_category">Expense's category</param>
        public bool AddSalary(decimal _value, DateTime _date, Wallet _wallet, SalaryCategory _category)
        {
            // Get starting wallet balance
            decimal balance = _wallet.GetBalance();

            // Start SQL transaction
            SqlTransaction transaction = DB.Instance.BegintTransaction();

            try
            {
                // -- Add value to wallet -- //
                // SQL command with paramenters
                string sql = "UPDATE Wallets SET balance = @balance WHERE id = @id";

                // Parameters for SQL command
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter(){ ParameterName = "@balance", SqlDbType = SqlDbType.Money, Value = balance + _value},
                    new SqlParameter(){ ParameterName = "@id", SqlDbType = SqlDbType.Int, Value = _wallet.id}
                };

                // Execute SQL command in DB
                DB.Instance.ExecSQL(sql, parameters, transaction);

                // -- Create transaction -- //
                // SQL command with paramenters
                sql = "INSERT INTO Transactions(value, date, wallet_id) VALUES(@value, @date, @wallet_id)";

                // Paramerters for SQL command
                parameters = new List<SqlParameter>
                {
                    new SqlParameter(){ ParameterName = "@value", SqlDbType = SqlDbType.Money, Value = _value},
                    new SqlParameter(){ ParameterName = "@date", SqlDbType = SqlDbType.Date, Value = _date},
                    new SqlParameter(){ ParameterName = "@wallet_id", SqlDbType = SqlDbType.Int, Value = _wallet.id}
                };

                // Execute SQL command in DB
                DB.Instance.ExecSQL(sql, parameters, transaction);

                // -- Create salary -- // 
                // Get transaction id
                sql = "SELECT MAX(id) FROM Transactions";

                int transactionId = (int)DB.Instance.ExecQuery(sql, transaction).Rows[0][0];

                // SQl command with parameters
                sql = "INSERT INTO Salaries(category_id, transaction_id) VALUES(@category_id, @transaction_id)";

                // Parameters for SQL command
                parameters = new List<SqlParameter>()
                {
                    new SqlParameter(){ ParameterName = "@category_id", SqlDbType = SqlDbType.Int, Value = _category.id},
                    new SqlParameter(){ ParameterName = "@transaction_id", SqlDbType = SqlDbType.Int, Value = transactionId}
                };

                // Execute SQL command in DB
                DB.Instance.ExecSQL(sql, parameters, transaction);

                // Commit transaction
                transaction.Commit();

                return true;
            }
            catch (Exception)
            {
                // Rollback transaction
                transaction.Rollback();

                return false;
            }
        }

        /// <summary>
        /// Add a Expense Category to user account.
        /// </summary>
        /// <param name="_name">Category name</param>
        public void AddExpenseCategory(string _name)
        {
            // SQL Command with paramenters
            string sql = "INSERT INTO Expenses_Categories(name, user_id) VAlUES(@name, @user_id)";

            // Paramenters for SQL command
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter(){ParameterName = "@name", SqlDbType = SqlDbType.VarChar, Value = _name},
                new SqlParameter(){ ParameterName = "@user_id", SqlDbType = SqlDbType.Int, Value = id},
            };

            // Execute command in DB
            DB.Instance.ExecSQL(sql, parameters);
        }

        /// <summary>
        /// Add a Salary Category to user account.
        /// </summary>
        /// <param name="_name">Categoty name</param>
        public void AddSalaryCategory(string _name)
        {
            // SQL Command with paramenters
            string sql = "INSERT INTO Salaries_Categories(name, user_id) VAlUES(@name, @user_id)";

            // Paramenters for SQL command
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter(){ParameterName = "@name", SqlDbType = SqlDbType.VarChar, Value = _name},
                new SqlParameter(){ ParameterName = "@user_id", SqlDbType = SqlDbType.Int, Value = id},
            };

            // Execute command in DB
            DB.Instance.ExecSQL(sql, parameters);
        }

        /// <summary>
        /// Change user's name
        /// </summary>
        /// <param name="_newName">New name</param>
        /// <param name="_password">User's password</param>
        /// <returns></returns>
        public bool ChangeName(string _newName, string _password)
        {
            if (_password != password) return false;

            // SQL command
            string sql = "UPDATE Users SET name = @name WHERE id = @id";

            // Paramenters for SQL command
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter(){ ParameterName = "@name", SqlDbType = SqlDbType.VarChar, Value = _newName},
                new SqlParameter(){ ParameterName = "@id", SqlDbType = SqlDbType.Int, Value = id }
            };

            // Execute command in DB
            DB.Instance.ExecSQL(sql, parameters);

            // Update session
            Session.Instance.LogOut();
            Session.Instance.Attempt(email, password);

            return true;
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

        /// <summary>
        /// Returns user's currency symbol.
        /// </summary>
        /// <returns></returns>
        public string GetUserCurrencySymbol()
        {
            return DB.Instance.ExecQuery($"SELECT symbol FROM Currencies WHERE id = {currency_id}").Rows[0][0].ToString();
        }
        #endregion

        /// <summary>
        /// Return user's email.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return email;
        }
    }
}
