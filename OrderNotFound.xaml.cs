using CommunityToolkit.Maui.Views;

namespace PrestagingProject;

public partial class OrderNotFound : Popup
{
	public OrderNotFound()
	{
		InitializeComponent();
	}

	private void OkButtonOrderNotFound_Clicked(object sender, EventArgs e)
	{
		Close();
	}
}