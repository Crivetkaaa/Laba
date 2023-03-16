using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Window_for_big_boss.xaml
    /// </summary>
    /// 

    public class GridItem
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Post { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Worked_Phone { get; set; }
        public string Password { get; set; }





    }

    public partial class Window_for_big_boss : Window
    {
        public Window_for_big_boss()
        {
            InitializeComponent();


            MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=database");
            conn.Open();
            string cmd = "SELECT * FROM users"; // Из какой таблицы нужен вывод 
            MySqlCommand createCommand = new MySqlCommand(cmd, conn);
            var reader = createCommand.ExecuteReader();

            var items = new List<GridItem>();
            while (reader.Read())
            {
                var clientItem = new GridItem();
                clientItem.Surname = reader.GetString(1);
                clientItem.Name = reader.GetString(2);
                clientItem.Post = reader.GetString(3);
                clientItem.Adress = reader.GetString(4);
                clientItem.Phone = reader.GetString(5);
                clientItem.Worked_Phone = reader.GetString(6);
                clientItem.Password = reader.GetString(7);


                items.Add(clientItem);
            }

            reader.Close();


            ClientsGrid.ItemsSource = items;
        }

        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            Window_add_employee not_boss = new Window_add_employee();
            not_boss.Show();
        }

        private void change_button_Click(object sender, RoutedEventArgs e)
        {
            Window_change_info not_boss = new Window_change_info();
            not_boss.Show();
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            Window_working not_boss = new Window_working();
            not_boss.Show();
        }
    }
}
