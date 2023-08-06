using System.Windows;
using TimerWebApplicationKevin.Model;
using TimerWebApplicationKevin.ViewModel;

namespace TimerWebApplicationKevin.Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore navigation;
        public App()
        {
            navigation = new NavigationStore();
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            navigation.CurrentViewModel = new LoginViewModel(navigation);

            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowModel(navigation)
            };
            MainWindow.Show();
        }
    }
}
