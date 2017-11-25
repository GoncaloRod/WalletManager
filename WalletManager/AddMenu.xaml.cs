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
    public partial class AddMenu : Window
    {
        public AddMenu()
        {
            InitializeComponent();
        }

        private void lnkAccountsClick(object sender, RoutedEventArgs e)
        {
            // Load add wallets window
            AddWallet addWallet = new AddWallet();
            addWallet.ShowDialog();
        }

        private void lnkExpensesClick(object sender, RoutedEventArgs e)
        {
            // Load add expenses window
            AddExpenses addExpenses = new AddExpenses();
            addExpenses.ShowDialog();
        }

        private void lnkSalariesClick(object sender, RoutedEventArgs e)
        {
            // Load add salaries window
            AddSalaries addSalaries = new AddSalaries();
            addSalaries.ShowDialog();
        }
    }
}
