using Android.App;
using Android.OS;
using Android.Runtime;
using HollysPillReminderApp.Interfaces;
using Resource = HollysPillReminderApp.Resource;
using Android.Content;
using AndroidX.Core.App;
using HollysPillReminderApp.Model;

namespace HollysPillReminderApp
{
    [Service(ForegroundServiceType = Android.Content.PM.ForegroundService.TypeDataSync)]
    public class ForegroundService : Service, IServices
    {

        private string NOTIFICATION_CHANNEL_ID = "1000";
        private int NOTIFICATION_ID = 1;
        private string NOTIFICATION_CHANNEL_NAME = "notification";

        public override IBinder OnBind(Intent intent)
        {
            throw new NotImplementedException();
        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            if (intent.Action == "START_SERVICE")
                RegisterNotification();
            else if (intent.Action == "STOP_SERVICE")
            {
                StopForeground(true);
                StopSelfResult(startId);
            }

            return StartCommandResult.NotSticky;
        }

        public void Start(int houre, int minuts)
        {
            PillReminder pillReminder = new PillReminder(houre, minuts);

            Intent startServics = new Intent(MainActivity.ActivityCurrent, typeof(ForegroundService));
            startServics.SetAction("START_SERVICE");
            MainActivity.ActivityCurrent.StartService(startServics);
        }

        public void Stop()
        {
            Intent stopIntent = new Intent(MainActivity.ActivityCurrent, Class);
            stopIntent.SetAction("STOP_SERVICE");
            MainActivity.ActivityCurrent.StopService(stopIntent);
        }

        private void RegisterNotification()
        {
            NotificationManager notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                createNotificationChannel(notificationManager);
            }

            var notification = new NotificationCompat.Builder(this, NOTIFICATION_CHANNEL_ID);
            notification.SetOngoing(false);
            notification.SetSmallIcon(Resource.Drawable.pill);
            notification.SetContentTitle("ForegroundService");
            notification.SetContentText("ForegroundService is running!");

            StartForeground(NOTIFICATION_ID, notification.Build());
        }

        private void createNotificationChannel(NotificationManager notifcationManager)
        {
            NotificationChannel channel = new NotificationChannel(NOTIFICATION_CHANNEL_ID, NOTIFICATION_CHANNEL_NAME, NotificationImportance.Low);
            notifcationManager.CreateNotificationChannel(channel);
        }
    }
}
