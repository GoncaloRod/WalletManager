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
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Window
    {
        public Account()
        {
            InitializeComponent();

            UpdateForm();
        }

        private void btnChangeNameClick(object sender, RoutedEventArgs e)
        {
            // Load change name window
            ChangeName changeName = new ChangeName();
            changeName.ShowDialog();

            if ((bool)changeName.DialogResult)
            {
                MessageBox.Show("Name updated with success!");
            }

            UpdateForm();
        }

        private void btnDeleteAccountClick(object sender, RoutedEventArgs e)
        {
            // Show confirmation message
            if (MessageBox.Show("Are ou sure you want to delete our account?", "Confirm Action", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                // Show enter password window
                EnterPasswordDeleteAccount enterPassword = new EnterPasswordDeleteAccount();
                enterPassword.ShowDialog();
            }
        }

        private void UpdateForm()
        {
            // Update text blocks
            tbName.Text = Session.Instance.GetUser().name;

            // Update DataGrids
            dgWallets.ItemsSource = Session.Instance.GetUser().GetAllWallets().DefaultView;
            dgExpensiesCategories.ItemsSource = Session.Instance.GetUser().GetAllExpensesCategories().DefaultView;
            dgSalariesCategories.ItemsSource = Session.Instance.GetUser().GetAllSalariesCategories().DefaultView;
        }
    }
}
