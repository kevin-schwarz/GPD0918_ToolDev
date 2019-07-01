using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace GPD0918_ToolDev
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {

        public IGameSerializer GameSerializer
            = new XMLSeriaizer();

        public ObservableCollection<Game> GameList
            = new ObservableCollection<Game>();

        private DispatcherTimer autoSaveTimer;

        private BackgroundWorker saveWorker;

        protected override void OnStartup(StartupEventArgs e)
        {
            foreach (string file in Directory.GetFiles("./games", "*.xml"))
            {
                GameList.Add(GameSerializer.Deserialize(file));
            }

            base.OnStartup(e);

            autoSaveTimer = new DispatcherTimer();
            autoSaveTimer.Interval = TimeSpan.FromSeconds(10);
            autoSaveTimer.Tick += AutoSaveTimer_Tick;
            //autoSaveTimer.Start();
        }

        private void AutoSaveTimer_Tick(object sender, EventArgs e)
        {
            SaveAll();
        }

        private void OnExit(object sender, ExitEventArgs e)
        {
            autoSaveTimer.Stop();
            SaveAll();
        }

        public void SaveAll()
        {
            if (saveWorker != null) return;

            SaveDialogWIndow window = new SaveDialogWIndow();
            window.FilesToSave = GameList.Count;
            window.Show();

            saveWorker = new BackgroundWorker();
            saveWorker.WorkerReportsProgress = true;
            saveWorker.DoWork += (object sender, DoWorkEventArgs e) => 
            {
                
                int i = 0;
                foreach (Game game in GameList)
                {
                    string path = Path.Combine("./games", game.FileName);

                    if (File.Exists(path))
                        File.Delete(path);

                    GameSerializer.Serialize(game, path);

                    saveWorker.ReportProgress(++i);

                    Thread.Sleep(1000);
                }
            };

            saveWorker.ProgressChanged += (object sender, ProgressChangedEventArgs e) =>
            {
                window.FilesSaved = e.ProgressPercentage;
            };

            saveWorker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) => 
            {
                window.Close();
                saveWorker = null;
            };
            saveWorker.RunWorkerAsync();
        }
    }
}
