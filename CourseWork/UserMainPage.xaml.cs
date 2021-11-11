using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для UserMainPage.xaml
    /// </summary>
    public partial class UserMainPage : Page
    {
        public UserMainPage()
        {
            InitializeComponent();
        }

        private void PriceButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new SortPriceCar());
        }

        private void TypeButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new SortTypeCar());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new StartPage());
        }

        private void FreedomCars_Click(object sender, RoutedEventArgs e)
        {
            Manager.connection.Open();
            string cmd = "SELECT Car_id AS [Номер автомобиля], Stamp AS Марка, Model AS Модель, Color AS Цвет, Type_car AS Тип, Mileage AS Пробег, " +
                "Year_Release AS [Год выпуска], Price_Day AS [Стоимость в день] " +
                " FROM dbo.Cars WHERE (NOT (Car_id IN (SELECT Car_id FROM dbo.Rent)))"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, Manager.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Cars"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            Manager.connection.Close();
        }

        public static string check(string variable) {
            Regex regex = new Regex(@"[A-z0-9]");
            if (!regex.IsMatch(variable))
                return "error";
            else
            return "";

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.connection.Open();
            string error_msg = "";
            if ((error_msg = check(Search_TextBox.Text)) == "") 
            {
                string search_value = Search_TextBox.Text;
                //Поиск
                string Search = "Select Car_id AS [Номер автомобиля], Stamp AS Марка, Model AS Модель, Color AS Цвет, Type_car AS Тип, Mileage AS Пробег, " +
                "Year_Release AS [Год выпуска], Price_Day AS [Стоимость в день] FROM Cars WHERE Model LIKE '%" + search_value + "%'";
                SqlCommand cmd = new SqlCommand(Search, Manager.connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Cars"); // В скобках указываем название таблицы
                dataAdp.Fill(dt);
                DataGrid.ItemsSource = dt.DefaultView; // Сам вывод
                Manager.connection.Close();
            }
        }

        private void MyCars_Click(object sender, RoutedEventArgs e)
       {
            Manager.connection.Open();
            string cmd = String.Format("SELECT dbo.Rent.Rent_id AS [Номер проката]," +
                "dbo.Rent.Car_id AS [Номер автомобиля],dbo.Rent.Date_Start AS[Дата начала],dbo.Rent.Date_End AS[Дата окончания], DATEDIFF(dd, dbo.Rent.Date_Start, dbo.Rent.Date_End) AS [Количество дней], " +
                "dbo.Cars.Price_Day AS[Стоимость в день] FROM dbo.Rent INNER JOIN dbo.Cars ON dbo.Rent.Car_id = dbo.Cars.Car_id WHERE Client_id = @myID");
            SqlCommand command = new SqlCommand(cmd, Manager.connection); 
            command.Parameters.Add("@myID", SqlDbType.Int);
            command.Parameters["@myID"].Value = Manager.myId;
            command.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(command);
            DataTable dt = new DataTable("Rent"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            Manager.connection.Close();
        }

        private void UserRent_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new UserRent());
        }
    }
}
