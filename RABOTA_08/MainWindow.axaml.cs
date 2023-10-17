using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;

namespace RABOTA_08;

public partial class MainWindow : Window
{
    private void UpdateDataGrid()
    {
        using (var connection = new MySqlConnection(_connection.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT*FROM `Заявка`";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Application1s.Add(new Application1
                        {
                            Id = reader.GetInt32("ID"),
                            Equip = reader.GetInt32("ОборудованиеIDs"),
                            SerialN = reader.GetInt32("СерийныйНомер"),
                            Description = reader.GetString("ОписаниеПроблемы"),
                            TypeEq = reader.GetInt32("ТипОборудования"),
                            Priority = reader.GetInt32("ПриоритетIDs"),
                            Client = reader.GetInt32("КлиентIDs")

                        });
                    }
                }
            }

            connection.Close();
        }

        DataGridApplic.ItemsSource = Application1s;
    }

    private List<Application1> Application1s { get; set; }
    private MySqlConnectionStringBuilder _connection;

    public MainWindow()
    {
        InitializeComponent();
        Application1s = new List<Application1>();
        _connection = new MySqlConnectionStringBuilder
        {
            Server = "10.10.1.24",
            Database = "pro1_8",
            UserID = "user_01",
            Password = "user01pro"
        };
        UpdateDataGrid();

    }

    private void AddBtn1_OnClick(object? sender, RoutedEventArgs e)
    {
        var myValue = new Application1();
        AddWindow addWindow = new AddWindow(myValue);
        addWindow.ShowDialog(this);
        addWindow.Closed += ((o, args) =>
        {
            if (addWindow.Result)
            {
                UpdateDataGrid();
            }
        });
    }
}
    
