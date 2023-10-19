using System.Collections.Generic;
using System.Data;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace RABOTA_08;

public partial class RepairWindow : Window
{
    private void UpdateDataGrid()
    {
        using (var connection = new MySqlConnection(_connection.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT*FROM `РемонтОборудования`";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RepairEquips.Add(new RepairEquip
                        {
                            Id = reader.GetInt32("ID"),
                            Applic = reader.GetInt32("ЗаявкаIDs"),
                            Staff = reader.GetInt32("СотрудникIDs"),
                            Start = reader.GetDateTime("ДатаНачалаРемонта"),
                            Finish = reader.GetDateTime("ДатаОкончанияРемонта"),
                            Matetial = reader.GetInt32("МатериалIDs"),
                            Money = reader.GetInt32("Цена"),
                            Reason = reader.GetString("ПричинаНеисправности")

                        });
                    }
                }
            }

            connection.Close();
        }

        DataGridRepair.ItemsSource = RepairEquips;
    }

    private List<RepairEquip> RepairEquips { get; set; }
    private MySqlConnectionStringBuilder _connection;

    public RepairWindow()
    {
        InitializeComponent();
        RepairEquips = new List<RepairEquip>();
        _connection = new MySqlConnectionStringBuilder
        {
            Server = "10.10.1.24",
            Database = "pro1_8",
            UserID = "user_01",
            Password = "user01pro"
        };
        UpdateDataGrid();

    }
}