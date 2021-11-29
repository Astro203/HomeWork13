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
        
        public string dateTime { get; set; }
        
        public string name { get; set; }
        
        public string operation { get; set; }
        
        public Journal(Client name, string operation)
        {
            dateTime = DateTime.Now.ToShortDateString();
            this.name = name.LastName;
            this.operation = operation;
        }
    }
}
