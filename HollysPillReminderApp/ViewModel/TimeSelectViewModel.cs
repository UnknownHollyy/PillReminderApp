
using HollysPillReminderApp.Commands;
using HollysPillReminderApp.Interfaces;
using HollysPillReminderApp.Utils;
using System.ComponentModel;
using System.Windows.Input;

namespace HollysPillReminderApp.ViewModel
{
    public class TimeSelectViewModel : INotifyPropertyChanged
    {

        private IServices services;

        public event PropertyChangedEventHandler PropertyChanged;

        public Color GradientFirstColor { get; private set; } = ColorsHandler.GradientFirstColor;
        public Color GradientSecondColor { get; private set; } = ColorsHandler.GradientSecondColor;

        public int[] HourePickerArray { get; private set; } = new int[24];
        public int[] MinutsPickerArray { get; private set; } = new int[60];

        private int hourePickerIndex = 0;
        private int minutsPickerIndex = 0;

        public Thickness ButtonMargin { get; private set; } = new(0, 0, 50, 0);

        private ICommand onCancelButtonClicked;
        private ICommand onStartButtonClicked;

        public int HourePickerIndex
        {
            get { return hourePickerIndex; }
            set 
            { 
                hourePickerIndex = value; 

                OnPropertyChanged(nameof(HourePickerIndex));
            }
        }

        public int MinutsPickerIndex
        {
            get { return minutsPickerIndex; }
            set 
            { 
                minutsPickerIndex = value; 

                OnPropertyChanged(nameof(MinutsPickerIndex));
            }
        }

        public ICommand OnCancelButtonClicked
        {
            get
            {
                return onCancelButtonClicked ?? (onCancelButtonClicked = new CommandHandler(() => GoBackToMainPage(), () => CanExecuteOnCancelButtonClicked));
            }
        }

        private bool CanExecuteOnCancelButtonClicked
        {
            get { return true; }
        }

        public ICommand OnStartButtonClicked
        {
            get
            {
                return onStartButtonClicked ?? (onStartButtonClicked = new CommandHandler(() => StartTimer(), () => CanExecuteOnStartButtonClicked));
            }
        }

        private bool CanExecuteOnStartButtonClicked
        {
            get { return true; }
        }

        public TimeSelectViewModel(IServices services)
        {
            this.services = services;

            FillPickerArrays();
            MatchPickerIndexWithCurrentDateTime();
        }

        private void FillPickerArrays()
        {
            for (int i = 0; i < HourePickerArray.Length; i++)
                HourePickerArray[i] = i;

            for (int i = 0; i < MinutsPickerArray.Length; i++)
                MinutsPickerArray[i] = i;
        }

        private void MatchPickerIndexWithCurrentDateTime()
        {
            HourePickerIndex = DateTime.Now.Hour;
            MinutsPickerIndex = DateTime.Now.Minute;
        }

        private async void GoBackToMainPage()
        {
            services.Stop();
            await Shell.Current.GoToAsync("..");
        }

        private async void StartTimer()
        {
            services.Start(HourePickerIndex, MinutsPickerIndex);
            await Shell.Current.GoToAsync("..");
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
