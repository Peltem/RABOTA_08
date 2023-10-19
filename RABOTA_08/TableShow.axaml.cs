using System.Collections.Generic;
using Avalonia.Controls;
using MySql.Data.MySqlClient;

namespace RABOTA_08;

public partial class TableShow : Window
{
    private void UpdateDataGrid1()
    {
        using (var connection = new MySqlConnection(_connection.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT*FROM `Клиент`";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Clients.Add(new Client
                        {
                            Id = reader.GetInt32("ID"),
                            SurName = reader.GetString("Фамилия"),
                            Name = reader.GetString("Имя"),
                            Number = reader.GetString("НомерТелефона")
                        });
                    }
                }
            }

            connection.Close();
        }

        DataGridClient.ItemsSource = Clients;
    }
    private void UpdateDataGrid2()
    {
        using (var connection = new MySqlConnection(_connection.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT*FROM `Сотрудник`";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Staffs.Add(new Staff
                        {
                            Id = reader.GetInt32("ID"),
                            SurName = reader.GetString("Фамилия"),
                            Name = reader.GetString("Имя"),
                            LastName = reader.GetString("Отчество"),
                            Role = reader.GetInt32("РольIDs")
                        });
                    }
                }
            }

            connection.Close();
        }

        DataGridStaff.ItemsSource = Staffs;
    }

    private List<Client> Clients { get; set; }
    private List<Staff> Staffs { get; set; }
    private MySqlConnectionStringBuilder _connection;

    public TableShow()
    {
        InitializeComponent();
        Clients = new List<Client>();
        Staffs = new List<Staff>();
        _connection = new MySqlConnectionStringBuilder
        {
            Server = "10.10.1.24",
            Database = "pro1_8",
            UserID = "user_01",
            Password = "user01pro"
        };
        UpdateDataGrid1();
        UpdateDataGrid2();

    }
}