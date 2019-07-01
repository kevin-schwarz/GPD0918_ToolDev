using System;
using System.Collections.Generic;
using System.IO;
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

using IOPath = System.IO.Path;

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

        private void OnRemoveButtonClicked(object sender, RoutedEventArgs e)
        {
            // das ausgewählte game aus der liste entfernen
            Game toRemove = lstGames.SelectedItem as Game;
            ((App)App.Current).GameList.Remove(toRemove);

            // die ausgewählte game datei löschen
            if(File.Exists(IOPath.Combine("./games", toRemove.FileName)))
            {
                File.Delete(IOPath.Combine("./games", toRemove.FileName));
            }
        }
    }
}



// nach einer änderung
// intervall
// # beim schliessen 
// strg-s
// button
