﻿using System;
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
    /// Логика взаимодействия для UpdateCar.xaml
    /// </summary>
    public partial class UpdateCar : Page
    {
        public UpdateCar()
        {
            InitializeComponent();
        }

        private void UpdteButton_Click(object sender, RoutedEventArgs e)
        {
            if (Stamp_TextBox.Text == "" || Model_TextBox.Text == "" || Color_TextBox.Text == "" || Year_release_TextBox.Text == "" || Price_day_TextBox.Text == "" || Mileage_TextBox.Text == "" || Type_car_TextBox.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля для регистрации!!!");
            }
            else
            {
                try
                {
                    Manager.connection.Open();
                    string registration = "Update Cars SET Stamp = @Stamp_value, Model = @Model_value, Color = @Color_value, Year_release = @Year_release_value, Price_day = @Price_day_value, Mileage = @Mileage_value, Type_car = @Type_car_value  WHERE (Car_id = @ID_value)";
                    SqlCommand cmd = new SqlCommand(registration, Manager.connection);
                    SqlParameter ID_param = new SqlParameter("@ID_value", Id_TextBox.Text);
                    cmd.Parameters.Add(ID_param);
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
                    MessageBox.Show("Данные обновлены!!!");
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
