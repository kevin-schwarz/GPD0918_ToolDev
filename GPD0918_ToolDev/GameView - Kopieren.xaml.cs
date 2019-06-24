using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace GPD0918_ToolDev
{
    /// <summary>
    /// Interaktionslogik für GameView.xaml
    /// </summary>
    public partial class GameViewOld : UserControl
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

        public GameViewOld()
        {
            InitializeComponent();

            updateTimer = new DispatcherTimer();
            updateTimer.Interval = TimeSpan.FromMilliseconds(200);
            updateTimer.Tick += Update;
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
                if (updateTimer.IsEnabled) return;
                updateTimer.Start();

                progress = 0.0f;
                (new Thread(InstallGame)).Start();
            }
        }

        private void Update(object sender, EventArgs e)
        {
            pbrInstallation.Value = progress;

            if (progress < 1.0f) return;

            Game.InstallLocation = "Irgendwo";
            updateTimer.Stop();
        }

        private DispatcherTimer updateTimer;

        private float progress = 0.0f;

        private void InstallGame()
        {
            // todo: install the game
            DateTime finished = DateTime.Now + TimeSpan.FromSeconds(3);
            while(DateTime.Now < finished)
            {
                progress = 1.0f - 1.0f * (finished - DateTime.Now).Ticks / TimeSpan.FromSeconds(3).Ticks;

                Thread.Sleep(100);
            }

            progress = 1.0f;
            //Game.InstallLocation = "Irgendwo";
        }

    }
}
