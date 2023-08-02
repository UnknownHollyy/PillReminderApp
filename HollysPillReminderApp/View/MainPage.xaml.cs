using HollysPillReminderApp.Model;
using HollysPillReminderApp.ViewModel;

namespace HollysPillReminderApp.View;

public partial class MainPage : ContentPage
{
	private MainPageViewModel Vm { get; set; }

	public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();

		this.Vm = vm;
		BindingContext = Vm;

		SetButtonToLayout();
	}

	public void SetButtonToLayout()
	{
		foreach (Day day in Vm.DaysList) 
		{
			Layout.Add(day.TookPillButton);
		}
	}

}

