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
    /// Логика взаимодействия для Window_working.xaml
    /// </summary>
    public partial class Window_working : Window
    {
        public Window_working()
        {
            InitializeComponent();
        }

        private void del_button_Click(object sender, RoutedEventArgs e)
        {
            String usersurname = userlogin.Text;

            database db = new database();

   
            MySqlCommand command = new MySqlCommand("DELETE FROM `users` WHERE `users`.`Surname` = @us", db.get_connection());
            command.Parameters.Add("@us", MySqlDbType.VarChar).Value = usersurname;

            db.open_connection();
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Сотрудник был удалён");
            else
                MessageBox.Show("Сотрудник не был удалён");

            db.close_connection();
            this.Close();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

///UPDATE `users` SET `Рабочий Телефон` = '43548' WHERE `users`.`Surname` = @ul
///
