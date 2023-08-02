using HollysPillReminderApp.Utils;
using System.ComponentModel;

namespace HollysPillReminderApp.Model
{
    public class Day : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private bool tookPill = false;
        private Button tookPillButton = null;

        public int DayNumber { get; set; } = -1;

        public bool TookPill
        {
            get { return tookPill; }
            private set 
            { 
                tookPill = value; 

                ChangeButtonBackgroundColor();

                OnPropertyChanged(nameof(TookPill));
            }
        }

        public Button TookPillButton
        {
            get { return tookPillButton; }
            set
            {
                tookPillButton = value;

                TookPillButton.Clicked -= new EventHandler(OnTookPillButtonClick);
                TookPillButton.Clicked += new EventHandler(OnTookPillButtonClick);

                OnPropertyChanged(nameof(TookPillButton));
            }
        }

        public Day(int dayNumber, Button tookPillButton)
        {
            this.DayNumber = dayNumber;
            this.TookPillButton = tookPillButton;

            TookPillButton.Text = DayNumber.ToString();

            if (DayNumber == DateTime.Today.Day)
            {
                TookPillButton.BorderWidth = 5;
                TookPillButton.BorderColor = ColorsHandler.ButtonBorderColorForTodayMark;
            }
        }

        private void ChangeButtonBackgroundColor()
        {
            if (TookPill == true)
            {
                TookPillButton.BackgroundColor = ColorsHandler.SelectedButtonBackgroundColor;
                return;
            }

            TookPillButton.BackgroundColor = ColorsHandler.UnSelectedButtonBackgroundColor;
            return;
        }

        private void OnTookPillButtonClick(object sender, EventArgs e)
        {
            if (TookPill == true)
            {
                TookPill = false;
                return;
            }

            TookPill = true;
            return;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
