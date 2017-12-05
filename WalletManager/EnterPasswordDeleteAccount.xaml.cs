using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WalletManager
{
    /// <summary>
    /// Interaction logic for EnterPasswordDeleteAccount.xaml
    /// </summary>
    public partial class EnterPasswordDeleteAccount : Window
    {
        public EnterPasswordDeleteAccount()
        {
            InitializeComponent();
        }

        private void btnDeleteClick(object sender, RoutedEventArgs e)
        {
            // Validate form
            if (txtPassword.Password == "")
            {
                MessageBox.Show("Please enter our password!");
            }

            // Variables to send to class
            string password = txtPassword.Password;

            // Delete account
            if (!Session.Instance.GetUser().DeleteAccount(password))
            {
                MessageBox.Show("Wrong password! Please try again!");
                return;
            }

            // Tell user that account was deleted with success
            MessageBox.Show("Account was deleted with successs! Application will now shutdown!");

            // Shutdown application
            Application.Current.Shutdown();
        }
    }
}
