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
    /// Логика взаимодействия для AdminMainPage.xaml
    /// </summary>
    public partial class AdminMainPage : Page
    {
        public AdminMainPage()
        {
            InitializeComponent();
        }

        private void FreedomCars_Click(object sender, RoutedEventArgs e)
        {
            Manager.connection.Open();
            string cmd = "SELECT Car_id AS [Номер автомобиля], Stamp AS Марка, Model AS Модель, Color AS Цвет, Type_car AS Тип, Mileage AS Пробег, " +
                "Year_Release AS [Год выпуска], Price_Day AS [Стоимость в день]  FROM dbo.Cars WHERE (NOT (Car_id IN (SELECT Car_id FROM dbo.Rent)))"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, Manager.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Cars"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            Manager.connection.Close();
        }

        private void SortPrice_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new SortPriceCar());
        }

        private void SortType_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new SortTypeCar());
        }

       
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new StartPage());
        }

        private void DataTableClients_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminDataUser());
        }

        private void DataTablesCars_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminDataCar());
        }

        private void DataTablesRent_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminDataRent());
        }

        private void DataTablesAdministration_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminDataAdmin());
        }
    }
}
