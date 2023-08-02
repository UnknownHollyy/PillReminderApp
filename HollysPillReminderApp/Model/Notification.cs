using Plugin.LocalNotification;
using Plugin.LocalNotification.AndroidOption;

namespace HollysPillReminderApp.Model
{
    public class Notification
    {

        public Notification()
        {
            EventsInitialization();
        }

        private void EventsInitialization()
        {
            Timer.OnTimeEqualsTimer += SendNotification;
        }

        private void SendNotification()
        {
            NotificationRequest request = new NotificationRequest
            {
                NotificationId = 1,
                Title = "Pill Reminder!",
                Description = $"Its {DateTime.Now.Hour} o'clock. Time to take your pill!",
                BadgeNumber = 1,
                Android =
                {
                    IconSmallName = new AndroidIcon { ResourceName = Resource.Drawable.pill.ToString() }
                },
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now
                }
            };

            LocalNotificationCenter.Current.Show(request);
        }

    }
}
