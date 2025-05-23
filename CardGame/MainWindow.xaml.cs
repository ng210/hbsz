using CardGame.Controls;
using CardGame.DbAccess;
using CardGame.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        List<Card> _cardList;

        private void ReadDataBase()
        {
            var connectionString = string.Empty;
            foreach (ConnectionStringSettings cs in ConfigurationManager.ConnectionStrings)
            {
                if (cs.Name == "LolCards") connectionString = cs.ConnectionString;
            }

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                _cardList = new DbCard(connection).Get();
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                ReadDataBase();
                var galleryControl = new GalleryControl();
                galleryControl.DataContext = _cardList;

                _controls = new Dictionary<string, Control>
                {
                    { "Main", new MainView() },
                    { "Host", new HostControl() },
                    { "Connect", new ConnectControl() },
                    { "Gallery", galleryControl }
                };
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButton.OK);
                Close();
            }
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
