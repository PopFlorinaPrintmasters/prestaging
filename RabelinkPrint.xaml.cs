using CommunityToolkit.Maui.Views;
using MySqlConnector;
using System.Collections.ObjectModel;

namespace PrestagingProject;

public partial class RabelinkPrint : ContentPage
{
    readonly DBConnection dbc = new DBConnection();

    public class CUSTREF
    {
        public string Name { get; set; }
    }

    readonly ObservableCollection<CUSTREF> custrefs = new();

    public ObservableCollection<CUSTREF> Custrefs { get { return custrefs; } }

	public RabelinkPrint()
	{
		InitializeComponent();
	}
	private void BackButtonRabelinkPrint_Clicked(object sender, EventArgs e)
	{
        Navigation.PushAsync(new RabelinkMenu(), false);
    }

	private void ButtonSearchRabelinkPrint_Clicked(object sender, EventArgs e)
	{
        if (!string.IsNullOrEmpty(EntryRabelinkPrint.Text))
        {
            MySqlConnection conn = new(dbc.connstring);

            conn.Open();

            MySqlCommand cmd = new(" SELECT `CUSTREF` " +
                                   " FROM `received_goods` " +
                                   " WHERE `CUSTREF` LIKE '%" + EntryRabelinkPrint.Text + "%' AND " +
                                   "       `STATUS` = 'Released'", conn);

            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                ButtonSearchRabelinkPrint.IsVisible = false;

                while (rdr.Read())
                {
                    custrefs.Add(new CUSTREF() { Name = rdr.GetString(0) });
                }

                conn.Close();

                CollectionViewRabelinkPrint.ItemsSource = Custrefs;
            }
            else
            {
                this.ShowPopup(new OrderNotFound());
            }
        }
    }

    private void RefreshButtonRabelinkPrint_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RabelinkMenu());
        Navigation.PushAsync(new RabelinkPrint());
    }

    private void CollectionViewRabelinkPrint_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Navigation.PushAsync(new OrderPrintRabelink((e.CurrentSelection[0] as CUSTREF).Name), false);
    }
}