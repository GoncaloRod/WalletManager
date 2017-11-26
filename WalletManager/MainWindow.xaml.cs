using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Initialize vizual elements
            InitializeComponent();

            // Populate vizual elements
            tbName.Text = Session.Instance.GetUser().name;
            tbBalance.Text = $"Total Balance: {Session.Instance.GetUser().TotalBalance():F2} {Session.Instance.GetUser().GetUserCurrencySymbol()}";
        }

        private void btnAddClick(object sender, RoutedEventArgs e)
        {
            // Load add menu window
            AddMenu addMenu = new AddMenu();
            addMenu.ShowDialog();
        }
    }
}
