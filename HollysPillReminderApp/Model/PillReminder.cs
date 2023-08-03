using Plugin.LocalNotification;
using Plugin.LocalNotification.AndroidOption;

namespace HollysPillReminderApp.Model
{
    public class PillReminder
    {

        private int whenToRemindHour;
        private int whenToRemindMinutes;

        public PillReminder(int houre, int minutes)
        {
            whenToRemindHour = houre;
            whenToRemindMinutes = minutes;
            CheckTime();
        }

        private async void CheckTime()
        {
            DateTime remindeTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, whenToRemindHour, whenToRemindMinutes, 0);

            NotificationRequest request = new NotificationRequest()
            {
                NotificationId = 400,
                Title = "Pill Reminder!",
                Description = "Its time to take your pill!",
                BadgeNumber = 1,
                Android =
                {
                    IconSmallName = new AndroidIcon { ResourceName = Resource.Drawable.pill.ToString() }
                },
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = remindeTime
                }
            };

            await LocalNotificationCenter.Current.Show(request);
        }

    }
}
