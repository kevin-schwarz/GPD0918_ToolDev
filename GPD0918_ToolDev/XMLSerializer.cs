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
            throw new NotImplementedException();
        }

        public void Serialize(Game _game, string _path)
        {
            XDocument document = new XDocument();

            XElement element = new XElement("Game");

            XElement name = new XElement("Name");
            name.Value = _game.Name;
            element.Add(name);

            XElement timePlayed = new XElement("TimePlayed");
            timePlayed.Value = _game.TimePlayed.ToString();
            element.Add(timePlayed);

            XElement patchNotes = new XElement("PatchNotes");
            patchNotes.Value = _game.PatchNotes;
            element.Add(patchNotes);

            XElement installLocation = new XElement("InstallLocation");
            installLocation.Value = _game.InstallLocation;
            element.Add(installLocation);

            document.Add(element);
            document.Save(_path);
        }

    }

}
