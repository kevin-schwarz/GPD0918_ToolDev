using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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

        protected override void OnStartup(StartupEventArgs e)
        {
            foreach (string file in Directory.GetFiles("./games", "*.xml"))
            {
                GameList.Add(GameSerializer.Deserialize(file));
            }

            base.OnStartup(e);
        }

    }
}
