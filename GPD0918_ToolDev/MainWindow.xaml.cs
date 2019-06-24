using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace GPD0918_ToolDev
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Game> GameList
            = new ObservableCollection<Game>();

        public IGameSerializer GameSerializer
            = new XMLSeriaizer();

        public MainWindow()
        {
            // das ui vorbereiten
            InitializeComponent();

            foreach (string file in Directory.GetFiles("./games", "*.xml"))
            {
                GameList.Add(GameSerializer.Deserialize(file));
            }

            tbcGames.ItemsSource = GameList;
        }
    }
}
