using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13
{
    class Client
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string NumberTel { get; set; }
        public int ID { get; set; }
        public Client(string lastName, string firstName, string middleName, string numberTel, int id)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            NumberTel = numberTel;
            ID = id;
        }
    }

    class Chek : INotifyPropertyChanged
    {
        public string name;
        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.name)));
            }
        }
        public int summ;
        public int Summ
        {
            get { return this.summ; }
            set
            {
                this.summ = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.summ)));
            }
        }
        public int indexClient;
        public int IndexClient
        {
            get { return this.indexClient; }
            set
            {
                this.indexClient = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.indexClient)));
            }
        }
        public int indexCheck;
        public int IndexCheck
        {
            get { return this.indexCheck; }
            set
            {
                this.indexCheck = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.indexCheck)));
            }
        }
        public Chek(string name, int summ, int indexClient, int indexCheck)
        {
            Name = name;
            Summ = summ;
            IndexClient = indexClient;
            IndexCheck = indexCheck;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
            
    }   
    
    class IndexClient
    {
        public int Index { get; set; }
        public IndexClient(int index)
        {
            Index = index;
        }
    }
}
