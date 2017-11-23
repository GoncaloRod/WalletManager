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
        DataTable user;

        public MainWindow(DataTable _user)
        {
            user = _user;
            InitializeComponent();
        }
    }
}
