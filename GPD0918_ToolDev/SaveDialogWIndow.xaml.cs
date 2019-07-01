using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace GPD0918_ToolDev
{
    /// <summary>
    /// Interaktionslogik für SaveDialogWIndow.xaml
    /// </summary>
    public partial class SaveDialogWIndow : Window, INotifyPropertyChanged
    {

        private int m_filesToSave;
        public int FilesToSave { get { return m_filesToSave; } set { m_filesToSave = value; OnPropertyChanged(); } }

        private int m_filesSaved;
        public int FilesSaved { get { return m_filesSaved; } set { m_filesSaved = value; OnPropertyChanged(); } }

        public SaveDialogWIndow()
        {
            InitializeComponent();
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
