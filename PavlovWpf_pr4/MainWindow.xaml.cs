using System.Text;
using System.Text.Json;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PavlovWpf_pr4
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
        private int GetNewId()
        {
            int id = 1;
            while (File.Exists("service_" + id + ".json"))
            {
                id++;
            }
            return id;
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            Service service = (Service)Resources["CurrentService"];

            int id;
            if (!int.TryParse(FindBox.Text, out id))
            {
                MessageBox.Show("Введите число в поле поиска!");
                return;
            }

            string fileName = "service_" + id + ".json";

            if (!File.Exists(fileName))
            {
                MessageBox.Show("Услуга с таким ID не найдена!");
                return;
            }

            string json = File.ReadAllText(fileName);
            Service loaded = JsonSerializer.Deserialize<Service>(json);

            service.Id = loaded.Id;
            service.Name = loaded.Name;
            service.Executor = loaded.Executor;
            service.HourPrice = loaded.HourPrice;
            service.Hours = loaded.Hours;

            MessageBox.Show("Услуга найдена!");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Service service = (Service)Resources["CurrentService"];

           
            if (service.Id == 0)
            {
                service.Id = GetNewId();
            }

            string json = JsonSerializer.Serialize(service);
            string fileName = "service_" + service.Id + ".json";
            File.WriteAllText(fileName, json);

            MessageBox.Show("Данные сохранены в файл " + fileName);
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            Service service = (Service)Resources["CurrentService"];
            service.Id = 0;
            service.Name = "Название услуги";
            service.Executor = "Исполнитель";
            service.HourPrice = 1000;
            service.Hours = 1;
        }
    }
}