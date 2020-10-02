using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyQueueLib;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue<int> numbers = new MyQueue<int>();
           // Console.WriteLine(numbers.Count);
            numbers.Enqueue(5);
            numbers.Enqueue(6);
            numbers.Enqueue(7);
            numbers.Enqueue(8);
            foreach (var i in numbers)
                Console.WriteLine(i);
            Console.WriteLine("===========");
            numbers.Dequeue();
            foreach (var i in numbers)
                Console.WriteLine(i);
            numbers.Peek();
            foreach (var i in numbers)
                Console.WriteLine(i);
            Console.WriteLine("===========");
            numbers.ClearQueue();
            foreach (var i in numbers)
                Console.WriteLine(i);
            Console.ReadLine();

        }
    }
}
