using System;
using System.ComponentModel;
using TimerWebApplicationKevin.Model;

namespace TimerWebApplicationKevin.Misc
{
    public class NavigateCommand<TViewModel> : CommandBase
        where TViewModel : BaseViewModel
    {
        private readonly NavigationStore navi;
        private readonly Func<TViewModel> viewModel;

        public NavigateCommand(NavigationStore navi, Func<TViewModel> createViewModel)
        {
            this.navi = navi;
            viewModel = createViewModel;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override void Execute(object parameter)
        {
            Console.WriteLine("Hello");
            navi.CurrentViewModel = viewModel();
        }
    }
}
