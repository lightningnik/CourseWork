
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
namespace CourseWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"DESKTOP-C848VBU\SQLEXPRESS"; //NOTEBOOK-MAX\SQLEXPRESS KOMP\SQLEXPRESS PC-MAX\SQLEXPRESS
            builder.InitialCatalog = "CP";
            builder.IntegratedSecurity = true;
            Manager.connection = new SqlConnection(builder.ConnectionString);
            MainFrame.Navigate(new StartPage());
            Manager.MainFrame = MainFrame;
           
        }
    }
}
