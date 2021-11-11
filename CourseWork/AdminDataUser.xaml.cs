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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;


namespace CourseWork
{
    /// <summary>
    /// Логика взаимодействия для AdminDataUser.xaml
    /// </summary>
    public partial class AdminDataUser : Page
    {
        public AdminDataUser()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new UserRegistration());
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new UpdateUser());
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (Delete_TextBox.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните поле для удаления!!!");
            }
            else
            {
                try
                {
                    Manager.connection.Open();
                    string Delete = "DELETE FROM Clients WHERE Client_id = (@Client_id)";
                    SqlCommand cmd = new SqlCommand(Delete, Manager.connection);
                    SqlParameter Delete_param = new SqlParameter("@Client_id", Delete_TextBox.Text);
                    cmd.Parameters.Add(Delete_param);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Пользователь удален!!!");
                }
                catch (SqlException er)
                {

                    MessageBox.Show(er.Number + " " + er.Message);
                }
                Manager.connection.Close();
            }
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            Manager.connection.Open();
            string cmd = "SELECT Client_id AS [Номер клиента], Surname AS Фамилия, Name AS Имя, Patronymic AS Отчество, " +
                "Date_Of_Birth AS [Дата рождения], Driver_license AS [Водительское удостоверение], Experience_years AS [Стаж вождения], " +
                "Login AS Логин, Password AS Пароль FROM     dbo.Clients"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, Manager.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Clients"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            Manager.connection.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminMainPage());
        }
    }
}
