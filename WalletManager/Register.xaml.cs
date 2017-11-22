using System;
using System.Collections.Generic;
using System.Windows;
using System.Data.SqlClient;
using System.Data;

namespace WalletManager
{
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegisterClick(object sender, RoutedEventArgs e)
        {
            // Setup variables to execute SQL command
            string name = txtName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Password;
            string passwordConfirmation = txtPasswordConfirmation.Password;

            // Validate form
            // Do things

            // SQL command with parameters
            string sql = "SELECT COUNT(*) FROM Users WHERE email = @email";

            // Parameters for SQL command
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter() { ParameterName = "@email", SqlDbType = SqlDbType.VarChar, Value = email }
            };

            // Execute SQL command
            DataTable userCount = DB.Instance.ExecQuery(sql, parameters);

            // Clear variables
            sql = null;
            parameters = null;

            // Check if the email doesn't exist
            if ((int)userCount.Rows[0][0] != 0)
            {
                // Do things
                return;
            }

            // Insert user to DB
            // SQL command with parameters
            sql = "INSERT INTO Users(name, email, password, balance) VALUES(@name, @email, @password, @balance)";

            // Parameters for SQL command
            parameters = new List<SqlParameter>
            {
                new SqlParameter() {ParameterName = "@name", SqlDbType = SqlDbType.VarChar, Value = name },
                new SqlParameter() {ParameterName = "@email", SqlDbType = SqlDbType.VarChar, Value = email },
                new SqlParameter() {ParameterName = "@password", SqlDbType = SqlDbType.VarChar, Value = password },
                new SqlParameter() {ParameterName = "@balance", SqlDbType = SqlDbType.Money, Value = 0 }
            };

            // Execute SQL command
            DB.Instance.ExecSQL(sql, parameters);

            // Close window
            DialogResult = true;
            Close();
        }
    }
}
