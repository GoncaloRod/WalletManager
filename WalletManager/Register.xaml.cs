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
            UpdateForm();
        }

        private void btnRegisterClick(object sender, RoutedEventArgs e)
        {
            // Validate form
            // Check if all inputs are filed
            if (txtName.Text == "" || txtEmail.Text == "" || txtPassword.Password == "" || txtPasswordConfirmation.Password == "" || cmbCurrency.SelectedIndex < 0)
            {
                MessageBox.Show("All field need to be filed!");
                return;
            }

            // Check if emails is valid
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email!");
                return;
            }

            // Check if passwords match
            if (txtPassword.Password != txtPasswordConfirmation.Password)
            {
                MessageBox.Show("Passwords does not match!");
                return;
            }

            // Setup variables to execute SQL command
            string name = txtName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Password;
            string passwordConfirmation = txtPasswordConfirmation.Password;
            int currencyId = ((Currency)(cmbCurrency.SelectedItem)).id;

            // Create user in DB
            if (!User.Create(name, email, password, currencyId))
            {
                MessageBox.Show("This email is already in use!");
                return;
            }

            // Close window
            DialogResult = true;
            Close();
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public void UpdateForm()
        {
            // Update currencies Combo Box
            foreach (var item in Currency.All())
            {
                cmbCurrency.Items.Add(item);
            }
        }
    }
}
