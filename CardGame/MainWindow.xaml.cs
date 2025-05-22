using CardGame.Controls;
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
        Dictionary<string, Control> _controls;
        public MainWindow()
        {
            InitializeComponent();

            _controls = new Dictionary<string, Control>
            {
                { "Main", new MainView() },
                { "Host", new HostControl() },
                { "Connect", new ConnectControl() },
                { "Gallery", new GalleryControl() }
            };
        }

        private void FileMenu_Click(object sender, RoutedEventArgs e)
        {
            switch (((MenuItem)e.Source).Name)
            {
                case "Host":
                    MainContent.Content = _controls["Host"];
                    break;
                case "Connect":
                    MainContent.Content = _controls["Connect"];
                    break;
                case "Exit":
                    Close();
                    break;
                default:
                    break;
            }
        }

        private void GalleryMenu_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = _controls["Gallery"];
        }
    }
}
