using NUnit.Framework;
using MyQueueLib;

namespace MyQueue.Tests
{
    public class Tests
    {
        [Test]
        public void CreateQueue_ValidQueue_True()
        {
            MyQueue<int> queue = new MyQueue<int>();
            bool expected = true;
            bool actual = queue.CreateQueue(1);
            Assert.AreEqual(expected, actual);
        }
    }
}