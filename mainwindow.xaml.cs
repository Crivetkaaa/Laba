using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        //login
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
        
        private void sign_in_button_Click(object sender, RoutedEventArgs e)
        {
            String userlogin = logintext.Text;
            String userpassword = passwordtext.Password;

            database db = new database();
            
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `Surname` = @ul AND `Password` = @up", db.get_connection());
            
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = userlogin;
            command.Parameters.Add("@up", MySqlDbType.VarChar).Value = userpassword;

            db.open_connection();
            MySqlCommand command2 = new MySqlCommand("SELECT Должность FROM users WHERE Surname = @ul AND Password = @up", db.get_connection());

            command2.Parameters.Add("@ul", MySqlDbType.VarChar).Value = userlogin;
            command2.Parameters.Add("@up", MySqlDbType.VarChar).Value = userpassword;
            string user_post = Convert.ToString(command2.ExecuteScalar());
            if (user_post == null)
            {
                Console.WriteLine("");
            }
            // выполняем запрос и получаем ответ
            db.close_connection();
            
            if (user_post == "Директор")
            {
                Window_for_big_boss big_boss = new Window_for_big_boss();
                big_boss.Show();
                this.Close();

            }

            else if (user_post == "Заместитель")
            {
                Window_for_mini_boss mini_boss = new Window_for_mini_boss();
                mini_boss.Show();
                Console.WriteLine("Good");
                this.Close();

            }
            else if (user_post == "Секретарь")
            {
                Window_for_not_boss not_boss = new Window_for_not_boss();
                not_boss.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Пользователь не найден");

            }

            /*adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count <= 0)
            {
                MessageBox.Show("Такого пользователя не существует");
            }
            */
        }

        private void passwordtext_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //
            Window_for_ghost any = new Window_for_ghost();
            any.Show();
            this.Close();
        }
    }
}
