using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GPD0918_ToolDev
{

    public class Game : INotifyPropertyChanged
    {

        public string FileName
        {
            get
            {
                string tempName = $"{m_name}.xml";
                char[] invalidChars = System.IO.Path.GetInvalidFileNameChars();
                
                foreach(char invalid in invalidChars)
                {
                    tempName = tempName.Replace(invalid.ToString(), "");
                }

                return tempName;
            }
        }

        // todo: icon

        /// <summary>
        /// Der Name des Spiels.
        /// </summary>
        private string m_name;
        public string Name
        {
            get
            {
                return m_name;
            }

            set
            {
                m_name = value;
                OnPropertyChanged();
            }
        }
        /*
        private string name;
        public string GetName() { return name; }
        public void SetName(string _value) { name = _value; OnPropertyChanged("Name"); }
        */

        /// <summary>
        /// Die Zeit die das Spiel offen war.
        /// </summary>
        private long m_timePlayed;
        public long TimePlayed
        {
            get
            {
                return m_timePlayed;
            }

            set
            {
                m_timePlayed = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Die Patch Notes.
        /// </summary>
        private string m_patchNotes;
        public string PatchNotes
        {
            get
            {
                return m_patchNotes;
            }

            set
            {
                m_patchNotes = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Wo ist das Spiel installiert.
        /// </summary>
        private string m_installLocation;
        public string InstallLocation
        {
            get
            {
                return m_installLocation;
            }

            set
            {
                m_installLocation = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Helfer-Methode zum aufrufen des change events.
        /// CallerMemberName sagt dem Compiler, dass er die Variable mit dem Namen des aufrufenden Members füllen soll.
        /// </summary>
        /// <param name="_propertyName"></param>
        private void OnPropertyChanged([CallerMemberName] string _propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(_propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }

}
