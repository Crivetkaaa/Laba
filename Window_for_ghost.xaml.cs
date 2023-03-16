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
using static Laba.Window_for_not_boss;

namespace Laba
{
    /// <summary>
    /// Логика взаимодействия для Window_for_ghost.xaml
    /// </summary>
    /// 
    public class GridItem_ghost
    {
        public string Surname_ghost { get; set; }
        public string Name_ghost { get; set; }
        public string Post_ghost { get; set; }
        public string Worked_Phone_ghost { get; set; }

    }
        public partial class Window_for_ghost : Window
    {
        public Window_for_ghost()
        {
            InitializeComponent();
            MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=database");
            conn.Open();
            string cmd = "SELECT * FROM users"; // Из какой таблицы нужен вывод 
            MySqlCommand createCommand = new MySqlCommand(cmd, conn);
            var reader = createCommand.ExecuteReader();

            var items = new List<GridItem_ghost>();
            while (reader.Read())
            {
                var clientItem_ghost = new GridItem_ghost();
                clientItem_ghost.Surname_ghost = reader.GetString(1);
                clientItem_ghost.Name_ghost = reader.GetString(2);
                clientItem_ghost.Post_ghost = reader.GetString(3);
                clientItem_ghost.Worked_Phone_ghost = reader.GetString(6);


                items.Add(clientItem_ghost);
            }

            reader.Close();


            ClientsGrid.ItemsSource = items;
        }
    }
}
