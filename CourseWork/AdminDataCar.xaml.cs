using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace CourseWork
{
    /// <summary>
    /// Логика взаимодействия для AdminDataCar.xaml
    /// </summary>
    public partial class AdminDataCar : Page
    {
        public AdminDataCar()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddCar());
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new UpdateCar());
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
                    string Delete = "DELETE FROM Cars WHERE Car_id = (@Car_id)";
                    SqlCommand cmd = new SqlCommand(Delete, Manager.connection);
                    SqlParameter Delete_param = new SqlParameter("@Car_id", Delete_TextBox.Text);
                    cmd.Parameters.Add(Delete_param);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Автомобиль удален!!!");
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
            string cmd = "SELECT Car_id AS [Номер автомобиля], Stamp AS Марка, Model AS Модель, Color AS Цвет, Type_car AS Тип, Mileage AS Пробег, " +
                "Year_Release AS [Год выпуска], Price_Day AS [Стоимость в день] FROM dbo.Cars"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, Manager.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Cars"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            DataGrid.ItemsSource = dt.DefaultView; // Сам вывод 
            Manager.connection.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminMainPage());
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
