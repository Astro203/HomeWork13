using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HomeWork13
{
    interface IRepository<T>
    {
        void Open(BindingList<T> list, T Value);
        void Close(BindingList<T> Value, int Index);
        void Translate(int summ, int summ1, int summ2);
    }
    class Repository<T> : IRepository<T>
    {
        public BindingList<T> list { get; set; }
        public int summ { get; set; }
        public int summ1 { get; set; }
        public int summ2 { get; set; }
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
        public void Translate(int summ, int summ1, int summ2)
        {        
            this.summ2 = summ + summ1;
            this.summ1 = summ1 - summ;
        }
    }
}
