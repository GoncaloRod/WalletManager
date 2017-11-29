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
    /// Interaction logic for ChangeName.xaml
    /// </summary>
    public partial class ChangeName : Window
    {
        public ChangeName()
        {
            InitializeComponent();
        }

        private void btnChangeNameClick(object sender, RoutedEventArgs e)
        {
            // Validate form
            if (txtNewName.Text == "" || txtPassword.Password == "")
            {
                MessageBox.Show("Both fields cannot be empty!");
                return;
            }

            // Variables to send to class
            string newName = txtNewName.Text;
            string password = txtPassword.Password;

            // Change name
            if (!Session.Instance.GetUser().ChangeName(newName, password))
            {
                MessageBox.Show("Wrong password! Please try again!");
                return;
            }

            // Close window
            DialogResult = true;
            Close();
        }
    }
}
