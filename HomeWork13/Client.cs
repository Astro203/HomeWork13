using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

    

    class Chek
    {


        public string Name{ get; set; }
        public int Summ { get; set; }
        public int IndexClient{ get; set; }
        public int IndexCheck { get; set; }
        
        public Chek(string name, int summ, int indexClient, int indexCheck)
        {
            Name = name;
            Summ = summ;
            IndexClient = indexClient;
            IndexCheck = indexCheck;

       
        }
        public delegate void Operation(string Mess);
        public static void ShowMessage(string Mess)
        {
            MessageBox.Show($"Счет {Mess}");
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
