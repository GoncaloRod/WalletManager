using System;
using System.Collections.Generic;
using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace WalletManager
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            // CHeck if DB path is created
            if (!Directory.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\WalletManager")) Directory.CreateDirectory($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\WalletManager");
            // Check if DB is created
            if (!File.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\WalletManager\WalletManager.mdf")) DB.Instance.CreateFromFile($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\WalletManager\WalletManager.mdf", @".\..\..\create_tables.sql");
        }

        private void btnLoginClick(object sender, RoutedEventArgs e)
        {
            // Set up variables for to execute SQL command
            string email = txtEmail.Text;
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

            // Clear variables
            sql = null;
            parameters = null;

            // Check if login was made successfully
            if ((int)userCount.Rows[0][0] != 0)
            {
                // Get user from DB
                // SQL command with paramenters
                sql = "SELECT * From Users WHERE email = @email";

                // Parameters for SQL command
                parameters = new List<SqlParameter>
                {
                    new SqlParameter(){ ParameterName = "@email", SqlDbType = SqlDbType.VarChar, Value = email },
                };

                DataTable user = DB.Instance.ExecQuery(sql, parameters);

                // Load user page
                MainWindow mainWindow = new MainWindow(user);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                // Tell user that creedentials are incorect
                MessageBox.Show("Email and password does not match!");          // TODO: Custom message window
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
                // Tell user that account was created with success
                MessageBox.Show("Account created with success!");               // TODO: Custom message window
            }
        }
    }
}
