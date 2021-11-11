using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CourseWork
{
    /// <summary>
    /// Логика взаимодействия для SortPriceCar.xaml
    /// </summary>
    public partial class SortPriceCar : Page
    {
        public SortPriceCar()
        {
            InitializeComponent();
        }

        private void Price1Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.connection.Open();
            string cmd = "SELECT Car_id AS [Номер автомобиля], Stamp AS Марка, Model AS Модель, Color AS Цвет, Type_car AS Тип, Mileage AS Пробег, " +
                "Year_Release AS [Год выпуска], Price_Day AS [Стоимость в день]  FROM dbo.Cars WHERE(Price_Day <= 100) AND (Price_Day > 0)"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, Manager.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Cars"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            Manager.connection.Close();
        }

        private void Price2Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.connection.Open();
            string cmd = "SELECT Car_id AS [Номер автомобиля], Stamp AS Марка, Model AS Модель, Color AS Цвет, Type_car AS Тип, Mileage AS Пробег, " +
                "Year_Release AS [Год выпуска], Price_Day AS [Стоимость в день]  FROM dbo.Cars WHERE(Price_Day <= 200) AND (Price_Day >= 100)"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, Manager.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Cars"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            Manager.connection.Close();
        }

        private void Price3Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.connection.Open();
            string cmd = "SELECT Car_id AS [Номер автомобиля], Stamp AS Марка, Model AS Модель, Color AS Цвет, Type_car AS Тип, Mileage AS Пробег, " +
                "Year_Release AS [Год выпуска], Price_Day AS [Стоимость в день]  FROM dbo.Cars WHERE(Price_Day <= 300) AND (Price_Day >= 200)"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, Manager.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Cars"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            Manager.connection.Close();
        }

        private void Price4Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.connection.Open();
            string cmd = "SELECT Car_id AS [Номер автомобиля], Stamp AS Марка, Model AS Модель, Color AS Цвет, Type_car AS Тип, Mileage AS Пробег, " +
                "Year_Release AS [Год выпуска], Price_Day AS [Стоимость в день]  FROM dbo.Cars WHERE(Price_Day <= 400) AND (Price_Day >= 300)"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, Manager.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Cars"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            Manager.connection.Close();
        }

        private void Price5Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.connection.Open();
            string cmd = "SELECT Car_id AS [Номер автомобиля], Stamp AS Марка, Model AS Модель, Color AS Цвет, Type_car AS Тип, Mileage AS Пробег, " +
                "Year_Release AS [Год выпуска], Price_Day AS [Стоимость в день]  FROM dbo.Cars WHERE(Price_Day <= 500) AND (Price_Day >= 400)"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, Manager.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Cars"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            Manager.connection.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
    }
}
