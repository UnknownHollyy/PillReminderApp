using HollysPillReminderApp.ViewModel;

namespace HollysPillReminderApp.View;

public partial class TimeSelectView : ContentPage
{
	public TimeSelectView(TimeSelectViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}

}