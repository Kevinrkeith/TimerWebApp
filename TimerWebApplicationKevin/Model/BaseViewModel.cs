using System.ComponentModel;
using TimerWebApplicationKevin.Misc;

namespace TimerWebApplicationKevin.Model
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        NavigateCommand<BaseViewModel> navigateCommand;
        public BaseViewModel()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
