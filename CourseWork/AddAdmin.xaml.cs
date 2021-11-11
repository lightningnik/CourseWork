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
    /// Логика взаимодействия для AddAdmin.xaml
    /// </summary>
    public partial class AddAdmin : Page
    {
        public AddAdmin()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (Surname_TextBox.Text == "" || Name_TextBox.Text == "" || Patronymic_TextBox.Text == "" || Drive_experience_TextBox.Text == "" || Date_of_Birth_TextBox.Text == "" || textBox_login.Text == "" || password.Password == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля!!!");
            }
            else
            {
                try
                {
                    Manager.connection.Open();
                    string registration = "insert into Administration VALUES(@Surname_value, @Name_value, @Patronymic_value, @Experience_years_value, @Date_of_Birth_value, @login_value, @passwd_value )";
                    SqlCommand cmd = new SqlCommand(registration, Manager.connection);
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
                    SqlParameter login_param = new SqlParameter("@login_value", textBox_login.Text);
                    cmd.Parameters.Add(login_param);
                    SqlParameter passwd_param = new SqlParameter("@passwd_value", password.Password);
                    cmd.Parameters.Add(passwd_param);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Администратор зарегистрирован!!!");
                    Manager.MainFrame.Navigate(new AdminDataAdmin());
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

            Manager.MainFrame.Navigate(new AdminDataAdmin());
        }
    }
}
