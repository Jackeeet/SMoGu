using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Smogu
{
    public partial class Form1 : Form
    {
        Tuple<int, string> valueX = new Tuple<int, string>(1, "");
        Tuple<int, string> valueY = new Tuple<int, string>(0, "");
        int MaxCountForGrafic = 12; // 12 месяцев
        //для valueY.Item1 можно сделать очередь, то есть при нажатии на кнопку выбора валюты будет
        //браться опредленная очередь

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

        private void buttonCreateGrafic(object sender, EventArgs e)
        {
            var queueItems = new Queue<double>(); // очередь данных отношения валют
            queueItems.Enqueue(1);    //проба
            queueItems.Enqueue(3);    //проба
            queueItems.Enqueue(15);   //проба
            queueItems.Enqueue(5);    //проба
            queueItems.Enqueue(3);    //проба
            queueItems.Enqueue(3);    //проба
            queueItems.Enqueue(15);   //проба
            queueItems.Enqueue(5);    //проба
            queueItems.Enqueue(3);    //проба
            queueItems.Enqueue(5);    //проба
            queueItems.Enqueue(3);    //проба
            queueItems.Enqueue(3);    //проба
            queueItems.Enqueue(15);   //проба
            queueItems.Enqueue(5);    //проба
            queueItems.Enqueue(3);    //проба

            if (valueX.Item1 == 0) throw new ArgumentException();

            if (this.radioButton1.Checked)
            {
                Axis ax = new Axis();
                ax.Title = valueY.Item2;
                this.chart1.ChartAreas[0].AxisY = ax;
            }
            else if (this.radioButton2.Checked)
            {
                Axis ax = new Axis();
                ax.Title = valueY.Item2;
                this.chart1.ChartAreas[0].AxisY = ax;
            }
            else if (this.radioButton3.Checked)
            {
                Axis ax = new Axis();
                ax.Title = valueY.Item2;
                this.chart1.ChartAreas[0].AxisY = ax;
            }
            double left = 0, x, y;
            this.chart1.Series[0].Points.Clear();
            x = left;
            while (x <= MaxCountForGrafic)
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
                x += valueX.Item1;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            valueY = new Tuple<int, string>(0, "USD");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            valueY = new Tuple<int, string>(0, "EUR");
        }
           
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            valueY = new Tuple<int, string>(0, "CNY");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данная функция доступна только в расширенной версии");
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
