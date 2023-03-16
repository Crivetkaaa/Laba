using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Laba
{
    /// <summary>
    /// Логика взаимодействия для Window_for_not_boss.xaml
    /// </summary>
    public partial class Window_for_not_boss : Window
    {
        public class GridItem_not
        {
            public string Surname_not { get; set; }
            public string Name_not { get; set; }
            public string Post_not { get; set; }
            public string Adress_not { get; set; }
            public string Phone_not { get; set; }
            public string Worked_Phone_not { get; set; }
            public string Password_not { get; set; }

        }
        public Window_for_not_boss()
        {
            InitializeComponent();
            MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=database");
            conn.Open();
            string cmd = "SELECT * FROM users"; // Из какой таблицы нужен вывод 
            MySqlCommand createCommand = new MySqlCommand(cmd, conn);
            var reader = createCommand.ExecuteReader();

            var items = new List<GridItem_not>();
            while (reader.Read())
            {
                var clientItem_not = new GridItem_not();
                clientItem_not.Surname_not = reader.GetString(1);
                clientItem_not.Name_not = reader.GetString(2);
                clientItem_not.Post_not = reader.GetString(3);
                clientItem_not.Adress_not = reader.GetString(4);
                clientItem_not.Phone_not = reader.GetString(5);
                clientItem_not.Worked_Phone_not = reader.GetString(6);
                clientItem_not.Password_not = reader.GetString(7);


                items.Add(clientItem_not);
            }

            reader.Close();


            ClientsGrid.ItemsSource = items;
        }
    }
}
