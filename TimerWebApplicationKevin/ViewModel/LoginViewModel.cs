using System;
using System.Windows.Input;
using TimerWebApplicationKevin.Misc;
using TimerWebApplicationKevin.Model;

namespace TimerWebApplicationKevin.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand NavigateHomeCommand { get; set; }
        public LoginViewModel(NavigationStore navi)
        {
            NavigateHomeCommand = new NavigateCommand<ShowResultsViewModel>(navi, () => new ShowResultsViewModel(navi));
        }
        private void Login()
        {
            OnPropertyChanged(nameof(username));
            OnPropertyChanged(nameof(password));
            Console.WriteLine(username == "Admin" && password == "Admin");
        }
    }
}
