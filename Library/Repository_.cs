using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    interface IRepository<T>
    {
        void Open(BindingList<T> list, T Value);
        void Close(BindingList<T> Value, int Index);
        void Translate(decimal summ, decimal summ1, decimal summ2);
    }
 
    
    public class Repository_<T> : IRepository<T>
    {
        public BindingList<T> list { get; set; }
        public decimal summ { get; set; }
        public decimal summ1 { get; set; }
        public decimal summ2 { get; set; }


        public void Open(BindingList<T> list, T Value)
        {
            list.Add(Value);
            this.list = list;
        }
        public void Close(BindingList<T> Value, int CheckIndex)
        {
            Value.RemoveAt(CheckIndex);
            list = Value;
        }
        public void Translate(decimal summ, decimal summ1, decimal summ2)
        {
            this.summ2 = summ + summ1;
            this.summ1 = summ1 - summ;
        }
    }
}
