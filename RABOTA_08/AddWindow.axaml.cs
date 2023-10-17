using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace RABOTA_08;

public partial class AddWindow : Window
{
    private readonly Application _application;
    public AddWindow(Application application)
    {
        _application = application;
        InitializeComponent();
    }

    private void AddBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        string _connString = "server=10.10.1.24;database=pro1_8;User Id=user_01;password=user01pro";
        List<Application> _aplications;
        MySqlConnection _connection;
        string sql = "INSERT INTO Заявка (ОборудованиеIDs, СерийныйНомер, ОписаниеПроблемы, ТипОборудование, ПриоритетIDs, КлиентIDs) VALUES (@Equip, @SerialN, @Description, @Type, @Priority, @Client);";
        _aplications = new List<Application>();
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        MySqlCommand command = new MySqlCommand(sql, _connection);
        command.Parameters.Add("@Id", MySqlDbType.Int32);
        command.Parameters["@Id"].Value = this._application.Id;
        command.Parameters.Add("@Equip", MySqlDbType.Int32);
        command.Parameters["@AddName"].Value = Equip.Text;
        command.Parameters.Add("@SerialN", MySqlDbType.Int32);
        command.Parameters["@SerialN"].Value = SerialN.Text;
        command.Parameters.Add("@Description", MySqlDbType.String);
        command.Parameters["@Description"].Value = Description.Text;
        command.Parameters.Add("@Type", MySqlDbType.Int32);
        command.Parameters["@Type"].Value = Type.Text;
        command.Parameters.Add("@Prioirity", MySqlDbType.Int32);
        command.Parameters["@Priority"].Value = Priority.Text;
        command.Parameters.Add("@Client", MySqlDbType.Int32);
        command.Parameters["@Client"].Value = Client.Text;
        command.ExecuteNonQuery();
        this.Close(true);
        Result = true;
    }
    public bool Result { get; private set; }
}

