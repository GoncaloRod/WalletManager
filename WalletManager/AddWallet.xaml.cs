using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class AddWallet : Window
    {
        public AddWallet()
        {
            InitializeComponent();
        }

        private void startingBalancePreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void btnAddClick(object sender, RoutedEventArgs e)
        {
            // Validate form
            if (txtWalletName.Text == "" || txtStartingBalance.Text == "")
            {
                MessageBox.Show("Both fields cannot be empty!");
                return;
            }

            // Variables to send to class
            string name = txtWalletName.Text;
            decimal balance = Convert.ToDecimal(txtStartingBalance.Text);

            // Create wallet in user's account
            Session.Instance.GetUser().AddWallet(name, balance);

            // Close window
            DialogResult = true;
            Close();
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+");
            return !regex.IsMatch(text);
        }
    }
}
