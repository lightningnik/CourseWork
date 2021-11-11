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
    /// Логика взаимодействия для AddCar.xaml
    /// </summary>
    public partial class AddCar : Page
    {
        public AddCar()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (Stamp_TextBox.Text == "" || Model_TextBox.Text == "" || Color_TextBox.Text == "" || Year_release_TextBox.Text == "" || Price_day_TextBox.Text == "" || Mileage_TextBox.Text == "" || Type_car_TextBox.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля!!!");
            }
            else
            {
                try
                {
                    Manager.connection.Open();
                    string registration = "insert into Cars VALUES(@Stamp_value, @Model_value, @Color_value, @Year_release_value, @Price_day_value, @Mileage_value, @Type_car_value )";
                    SqlCommand cmd = new SqlCommand(registration, Manager.connection);
                    SqlParameter Stamp_param = new SqlParameter("@Stamp_value", Stamp_TextBox.Text);
                    cmd.Parameters.Add(Stamp_param);
                    SqlParameter Model_param = new SqlParameter("@Model_value", Model_TextBox.Text);
                    cmd.Parameters.Add(Model_param);
                    SqlParameter Color_param = new SqlParameter("@Color_value", Color_TextBox.Text);
                    cmd.Parameters.Add(Color_param);
                    SqlParameter Year_release_param = new SqlParameter("@Year_release_value", Year_release_TextBox.Text);
                    cmd.Parameters.Add(Year_release_param);
                    SqlParameter Price_day_param = new SqlParameter("@Price_day_value", Price_day_TextBox.Text);
                    cmd.Parameters.Add(Price_day_param);
                    SqlParameter Mileage_param = new SqlParameter("@Mileage_value", Mileage_TextBox.Text);
                    cmd.Parameters.Add(Mileage_param);
                    SqlParameter Type_car_param = new SqlParameter("@Type_car_value", Type_car_TextBox.Text);
                    cmd.Parameters.Add(Type_car_param);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Автомобиль зарегистрирован!!!");
                    Manager.MainFrame.Navigate(new AdminDataCar());
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
            Manager.MainFrame.Navigate(new AdminDataCar());
        }
    }
}
