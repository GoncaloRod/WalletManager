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

        private void UpdateForm()
        {
            tbName.Text = Session.Instance.GetUser().name;
        }
    }
}
