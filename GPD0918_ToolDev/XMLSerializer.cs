using System;
using System.IO;
using System.Windows;
using System.Xml.Linq;

namespace GPD0918_ToolDev
{

    public class XMLSeriaizer : IGameSerializer
    {

        public Game Deserialize(string _path)
        {
            XDocument document = XDocument.Load(_path);

            XElement rootElement = document.Root;

            if (rootElement.Name != "Game")
                throw new InvalidDataException("No valid Game xml.");

            Game game = new Game();

            game.Name = rootElement.Element("Name").Value;
            game.TimePlayed = long.Parse(rootElement.Element("TimePlayed").Value);
            game.InstallLocation = rootElement.Element("InstallLocation").Value;
            game.PatchNotes = rootElement.Element("PatchNotes").Value;

            #region Foreach Variante
            /*
            foreach (XElement childElement in rootElement.Nodes())
            {
                switch(childElement.Name.ToString())
                {
                    case "Name":
                        game.Name = childElement.Value;
                        break;
                    case "PatchNotes":
                        break;
                    case "InstallLocation":
                        break;
                    case "TimePlayed":
                        break;
                }
            }
            */
            #endregion

            return game;
        }

        public void Serialize(Game _game, string _path)
        {
            XDocument document = new XDocument();

            XElement rootElement = new XElement("Game");

            XElement name = new XElement("Name");
            name.Value = _game.Name;
            rootElement.Add(name);

            XElement timePlayed = new XElement("TimePlayed");
            timePlayed.Value = _game.TimePlayed.ToString();
            rootElement.Add(timePlayed);

            XElement patchNotes = new XElement("PatchNotes");
            patchNotes.Value = _game.PatchNotes;
            rootElement.Add(patchNotes);

            XElement installLocation = new XElement("InstallLocation");
            installLocation.Value = _game.InstallLocation;
            rootElement.Add(installLocation);

            // element als root node setzten
            document.Add(rootElement);

            // das dokument in die datei an dem pfad speichern.
            document.Save(_path);
        }

    }

}
