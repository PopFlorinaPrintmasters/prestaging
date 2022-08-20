using MySqlConnector;
using System.Collections.ObjectModel;

namespace PrestagingProject;

public partial class OrderPrintRabelink : ContentPage
{
    readonly DBConnection dbc = new DBConnection();

    public class ITEM
    {
        public string ItemName { get; set; }
    }

    readonly ObservableCollection<ITEM> items = new();

    public ObservableCollection<ITEM> Items { get { return items; } }

    public OrderPrintRabelink(string order)
	{
		InitializeComponent();

		SCOrderPrint.Text = order;

        MySqlConnection conn = new(dbc.connstring);

        conn.Open();

        MySqlCommand cmd = new(" SELECT `PRODUCTMODELID` " +
                               " FROM `received_goods` " +
                               " WHERE `CUSTREF` = '" + SCOrderPrint.Text + "'", conn);

        MySqlDataReader rdr = cmd.ExecuteReader();

        if (rdr.HasRows)
        {
            while (rdr.Read())
            {
                items.Add(new ITEM() { ItemName = rdr.GetString(0) });
            }

            conn.Close();

            CollectionViewOrderPrint.ItemsSource = Items;
        }
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        this.DisplayAlert("test", "test mesaj", "test cancel");
    }
}