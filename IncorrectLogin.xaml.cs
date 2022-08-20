using CommunityToolkit.Maui.Views;

namespace PrestagingProject;

public partial class IncorrectLogin : Popup
{
	public IncorrectLogin()
	{
		InitializeComponent();
	}

	private void OkButtonIncorrectLogin_Clicked(object sender, EventArgs e)
	{
		Close();
	}
}