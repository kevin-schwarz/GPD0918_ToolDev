using Microsoft.Win32;
using System;
using System.ComponentModel;
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
                //Game.InstallLocation = "";

                OpenFileDialog dialog = new OpenFileDialog();
                // SaveFileDialog dialog = new SaveFileDialog();
                // dialog.Multiselect = true;
                dialog.InitialDirectory = System.IO.Path.GetFullPath("./games");
                dialog.Filter = "Alle Dateien|*|XML Dateien|*.xml|Text Dateien|*.txt";
                dialog.FilterIndex = 2;

                bool? result = dialog.ShowDialog();

                // true => Eine oder mehrere Dateien wurden ausgewählt
                // false => Cancel wurde gedrückt
                // null => Wurde das Fenster geschlossen
                if (!result.HasValue || !result.Value) return;

                // Ausgewählte Datei => dialog.FileName
            }
            else
            {
                if (installationWorker != null) return;

                installationWorker = new BackgroundWorker();
                installationWorker.WorkerReportsProgress = true;
                installationWorker.DoWork += InstallGame;
                installationWorker.ProgressChanged += ReportInstallationProgress;
                installationWorker.RunWorkerCompleted += FinishInstallation;
                installationWorker.RunWorkerAsync();
            }
        }

        private BackgroundWorker installationWorker;

        private void InstallGame(object sender, DoWorkEventArgs e)
        {
            // todo: install the game
            DateTime finished = DateTime.Now + TimeSpan.FromSeconds(3);
            while(DateTime.Now < finished)
            {
                float progress = 
                    100.0f - 100.0f * (finished - DateTime.Now).Ticks / TimeSpan.FromSeconds(3).Ticks;

                installationWorker.ReportProgress((int)progress);

                Thread.Sleep(100);
            }
        }
        
        private void ReportInstallationProgress(object sender, ProgressChangedEventArgs e)
        {
            pbrInstallation.Value = e.ProgressPercentage;
        }

        private void FinishInstallation(object sender, RunWorkerCompletedEventArgs e)
        {
            pbrInstallation.Value = 0;
            Game.InstallLocation = "Irgendwo";
            installationWorker = null;
        }

    }
}
