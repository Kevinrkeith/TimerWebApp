using System;

namespace TimerWebApplicationKevin.Model
{
    public class NavigationStore
    {
        private BaseViewModel currentViewModel { get; set; }
        public BaseViewModel CurrentViewModel
        {

            get => currentViewModel;

            set
            {
                Console.WriteLine("Hello");
                currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }
        public event Action CurrentViewModelChanged;
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
