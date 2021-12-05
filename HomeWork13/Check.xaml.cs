using Newtonsoft.Json;
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
using System.Windows.Shapes;
using Library;

namespace HomeWork13
{
    /// <summary>
    /// Логика взаимодействия для Check.xaml
    /// </summary>
    public partial class Check : Window
    {
        string json = "";
        string file = "Checks.json";
        public Check()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbName.Text == "") { MessageBox.Show("Счет не может быть безымянным"); return; }
                if (tbSumm.Text == "") tbSumm.Text = "0";

                json = File.ReadAllText("Index.json");
                IndexClient indexClient = JsonConvert.DeserializeObject<IndexClient>(json);

                Repository_<Chek> repository = new Repository_<Chek>();
                if (File.Exists(file))
                {
                    json = File.ReadAllText(file);
                    repository.list = JsonConvert.DeserializeObject<BindingList<Chek>>(json);

                    decimal summ = 0;
                    bool flag = decimal.TryParse(tbSumm.Text, out summ);
                    if (flag)
                    {
                        repository.Open(repository.list, new Chek(tbName.Text, summ, indexClient.Index, repository.list.Count));
                    }
                    else
                    {
                        MessageBox.Show("Сумма должна принимать числовле значение"); return;
                    }

                    json = JsonConvert.SerializeObject(repository.list);
                    File.WriteAllText(file, json);
                }
                else
                {
                    List<Chek> list = new List<Chek>();
                    list.Add(new Chek(tbName.Text, Convert.ToInt32(tbSumm.Text), indexClient.Index, 0));
                    json = JsonConvert.SerializeObject(list);
                    File.WriteAllText(file, json);
                }
                //MessageBox.Show("Счет открыт");
                this.Close();
                Chek.Operation message = Chek.ShowMessage;
                message.Invoke("Счет добавлен");
            }
            catch (FileLoadException)
            {
                MessageBox.Show("Ошибка чтения файла");
            }
        }
    }
}
