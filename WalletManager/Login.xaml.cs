using System;
using System.Collections.Generic;
using System.Windows;
using System.Data.SqlClient;
using System.Data;

namespace WalletManager
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLoginClick(object sender, RoutedEventArgs e)
        {
            // Set up variables for to execute SQL command
            string email    = txtEmail.Text;
            string password = txtPassword.Password;

            // Validate form
            // Do things
            
            // SQL command with parameters
            string sql = "SELECT COUNT(*) FROM Users WHERE email = @email AND password = @password";
           
            // Parameters for SQL command
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter(){ ParameterName = "@email", SqlDbType = SqlDbType.VarChar, Value = email },
                new SqlParameter(){ ParameterName = "@password", SqlDbType = SqlDbType.VarChar, Value = password }
            };

            // Execute SQL command
            DataTable userCount = DB.Instance.ExecQuery(sql, parameters);

            // Check if login was made successfully
            if ((int)userCount.Rows[0][0] != 0)
            {
                // Load user page
            }
            else
            {
                // Tell user that creedentials are incorect
            }
        }

        private void btnRegisterClick(object sender, RoutedEventArgs e)
        {
            // Show register window
            Register windowRegister = new Register();
            windowRegister.ShowDialog();

            // Check if registration was completed with success
            if ((bool)windowRegister.DialogResult)
            {
                MessageBox.Show("Account created with success!");
            }
        }
    }
}
