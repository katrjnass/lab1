using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQueueLib
{
    public class Item<T>
    {
        public T data { get; set; }
        public Item<T> next { get; set; }
        public Item<T>  previous { get; set; }
        public Item() { }
        public Item(T data)
        {
            this.data = data;
        }
       
    }
}
