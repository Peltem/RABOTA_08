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
        string sql = "INSERT Заявка SET ОборудованиеIDs = @Equip, СерийныйНомер = @SerialN, ОписаниеПроблемы = @Description  WHERE ID_Клиента = @Id;";
        _aplications = new List<Application>();
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        MySqlCommand command = new MySqlCommand(sql, _connection);
        command.Parameters.Add("@Id", MySqlDbType.Int32);
        command.Parameters["@Id"].Value = this._application.Id;
        command.Parameters.Add("@Equip", MySqlDbType.Int32);
        command.Parameters["@AddName"].Value = Equip.Text;
        command.Parameters.Add("@SerialN", MySqlDbType.Int32);
        command.Parameters["@AddNumber"].Value = SerialN.Text;
}