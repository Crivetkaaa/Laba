using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Window_add_employee.xaml
    /// </summary>
    public partial class Window_add_employee : Window
    {

        public Window_add_employee()
        {
            InitializeComponent();
        }

        private void registrationuser_Click(object sender, RoutedEventArgs e)
        {
            String userlogin = surnametext.Text;
            String username = nametext.Text;
            String post = postlist.Text;
            String workphone = workphonetext.Text;
            String personalphone = personalphonetext.Text;
            String address = addresstext.Text;
            String password = passwordtext.Text;

            database db = new database();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`Surname`, `Имя Отчество`, `Должность`, `Адрес`, `Личный Телефон`, `Рабочий Телефон`, `Password`) VALUES (@us, @un, @upost, @ua, @ulp, @uwp, @up);", db.get_connection());
            command.Parameters.Add("@us", MySqlDbType.VarChar).Value = userlogin;
            command.Parameters.Add("@un", MySqlDbType.Text).Value = username;
            command.Parameters.Add("@upost", MySqlDbType.VarChar).Value = post;
            command.Parameters.Add("@ua", MySqlDbType.Text).Value = address;
            command.Parameters.Add("@ulp", MySqlDbType.Text).Value = personalphone;
            command.Parameters.Add("@uwp", MySqlDbType.Text).Value = workphone;
            command.Parameters.Add("@up", MySqlDbType.VarChar).Value = password;

            db.open_connection();
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Сотрудник был внесен");
            else
                MessageBox.Show("Сотрудник не был внесен");

            db.close_connection();
            this.Close();
        }


        private void surnametext_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void nametext_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void posttext_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void workphonetext_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void personalphonetext_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void addresstext_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void passwordtext_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
