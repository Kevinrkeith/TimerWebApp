using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using TimerWebApplicationKevin.Misc;
using TimerWebApplicationKevin.Model;

namespace TimerWebApplicationKevin.ViewModel
{
    public class TimerViewModel : BaseViewModel
    {
        private bool started = false;
        public string _startTime { get; set; }
        public string _endTime { get; set; }
        public string _startTimer { get; private set; }
        public ICommand SubmitButton { get; private set; }
        public ICommand ExitButton { get; private set; }
        public ICommand StartTime { get; private set; }

        public ICommand NavigateLoginCommand { get; set; }

        ObservableCollection<TimerModelLogic> timerModels = new ObservableCollection<TimerModelLogic>();
        public TimerViewModel(NavigationStore navi)
        {
            _startTimer = "Start Timer";
            OnPropertyChanged(nameof(_startTimer));
            SubmitButton = new DelegateCommand(submitButtonPressed);
            ExitButton = new DelegateCommand(exitButton);
            StartTime = new DelegateCommand(StartButton);
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(navi, () => new LoginViewModel(navi));
        }
        private void StartButton()
        {
            if (!started)
            {
                _startTimer = "Stop Timer";
                _startTime = DateTime.Now.ToString("HH:mm:ss:fff");
                started = true;
            }
            else
            {
                _startTimer = "Start Timer";
                _endTime = DateTime.Now.ToString("HH:mm:ss:fff");
                started = false;
            }
            OnPropertyChanged(nameof(_startTimer));
            OnPropertyChanged(nameof(_startTime));
            OnPropertyChanged(nameof(_endTime));
        }
        private void submitButtonPressed()
        {
            DateTime start = DateTime.ParseExact(this._startTime, "HH:mm:ss:fff", CultureInfo.InvariantCulture);
            DateTime end = DateTime.ParseExact(this._endTime, "HH:mm:ss:fff", CultureInfo.InvariantCulture);

            TimeSpan diff = end.Subtract(start);

            MessageBox.Show($"Total time: '{diff.ToString()}'");
            timerModels.Add(new TimerModelLogic { startTime = start, endTime = end, totalTime = diff });
        }
        private void exitButton()
        {
            MessageBox.Show("GoodBye");
            Environment.Exit(0);
        }
    }
}
