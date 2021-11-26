using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HomeWork13
{
    class Journal
    {
        
        public DateTime dateTime { get; set; }
        
        public string name { get; set; }
        
        public string operation { get; set; }
        
        public Journal(Client name, string operation)
        {
            this.name = name.LastName;
            this.operation = operation;
        }
    }
}
