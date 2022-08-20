namespace PrestagingProject;

public partial class RabelinkMenu : ContentPage
{
	public RabelinkMenu()
	{
		InitializeComponent();
	}

	private void ButtonPrintRabelinkMenu_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new RabelinkPrint(), false);
	}
}