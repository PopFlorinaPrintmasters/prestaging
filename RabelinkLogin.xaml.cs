using CommunityToolkit.Maui.Views;

namespace PrestagingProject;

public partial class RabelinkLogin : Popup
{
	public RabelinkLogin()
	{
		InitializeComponent();
	}

	private void OkButtonRabelinkMenu_Clicked(object sender, EventArgs e)
	{
        if (EntryRabelinkLogin.Text == "Rabelink01!")
		{
			Close("Ok");
		}
		else
		{
			if (!string.IsNullOrEmpty(EntryRabelinkLogin.Text))
			{
                Close("Nu ok");
            }
		}
    }
}