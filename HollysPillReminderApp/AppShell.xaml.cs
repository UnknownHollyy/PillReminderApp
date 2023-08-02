using HollysPillReminderApp.View;

namespace HollysPillReminderApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(TimeSelectView), typeof(TimeSelectView));
    }
}
