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
    public partial class AddExpenses : Window
    {
        public AddExpenses()
        {
            InitializeComponent();
            UpdateForm();
        }

        private void valuePreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void newWalletClick(object sender, RoutedEventArgs e)
        {
            // Load add wallets window
            AddWallet addWallet = new AddWallet();
            addWallet.ShowDialog();

            // Check if operation was completed with success
            if ((bool)addWallet.DialogResult)
            {
                MessageBox.Show("Wallet added with success!");
            }

            // Update Form
            UpdateForm();
        }

        private void newCategoryClick(object sender, RoutedEventArgs e)
        {
            AddExpenseCategory addExpenseCategory = new AddExpenseCategory();
            addExpenseCategory.ShowDialog();

            if ((bool)addExpenseCategory.DialogResult)
            {
                MessageBox.Show("Category added with success!");
            }

            // Update Form
            UpdateForm();
        }

        private void btnAddClick(object sender, RoutedEventArgs e)
        {
            // Validate Form
            if (txtValue.Text == "" || !dtpDate.SelectedDate.HasValue || cmbWallet.SelectedIndex < 0 || cmbCategory.SelectedIndex < 0)
            {
                MessageBox.Show("All field need to be filed!");
                return;
            }

            // Variables to send to class
            decimal value = Convert.ToDecimal(txtValue.Text);
            DateTime date = new DateTime(dtpDate.SelectedDate.Value.Year, dtpDate.SelectedDate.Value.Month, dtpDate.SelectedDate.Value.Day);
            Wallet wallet = (Wallet)cmbWallet.SelectedItem;
            ExpenseCategory category = (ExpenseCategory)cmbCategory.SelectedItem;

            // Add expense to user's account
            if (Session.Instance.GetUser().AddExpense(value, date, wallet, category))
            {
                // Close Window
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("An error ocurred while inserting expense! Please try again.");
            }
        }

        private bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+");
            return !regex.IsMatch(text);
        }

        private void UpdateForm()
        {
            // Clear Combo Boxes
            cmbWallet.Items.Clear();
            cmbCategory.Items.Clear();

            // Update Wallets Combo Box
            foreach(var item in Wallet.All())
            {
                cmbWallet.Items.Add(item);
            }

            // Update Categories Comobo Box
            foreach (var item in ExpenseCategory.All())
            {
                cmbCategory.Items.Add(item);
            }
        }
    }
}
