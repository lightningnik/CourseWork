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
    /// Логика взаимодействия для UpdateUser.xaml
    /// </summary>
    public partial class UpdateUser : Page
    {
        public UpdateUser()
        {
            InitializeComponent();
        }

        private void UpdteButton_Click(object sender, RoutedEventArgs e)
        {
            if (Surname_TextBox.Text == "" || Name_TextBox.Text == "" || Patronymic_TextBox.Text == "" || Drive_experience_TextBox.Text == "" || Date_of_Birth_TextBox.Text == "" || Driver_license_TextBox.Text == "" || textBox_login.Text == "" || password.Password == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля для регистрации!!!");
            }
            else
            {
                try
                {
                    Manager.connection.Open();
                    string registration = "Update Cars SET Stamp = @Stamp_value, Model = @Model_value, Color = @Color_value, Year_release = @Year_release_value, Price_day = @Price_day_value, Mileage = @Mileage_value, Type_car = @Type_car_value  WHERE (Client_id = @ID_value)";
                    SqlCommand cmd = new SqlCommand(registration, Manager.connection);
                    SqlParameter ID_param = new SqlParameter("@ID_value", Id_TextBox.Text);
                    SqlParameter Surname_param = new SqlParameter("@Surname_value", Surname_TextBox.Text);
                    cmd.Parameters.Add(Surname_param);
                    SqlParameter Name_param = new SqlParameter("@Name_value", Name_TextBox.Text);
                    cmd.Parameters.Add(Name_param);
                    SqlParameter Patronymic_param = new SqlParameter("@Patronymic_value", Patronymic_TextBox.Text);
                    cmd.Parameters.Add(Patronymic_param);
                    SqlParameter Drive_experience_param = new SqlParameter("@Experience_years_value", Drive_experience_TextBox.Text);
                    cmd.Parameters.Add(Drive_experience_param);
                    SqlParameter Date_of_Birth_param = new SqlParameter("@Date_of_Birth_value", Date_of_Birth_TextBox.Text);
                    cmd.Parameters.Add(Date_of_Birth_param);
                    SqlParameter Driver_license_param = new SqlParameter("@Driver_license_value", Driver_license_TextBox.Text);
                    cmd.Parameters.Add(Driver_license_param);
                    SqlParameter login_param = new SqlParameter("@login_value", textBox_login.Text);
                    cmd.Parameters.Add(login_param);
                    SqlParameter passwd_param = new SqlParameter("@passwd_value", password.Password);
                    cmd.Parameters.Add(passwd_param);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные обновлены!!!");
                    Manager.MainFrame.Navigate(new AdminDataUser());
                }
                catch (SqlException er)
                {

                    MessageBox.Show(er.Number + " " + er.Message);
                }
                Manager.connection.Close();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminDataUser());
        }
    }
}
