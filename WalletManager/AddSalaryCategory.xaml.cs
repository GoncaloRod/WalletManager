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
    public partial class AddSalaryCategory : Window
    {
        public AddSalaryCategory()
        {
            InitializeComponent();
        }

        private void btnAddClick(object sender, RoutedEventArgs e)
        {
            // Validate Form
            if (txtName.Text == "")
            {
                MessageBox.Show("Fields cannot be empty!");
                return;
            }

            // Variable to send to class
            string name = txtName.Text;

            // Create category in user's account
            Session.Instance.GetUser().AddSalaryCategory(name);

            // Close window
            DialogResult = true;
            Close();
        }
    }
}
