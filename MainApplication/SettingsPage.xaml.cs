using MainApplication.ViewModels;

namespace MainApplication;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();

        BindingContext = new SettingsViewModel();
    }
}