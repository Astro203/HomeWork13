using System;
using System.Collections.Generic;
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

    class Chek
    {
        public string Name { get; set; }
        public int Summ { get; set; }
        public int IndexClient { get; }
        public int IndexCheck { get; set; }
        public Chek(string name, int summ, int indexClient, int indexCheck)
        {
            Name = name;
            Summ = summ;
            IndexClient = indexClient;
            IndexCheck = indexCheck;
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
