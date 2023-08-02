
namespace HollysPillReminderApp.Utils
{
    public class ColorsHandler
    {

        public static Color GradientFirstColor { get; private set; } = Color.FromRgb(34, 59, 201);
        public static Color GradientSecondColor { get; private set; } = Color.FromRgb(6, 127, 208);

        public static Color UnSelectedButtonBackgroundColor { get; private set; } = Color.FromRgb(21, 26, 123);
        public static Color SelectedButtonBackgroundColor { get; private set; } = Color.FromRgb(0, 0, 0);

        public static Color ButtonBorderColor { get; private set; } = Color.FromRgb(255, 255, 255);
        public static Color ButtonBorderColorForTodayMark { get; private set; } = Color.FromRgb(230, 59, 96);

    }
}
