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
using System.Windows.Shapes;

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
            if (tbName.Text == "") { MessageBox.Show("Счет не может быть безымянным"); return; }
            if (tbSumm.Text == "") tbSumm.Text = "0";

            json = File.ReadAllText("Index.json");
            IndexClient indexClient = JsonConvert.DeserializeObject<IndexClient>(json);

            Repository<Chek> repository = new Repository<Chek>();
            if(File.Exists(file))
            {
                json = File.ReadAllText(file);
                repository.list = JsonConvert.DeserializeObject<List<Chek>>(json);
                repository.Open(repository.list, new Chek(tbName.Text, Convert.ToInt32(tbSumm.Text), indexClient.Index, repository.list.Count));
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
            MessageBox.Show("Счет открыт");
            this.Close();
        }
    }
}
