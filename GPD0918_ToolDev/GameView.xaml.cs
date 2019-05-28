using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace GPD0918_ToolDev
{
    /// <summary>
    /// Interaktionslogik für GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {

        public Game Game;

        public GameView()
        {
            InitializeComponent();
        }

        public void Sync()
        {
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
