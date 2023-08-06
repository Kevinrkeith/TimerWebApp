using TimerWebApplicationKevin.Model;

namespace TimerWebApplicationKevin.ViewModel
{
    public class MainWindowModel : BaseViewModel
    {
        private readonly NavigationStore navigation;
        public BaseViewModel CurrentViewModel => navigation.CurrentViewModel;
        public MainWindowModel(NavigationStore navigation)
        {
            this.navigation = navigation;

            navigation.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
