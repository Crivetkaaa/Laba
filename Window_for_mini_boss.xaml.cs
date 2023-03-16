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
    /// Логика взаимодействия для Window_for_mini_boss.xaml
    /// </summary>
    /// 
    public class GridItem_mini
    {
        public string Surname_mini { get; set; }
        public string Name_mini { get; set; }
        public string Post_mini { get; set; }
        public string Adress_mini { get; set; }
        public string Phone_mini { get; set; }
        public string Worked_Phone_mini { get; set; }
        public string Password_mini { get; set; }





    }
    public partial class Window_for_mini_boss : Window
    {
        public Window_for_mini_boss()
        {
            InitializeComponent();

            MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=database");
            conn.Open();
            string cmd = "SELECT * FROM users"; // Из какой таблицы нужен вывод 
            MySqlCommand createCommand = new MySqlCommand(cmd, conn);
            var reader = createCommand.ExecuteReader();

            var items = new List<GridItem_mini>();
            while (reader.Read())
            {
                var clientItem_mini = new GridItem_mini();
                clientItem_mini.Surname_mini = reader.GetString(1);
                clientItem_mini.Name_mini = reader.GetString(2);
                clientItem_mini.Post_mini = reader.GetString(3);
                clientItem_mini.Adress_mini = reader.GetString(4);
                clientItem_mini.Phone_mini = reader.GetString(5);
                clientItem_mini.Worked_Phone_mini = reader.GetString(6);
                clientItem_mini.Password_mini = reader.GetString(7);


                items.Add(clientItem_mini);
            }

            reader.Close();


            ClientsGrid.ItemsSource = items;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Window_add_employee not_boss = new Window_add_employee();
            not_boss.Show();
        }
    }
}
