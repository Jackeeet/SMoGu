using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smogu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var queueItems = new Queue<int>(); // очередь данных отношения валют
            queueItems.Enqueue(1);    //проба
            queueItems.Enqueue(2);    //проба
            queueItems.Enqueue(3);    //проба
            queueItems.Enqueue(4);    //проба
            queueItems.Enqueue(5);    //проба
            queueItems.Enqueue(10);   //проба
            queueItems.Enqueue(15);   //проба
            queueItems.Enqueue(20);   //проба
            queueItems.Enqueue(5);    //проба
            queueItems.Enqueue(10);   //проба
            queueItems.Enqueue(10);   //проба
            queueItems.Enqueue(0);    //проба
            queueItems.Enqueue(3);    //проба

            double left = 10, right = 10, step = 0.5, x, y;
            this.chart1.Series[0].Points.Clear();
            x = left;
            while (true)
            {
                try
                {
                    y = queueItems.Dequeue();
                }
                catch (InvalidOperationException)
                {
                    break;
                }
                
                this.chart1.Series[0].Points.AddXY(x, y);
                x += step;
            }
        }

        //чтобы работало сейчас, потом Рома затащит другое
        public class QueueItem
        {
            public int Value { get; set; }
            public QueueItem Next { get; set; }
        }

        public class Queue
        {
            QueueItem head;
            QueueItem tail;

            public void Enqueue(int value)
            {
                if (head == null)
                    tail = head = new QueueItem { Value = value, Next = null };
                else
                {
                    var item = new QueueItem { Value = value, Next = null };
                    tail.Next = item;
                    tail = item;
                }
            }

            public int Dequeue()
            {
                if (head == null) throw new InvalidOperationException();
                var result = head.Value;
                head = head.Next;
                if (head == null)
                    tail = null;
                return result;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
