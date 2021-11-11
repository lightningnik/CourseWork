using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace CourseWork
{
    /// <summary>
    /// Логика взаимодействия для AdminDatarent.xaml
    /// </summary>
    public partial class AdminDataRent : Page
    {
        public AdminDataRent()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddRent());
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new UpdateRent());
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
                    string Delete = "DELETE FROM Rent WHERE Rent_id = (@Rent_id)";
                    SqlCommand cmd = new SqlCommand(Delete, Manager.connection);
                    SqlParameter Delete_param = new SqlParameter("@Rent_id", Delete_TextBox.Text);
                    cmd.Parameters.Add(Delete_param);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Прокат удален!!!");
                }
                catch 
                {

                    MessageBox.Show("Введите номер проката");
                }
                Manager.connection.Close();
            }
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            Manager.connection.Open();
            string cmd = "SELECT dbo.Rent.Rent_id AS [Номер проката], dbo.Rent.Client_id AS [Номер клиента], " +
                "dbo.Rent.Car_id AS [Номер автомобиля], DATEDIFF(dd, dbo.Rent.Date_Start, dbo.Rent.Date_End) AS [Количество дней], " +
                "dbo.Cars.Price_Day AS[Стоимость в день] FROM dbo.Rent INNER JOIN dbo.Cars ON dbo.Rent.Car_id = dbo.Cars.Car_id"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, Manager.connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Rent"); // В скобках указываем название таблицы
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
