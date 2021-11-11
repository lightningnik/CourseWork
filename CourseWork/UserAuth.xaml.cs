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
using System.Data.Sql;


namespace CourseWork
{
    /// <summary>
    /// Логика взаимодействия для UserAuth.xaml
    /// </summary>
    public partial class UserAuth : Page
    {
        public UserAuth()
        {
            InitializeComponent();
        }

        private void Log_in_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_login.Text.Length > 0) // проверяем введён ли логин     
            {
                if (password.Password.Length > 0) // проверяем введён ли пароль         
                {             // ищем в базе данных пользователя с такими данными  
            Manager.connection.Open();
                    string authorization = String.Format ("SELECT Client_id, login, password FROM [dbo].[Clients] WHERE [login] = @login_value AND [password] = @passwd_value");
            SqlCommand command = new SqlCommand(authorization, Manager.connection);
            SqlParameter login_param = new SqlParameter("@login_value", textBox_login.Text);
            command.Parameters.Add(login_param);
            SqlParameter passwd_param = new SqlParameter("@passwd_value", password.Password);
            command.Parameters.Add(passwd_param);
            SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Manager.myId = Convert.ToInt32(reader.GetValue(0));
                    }
                    if (reader.HasRows) // если такая запись существует       
                    {
                        Manager.MainFrame.Navigate(new UserMainPage());
                    }

                    else MessageBox.Show("Пользователь не найден"); // выводим ошибку  
                }
                else MessageBox.Show("Введите пароль"); // выводим ошибку    
            }
            else MessageBox.Show("Введите логин"); // выводим ошибку 
            Manager.connection.Close();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new UserRegistration());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new StartPage());
        }
    }
}
