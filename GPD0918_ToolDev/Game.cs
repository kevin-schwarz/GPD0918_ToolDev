using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPD0918_ToolDev
{

    public class Game
    {

        // todo: icon

        /// <summary>
        /// Der Name des Spiels.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Die Zeit die das Spiel offen war.
        /// </summary>
        public long TimePlayed { get; set; }

        /// <summary>
        /// Die Patch Notes.
        /// </summary>
        public string PatchNotes { get; set; }

        /// <summary>
        /// Wo ist das Spiel installiert.
        /// </summary>
        public string InstallLocation { get; set; }

    }

}
