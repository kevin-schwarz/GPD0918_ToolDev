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

namespace GPD0918_ToolDev
{
    /// <summary>
    /// Interaktionslogik für AdminView.xaml
    /// </summary>
    public partial class AdminView : UserControl
    {

        public static DependencyProperty gameProperty =
           DependencyProperty.Register("Current", typeof(Game), typeof(AdminView));

        /// <summary>
        /// Das Spiel, das von dieser Seite angezeigt wird.
        /// </summary>
        public Game Current
        {
            get
            {
                return GetValue(gameProperty) as Game;
            }

            set
            {
                SetValue(gameProperty, value);
            }
        }

        public AdminView()
        {
            InitializeComponent();

            lstGames.ItemsSource = ((App)App.Current).GameList;
        }

        private void OnGameSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Current = lstGames.SelectedItem as Game;
        }

        private void OnAddGameButtonClicked(object sender, RoutedEventArgs e)
        {
            ((App)App.Current).GameList.Add(new Game());
        }
    }
}
