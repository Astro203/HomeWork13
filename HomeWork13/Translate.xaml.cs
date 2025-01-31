﻿using Newtonsoft.Json;
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
using System.Windows.Shapes;
using Library;

namespace HomeWork13
{
    /// <summary>
    /// Логика взаимодействия для Translate.xaml
    /// </summary>
    public partial class Translate : Window
    {
        string fileClient = "Clients.json";
        string fileChek = "Checks.json";
        string fileIndex = "Index.json";
        string json = "";
        int index;
        List<Chek> newList = new List<Chek>();

        public Translate()
        {
            InitializeComponent();

            if (File.Exists(fileIndex))
            {
                try
                {
                    json = File.ReadAllText("Index.json");
                    IndexClient indexClient = JsonConvert.DeserializeObject<IndexClient>(json);
                    index = indexClient.Index;
                    if (File.Exists(fileChek))
                    {
                        List<Chek> cheks = new List<Chek>();
                        json = File.ReadAllText(fileChek);
                        cheks = JsonConvert.DeserializeObject<List<Chek>>(json);
                        foreach (var item in cheks)
                        {
                            if (item.IndexClient == indexClient.Index)
                            {
                                cbCheck1.Items.Add(item.Name);
                                cbCheck2.Items.Add(item.Name);

                            }
                        }
                    }
                }
                catch (FileLoadException)
                {
                    MessageBox.Show("Ошибка чтения файла");
                }
            }
        }

        private void btTranslate_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(tbSumm.Text) > Convert.ToInt32(tbSumm1.Text))
            {
                MessageBox.Show("Сумма перевода превышает имеющуюся");
                return;
            }
            Repository_<Chek> repository = new Repository_<Chek>();

            decimal summ = 0;
            bool flag = decimal.TryParse(tbSumm.Text, out summ);
            if (flag)
            {
                repository.Translate(Convert.ToInt32(tbSumm.Text), Convert.ToInt32(tbSumm1.Text), Convert.ToInt32(tbSumm2.Text));
            }
            else
            {
                MessageBox.Show("Сумма должна быть числом"); return;
            }

            try
            {
                List<Chek> cheks = new List<Chek>();
                json = File.ReadAllText(fileChek);
                cheks = JsonConvert.DeserializeObject<List<Chek>>(json);
                cheks
                    .FindAll(x => x.IndexClient == index && x.IndexCheck == cbCheck1.SelectedIndex)
                    .ForEach(s => s.Summ = repository.summ1);
                cheks
                    .FindAll(x => x.IndexClient == index && x.IndexCheck == cbCheck2.SelectedIndex)
                    .ForEach(s => s.Summ = repository.summ2);
                json = JsonConvert.SerializeObject(cheks);
                File.WriteAllText(fileChek, json);

                this.Close();

                Chek.Operation message = Chek.ShowMessage;
                message.Invoke("Выполнен перевод между счетами");
            }
            catch (FileLoadException)
            {
                MessageBox.Show("Ошибка чтения файла");
            }
        }
    }
}
