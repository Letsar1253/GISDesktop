using System.ComponentModel;

namespace GisDesktop.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private string filePath;

        public string FilePath { 
            get
            {
                return filePath;
            }
            set 
            {
                if(filePath == value) 
                    return;

                filePath = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FilePath)));
            } 
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
