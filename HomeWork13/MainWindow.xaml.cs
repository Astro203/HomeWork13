﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Library;

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
                try
                {
                    json = File.ReadAllText(fileCLients);
                    clients = JsonConvert.DeserializeObject<List<Client>>(json);
                }
                catch (FileLoadException)
                {
                    MessageBox.Show("Ошибка чтения файла");
                }
            }
            lvClients.ItemsSource = clients;
        }

        private void btTranslate_Click(object sender, RoutedEventArgs e)
        {
            Translate translate = new Translate();
            translate.Show();
        }
        private void btDel_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(fileCheck))
            {
                try
                {
                    Repository_<Chek> repository = new Repository_<Chek>();
                    json = File.ReadAllText(fileCheck);
                    repository.list = JsonConvert.DeserializeObject<BindingList<Chek>>(json);
                    repository.Close(find(repository.list, lvClients.SelectedIndex), lvCheks.SelectedIndex);
                    json = JsonConvert.SerializeObject(repository.list);
                    File.WriteAllText(fileCheck, json);
                    //MessageBox.Show("Счет закрыт");

                    lvCheks.ItemsSource = repository.list;
                    var clients = new List<Client>();
                    json = File.ReadAllText(fileCLients);
                    clients = JsonConvert.DeserializeObject<List<Client>>(json);

                    List<Journal> journal = new List<Journal>();
                    journal.Add(new Journal(clients[lvClients.SelectedIndex], "счет закрыт"));

                    lvJournal.ItemsSource = journal;

                    Chek.Operation message = Chek.ShowMessage;
                    message.Invoke("Cчет удален");
                }
                catch (FileLoadException)
                {
                    MessageBox.Show("Ошибка чтения файла");
                }
            }          
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
                try
                {
                    json = File.ReadAllText(fileCheck);
                    List<Chek> cheks = new List<Chek>();
                    cheks = JsonConvert.DeserializeObject<List<Chek>>(json);
                    JsonConvert.SerializeObject(cheks);
                    lvCheks.ItemsSource = cheks.Where(findID);
                }
                catch (FileLoadException)
                {
                    MessageBox.Show("Ошибка чтения файла");
                }
            }
            
            //файл для хранения индекса выделенной строки с клиентами
            if(File.Exists("Index.json"))
            {
                try
                {
                    json = File.ReadAllText("Index.json");
                    IndexClient indexClient = new IndexClient(lvClients.SelectedIndex);
                    json = JsonConvert.SerializeObject(indexClient);
                    File.WriteAllText("Index.json", json);
                }
                catch (FileLoadException)
                {
                    MessageBox.Show("Ошибка чтения файла");
                }
            }
            else
            {
                IndexClient indexClient = new IndexClient(0);
                json = JsonConvert.SerializeObject(indexClient);
                File.WriteAllText("Index.json", json);
            }
        }

        private BindingList<Chek> find(BindingList<Chek> list, int Index)
        {
            BindingList<Chek> newList = new BindingList<Chek>();
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
