using System;
using System.IO;
using System.Windows;

namespace GPD0918_ToolDev
{

    public class BinarySeriaĺizer : IGameSerializer
    {

        public Game Deserialize(string _path)
        {
            try
            {
                using (Stream stream = File.OpenRead(_path))
                {
                    BinaryReader reader = new BinaryReader(stream);

                    Game game = new Game();
                    game.Name = reader.ReadString();
                    game.TimePlayed = reader.ReadInt64();
                    game.PatchNotes = reader.ReadString();
                    game.InstallLocation = reader.ReadString();

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
                BinaryWriter writer = new BinaryWriter(stream);

                writer.Write(_game.Name);
                writer.Write(_game.TimePlayed);
                writer.Write(_game.PatchNotes);
                writer.Write(_game.InstallLocation);

                writer.Flush();
            }
        }

    }

}
