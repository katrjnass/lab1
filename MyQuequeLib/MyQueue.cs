using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MyQueueLib
{
    public class MyQueue<T> : IEnumerable<T>
    {
        private Item<T> head;
        private Item<T> tail;
        public int size { get; private set; } = 0;
         
        public MyQueue(T data)
        {
            CreateQueue(data);
        }
        public MyQueue(int capacity)
        {
            size = capacity;
        }
        public MyQueue() { }
        public bool CreateQueue(T data)
        {
            head = new Item<T>(data);
            tail = head;
            size = 1;
            return true;
        }
        public bool Enqueue(T data)
        {
            try
            {
                if (size == 0)
                {
                    CreateQueue(data);
                    return true;
                }
                var temp = new Item<T>(data);
                temp.previous = tail;
                tail.next = temp;
                tail = temp;
                size++;
            }
            catch
            {
                return false;
            }
            return true;
        }
        
        public T Dequeue()
        {
            if (size > 0)
            {
                var temp = head.data;
                head = head.next;
                head.previous = null;
                size--;
                return temp;
            }
            else
                throw new InvalidOperationException("Очередь пустая"); 
        }
        
        public T Peek()
        {
            if (head != null)
                return head.data;
            else
                throw new InvalidOperationException("Очередь пустая");
        }
        
        public bool ClearQueue()
        {
            try
            {
                tail = head = null;
                size = 0;
            }
            catch
            {
                return false;
            }
            return true;
        }
       
        public MyQueueEnum<T> GetEnumerator()
        {
            return new MyQueueEnum<T>(head);
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }


    }
    public class MyQueueEnum<T> : IEnumerator<T>
    {
        public Item<T> head;
        public Item<T> position = new Item<T>();
        public MyQueueEnum(Item<T> data)
        {
            head = data;
            position.next = head;
        }

        public T Current
        {
            get
            {
                try
                {
                    return position.data;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        void IDisposable.Dispose() { }

        public bool MoveNext()
        {
            position = position.next;
            return position != null;
        }

        public void Reset()
        {
            position.next = head;
        }
    }
}
