using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace HomeWork13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string json = "";
        string fileCLients = "Clients.json";
        string fileCheck = "Checks.json";
        public MainWindow()
        {
            InitializeComponent();
            
            List<Client> clients = new List<Client>();
            if (!File.Exists(fileCLients))
            {
                for (int i = 0; i < 10; i++)
                {
                    clients.Add
                        (new Client(
                            $"Фамилия_{i}",
                            $"Имя_{i}",
                            $"Отчество_{i}",
                            $"8999999999{i}",
                            i
                        ));
                }
                json = JsonConvert.SerializeObject(clients);
                File.WriteAllText(fileCLients, json);
            } else
            {
                json = File.ReadAllText(fileCLients);
                clients = JsonConvert.DeserializeObject<List<Client>>(json);
            }
            lvClients.ItemsSource = clients;
        }

        private void btTranslate_Click(object sender, RoutedEventArgs e)
        {
            Translate translate = new Translate();
            translate.Show();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            Check check = new Check();
            check.Show();
        }

        private void lvClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //json файл для хранения счетов клиентов
            if (File.Exists(fileCheck))
            {
                json = File.ReadAllText(fileCheck);
                List<Chek> cheks = new List<Chek>();
                cheks = JsonConvert.DeserializeObject<List<Chek>>(json);
                JsonConvert.SerializeObject(cheks);
                lvCheks.ItemsSource = cheks.Where(findID);
            }
            
            //файл для хранения индекса выделенной строки с клиентами
            if(File.Exists("Index.json"))
            {
                json = File.ReadAllText("Index.json");
                IndexClient indexClient = new IndexClient(lvClients.SelectedIndex);
                json = JsonConvert.SerializeObject(indexClient);
                File.WriteAllText("Index.json", json);
            }
            else
            {
                IndexClient indexClient = new IndexClient(0);
                json = JsonConvert.SerializeObject(indexClient);
                File.WriteAllText("Index.json", json);
            }
        }

        private void btDel_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(fileCheck))
            {
                Repository<Chek> repository = new Repository<Chek>();
                json = File.ReadAllText(fileCheck);
                repository.list = JsonConvert.DeserializeObject<List<Chek>>(json);
                repository.Close(find(repository.list, lvClients.SelectedIndex), lvCheks.SelectedIndex);
                json = JsonConvert.SerializeObject(repository.list);
                File.WriteAllText(fileCheck, json);
                MessageBox.Show("Счет закрыт");
            }
        }

        private List<Chek> find(List<Chek> list, int Index)
        {
            List<Chek> newList = new List<Chek>();
            foreach(var item in list)
            {
                if(item.IndexClient == Index)
                {
                    newList.Add(item);
                }
            }
            return newList;
        }

        private bool findID(Chek arg)
        {
            return arg.IndexClient == (lvClients.SelectedItem as Client).ID;
        }
    }
}
