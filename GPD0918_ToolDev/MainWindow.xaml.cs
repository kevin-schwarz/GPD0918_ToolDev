using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public Game Game;

        public MainWindow()
        {
            // ein spiel faken
            Game = new Game();
            Game.Name = "WPF Game";
            Game.PatchNotes = "Lorem Ipsum";
            Game.TimePlayed = 0;
            Game.InstallLocation = "C:\\Program Files (x86)\\Internet Explorer\\iexplore.exe";

            // das ui vorbereiten
            InitializeComponent();

            // das ui mit dem spiel syncen
            lblName.Content = Game.Name;
            atxtPatchNotes.Text = Game.PatchNotes;
            lblTimePlayed.Content = (new TimeSpan(Game.TimePlayed)).ToString();

            btnStart.Content = Game.InstallLocation != null ? "Start" : "Install";
        }

        /// <summary>
        /// Der Event Handler der aufgerufen wird,
        /// wenn der Start Button gedrückt wird.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            if (Game.InstallLocation != null)
            {
                Process game = Process.Start(Game.InstallLocation);
            }
            else
            {
                // todo: install the game
            }
        }
    }
}
