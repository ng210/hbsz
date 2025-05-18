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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CardGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HostWindow _hostWindow = new HostWindow();
        ConnectWindow _connectWindow = new ConnectWindow();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FileMenu_Click(object sender, RoutedEventArgs e)
        {
            switch (((MenuItem)e.Source).Name)
            {
                case "Host":
                    _hostWindow.ShowDialog();
                    break;
                case "Connect":
                    _connectWindow.ShowDialog();
                    break;
                case "Exit":
                    Close();
                    break;
                default:
                    break;
            }
        }
    }
}
