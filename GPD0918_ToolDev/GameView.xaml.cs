using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace GPD0918_ToolDev
{
    /// <summary>
    /// Interaktionslogik für GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {

        public static DependencyProperty gameProperty =
            DependencyProperty.Register("Game", typeof(Game), typeof(GameView));

        /// <summary>
        /// Das Spiel, das von dieser Seite angezeigt wird.
        /// </summary>
        public Game Game
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

        public GameView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Der Event Handler der aufgerufen wird,
        /// wenn der Start Button gedrückt wird.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            if (Game.InstallLocation != null && Game.InstallLocation.Length > 0)
            {
                //Process game = Process.Start(Game.InstallLocation);
                Game.InstallLocation = "";
            }
            else
            {
                (new Thread(InstallGame)).Start();
            }
        }

        private void InstallGame()
        {
            // todo: install the game
            Thread.Sleep(3000);
            Game.InstallLocation = "Irgendwo";
        }

    }
}
