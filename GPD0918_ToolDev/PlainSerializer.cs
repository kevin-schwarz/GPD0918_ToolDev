using System;
using System.IO;
using System.Windows;

namespace GPD0918_ToolDev
{

    public class PlainSerializer : IGameSerializer
    {

        public Game Deserialize(string _path)
        {
            try
            {
                using (Stream stream = File.OpenRead(_path))
                {
                    StreamReader reader = new StreamReader(stream);

                    Game game = new Game();
                    game.Name = reader.ReadLine();
                    game.TimePlayed = long.Parse(reader.ReadLine());
                    game.PatchNotes = reader.ReadLine();
                    game.InstallLocation = reader.ReadLine();

                    return game;
                }
            }
            catch(FileNotFoundException fof)
            {
                MessageBox.Show("Die Datei wurde nicht gefunden.",
                    "Fehler beim laden,",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Fehler beim laden,",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            return new Game();
        }

        public void Serialize(Game _game, string _path)
        {
            using (Stream stream = File.OpenWrite(_path))
            {
                StreamWriter writer = new StreamWriter(stream);
                
                writer.WriteLine(_game.Name);
                writer.WriteLine(_game.TimePlayed);
                writer.WriteLine(_game.PatchNotes);
                writer.WriteLine(_game.InstallLocation);

                writer.Flush();
            }
        }

    }

}
