using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Laboratorio3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=LAB1504-32\\SQLEXPRESS; Initial Catalog-DEMO_DB;" +
                               "User Id=hugo; Password=123456";

            List<Student> students = new List<Student>();
            try
            {   
                //Cadena de conexión
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                //Comandos de TRANSACT SQL
                SqlCommand command = new SqlCommand("SELECT FROM Student", connection);

                //CONECTADA
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                    {

                    int StudentId = reader.GetInt16("StudentId");
                    string FirstName = reader.GetString("FirstName");
                    string LastName = reader.GetString("LastName");

                    students.Add(new Student { StudentId = StudentId, FirstName = FirstName, LastName = LastName });
    
                    }

                connection.Close();
                dgvDemo.ItemsSource = students;
            }

    }
}