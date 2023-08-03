using HollysPillReminderApp.Commands;
using HollysPillReminderApp.Model;
using HollysPillReminderApp.Utils;
using HollysPillReminderApp.View;
using System.Windows.Input;

namespace HollysPillReminderApp.ViewModel
{
    public class MainPageViewModel
    {

        public Color GradientFirstColor { get; private set; } = ColorsHandler.GradientFirstColor;
        public Color GradientSecondColor { get; private set; } = ColorsHandler.GradientSecondColor;

        public Color GoToTimeSelectViewButtonBackgroundColor { get; private set; } = ColorsHandler.UnSelectedButtonBackgroundColor;

        public Thickness Margin { get; private set; } = new Thickness(15, 30, 0, 15);
        public int FontSize { get; private set; } = 16;

        public Thickness LabelBackgroundMargin { get; private set; } = new Thickness(10, 15, 10, 10);

        private int year = DateTime.Now.Year;
        private int month = DateTime.Now.Month;
        private int MaxDaysNumberInMonth;

        private List<Day> days = new();
        private int buttonColumn;
        private int buttonRow;

        private ICommand goToTimeSelectViewCommand;

        public ICommand GoToTimeSelectViewCommand
        {
            get
            {
                return goToTimeSelectViewCommand ?? (goToTimeSelectViewCommand = new CommandHandler(() => SwitchToTimeSelectView(), () => CanExecuteGoToTimeSelectViewCommand));
            }
        }

        public bool CanExecuteGoToTimeSelectViewCommand
        {
            get { return true; }
        }

        public List<Day> DaysList
        {
            get { return days; }
            set { days = value; }
        }

        public MainPageViewModel()
        {
            MaxDaysNumberInMonth = DateTime.DaysInMonth(year, month);
            CreateButtons(MaxDaysNumberInMonth);
        }

        private void CreateButtons(int Days)
        {
            MoveButtonToMonthStartDayOfWeek();

            buttonRow = 1;

            for (int i = 0; i < Days; i++) 
            {

                if (buttonColumn == 7)
                {
                    buttonColumn = 0;
                    buttonRow++;
                }

                Button button = new()
                {
                    HeightRequest = 55,
                    WidthRequest = 55,
                    Margin = new Thickness(3, 0, 0, 0),
                    BackgroundColor = ColorsHandler.UnSelectedButtonBackgroundColor,
                    FontAttributes = FontAttributes.Bold,
                    BorderWidth = 2,
                    BorderColor = ColorsHandler.ButtonBorderColor
                };

                button.SetValue(Grid.ColumnProperty, buttonColumn);
                button.SetValue(Grid.RowProperty, buttonRow);

                buttonColumn++;

                Day day = new(i + 1, button);
                DaysList.Add(day);
            }
        }

        private void MoveButtonToMonthStartDayOfWeek()
        {
            string dayOfWeek = DateTime.Now.AddDays(-DateTime.Now.Day + 1).DayOfWeek.ToString();

            switch (dayOfWeek)
            {
                case "Monday":
                    buttonColumn = 0;
                    break;
                case "Tuesday":
                    buttonColumn = 1;
                    break;
                case "Wednesday":
                    buttonColumn = 2;
                    break;
                case "Thursday":
                    buttonColumn = 3;
                    break;
                case "Friday":
                    buttonColumn = 4;
                    break;
                case "Saturday":
                    buttonColumn = 5;
                    break;
                case "Sunday":
                    buttonColumn = 6;
                    break;
                default:
                    Console.WriteLine("dayOfWeek is out of Range!");
                    break;
            }
        }

        private async void SwitchToTimeSelectView()
        {
            await Shell.Current.GoToAsync(nameof(TimeSelectView));
        }

    }
}
