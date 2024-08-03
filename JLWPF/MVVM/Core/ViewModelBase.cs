using System.ComponentModel;
using System.Windows.Input;

namespace JLWPF.MVVM.Core
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public ICommand? UpdateViewCommand { get; set; } = null;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}