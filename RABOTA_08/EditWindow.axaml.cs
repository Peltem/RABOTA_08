using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace RABOTA_08;

public partial class EditWindow : Window
{
    private readonly Application1 _application1;
    public EditWindow(Application1 application1)
    {
        _application1 = application1;
        InitializeComponent();
    }
    private void EditBtn_OnClick(object? sender, RoutedEventArgs e){
    string _connString = "server=10.10.1.24;database=pro1_8;User Id=user_01;password=user01pro";
    List<Application1> _application1s ;
    MySqlConnection _connection;
    string sql = "UPDATE Заявка SET (ОборудованиеIDs, СерийныйНомер, ОписаниеПроблемы, ТипОборудования, ПриоритетIDs, КлиентIDs) VALUES (@Equip, @SerialN, @Description, @TypeEq, @Priority, @Client)";
    _application1s = new List<Application1>();
    _connection = new MySqlConnection(_connString);
    _connection.Open();
    MySqlCommand command = new MySqlCommand(sql, _connection);
    command.Parameters.Add("@Id", MySqlDbType.Int32);
    command.Parameters["@Id"].Value =this._application1.Id;
    command.Parameters.Add("@Equip", MySqlDbType.Int32);
    command.Parameters["@Equip"].Value = Equip.Text;
    command.Parameters.Add("@SerialN", MySqlDbType.Int32);
    command.Parameters["@SerialN"].Value = SerialN.Text;
    command.Parameters.Add("@Description", MySqlDbType.String);
    command.Parameters["@Description"].Value = Description.Text;
    command.Parameters.Add("@TypeEq", MySqlDbType.Int32);
    command.Parameters["@TypeEq"].Value = TypeEq.Text;
    command.Parameters.Add("@Priority", MySqlDbType.Int32);
    command.Parameters["@Priority"].Value = Priority.Text;
    command.Parameters.Add("@Client", MySqlDbType.Int32);
    command.Parameters["@Client"].Value = Client.Text;
    command.ExecuteNonQuery();
    this.Close(true);
    Result = true; 
        
}
public bool Result { get; private set; }
}
