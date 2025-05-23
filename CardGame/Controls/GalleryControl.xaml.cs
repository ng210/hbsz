using CardGame.Model;
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

namespace CardGame.Controls
{
    /// <summary>
    /// Interaction logic for GalleryControl.xaml
    /// </summary>
    public partial class GalleryControl : UserControl
    {
        private int _currentIndex = 0;

        private List<Card> Cards
        {
            get => (List<Card>)DataContext;
            set {
                DataContext = value;
                Card.DataContext = Cards[_currentIndex];
            }
        }

        public GalleryControl()
        {
            InitializeComponent();
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (_currentIndex > 0) _currentIndex--;
            Card.DataContext = Cards[_currentIndex];
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (_currentIndex < Cards.Count-1) _currentIndex++;
            Card.DataContext = Cards[_currentIndex];
        }
    }
}
