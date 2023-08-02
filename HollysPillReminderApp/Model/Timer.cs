using System.ComponentModel;

namespace HollysPillReminderApp.Model
{
    public class Timer : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public static event Action OnTimeEqualsTimer;

        private bool timerIsSet = false;

        private float timeToNotifyHour;
        private float timeToNotifyMinute;

        public bool TimerIsSet
        {
            get { return timerIsSet; }
            set 
            { 
                timerIsSet = value;

                if (timerIsSet)
                    OnTimerSet();

                OnPropertyChanged(nameof(TimerIsSet));
            }
        }

        public Timer(float hour, float minute)
        {
            this.timeToNotifyHour = hour;
            this.timeToNotifyMinute = minute;
        }

        private async void OnTimerSet()
        {
            if (!timerIsSet)
                return;

            while (timerIsSet)
            {
                if (DateTime.Now.Hour == timeToNotifyHour && DateTime.Now.Minute == timeToNotifyMinute)
                {
                    OnTimeEqualsTimer?.Invoke();
                    timerIsSet = false;
                    return;
                }

                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
