using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMoGu.App.Test
{

    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        //проверка на правильность заполнения очереди
        public void CorrectFillingQueue()
        {
            var queue = new Queue<int>();
            for (int i = 0; i < 10; i++)
                queue.Enqueue(i);
            for (int i = 0; i < 10; i++)
                Assert.AreEqual(i, queue.Dequeue());
        }

        [TestMethod]
        //проверка правильности установки метки на первый элемент
        public void CorrectPointerToTheFirstElement()
        {
            var queue = new Queue<string>();
            queue.Enqueue("aa");
            queue.Enqueue("bb");
            queue.Enqueue("xx");
            Assert.AreEqual("aa", queue.Head.Value);
        }

        [TestMethod]
        //проверка правильности установки метки на последний элемент
        public void CorrectPointerToTheLastElement()
        {
            var queue = new Queue<double>();
            queue.Enqueue(22.4);
            queue.Enqueue(34.65);
            queue.Enqueue(7.998);
            Assert.AreEqual(7.998, queue.Tail.Value);
        }
    }
}
