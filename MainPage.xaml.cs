using CommunityToolkit.Maui.Views;

namespace PrestagingProject;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void RabelinkButtonMainPage_Clicked(object sender, EventArgs e)
	{
		var pwd = await this.ShowPopupAsync(new RabelinkLogin());

		if ((string)pwd == "Ok")
		{
			await Navigation.PushAsync(new RabelinkMenu(), false);
		}
		else
		{
			if (!string.IsNullOrEmpty((string)pwd))
			{
                this.ShowPopup(new IncorrectLogin());
            }
            
        }
    }
}