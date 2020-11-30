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

namespace SMoGu.App
{
    public partial class MainForm : Form
    {
        Tuple<int, string> valueX = new Tuple<int, string>(0, "");
        Tuple<int, CurrencyType> valueY = new Tuple<int, CurrencyType>(0, CurrencyType.RUB);

        public readonly Investments investments;
        public readonly Investment investment;

        public MainForm()
        {
            investments = new Investments();
            investment = new Investment(" ",1,CurrencyType.RUB,1);
            //заполнил данные с потолка, ибо не понимаю, как это сделать по другому
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        void CreateGrafic()
        {
            var queueItems = new Queue<double>(); 

            if (valueX.Item1 == 0) throw new ArgumentException();
            if (this.radioButton5.Checked)
            {
                Axis ax = new Axis();
                ax.Title = valueX.Item2.ToString();
                this.chart1.ChartAreas[0].AxisX = ax;
            }
            else if (this.radioButton6.Checked)
            {
                Axis ax = new Axis();
                ax.Title = valueX.Item2.ToString();
                this.chart1.ChartAreas[0].AxisX = ax;
            }
            else if (this.radioButton7.Checked)
            {
                Axis ax = new Axis();
                ax.Title = valueX.Item2.ToString();
                this.chart1.ChartAreas[0].AxisX = ax;
            }

            if (this.radioButton1.Checked)
            {
                Axis ay = new Axis();
                ay.Title = valueY.Item2.ToString();
                this.chart1.ChartAreas[0].AxisY = ay;
            }
            else if (this.radioButton2.Checked)
            {
                Axis ay = new Axis();
                ay.Title = valueY.Item2.ToString();
                this.chart1.ChartAreas[0].AxisY = ay;
            }
            else if (this.radioButton3.Checked)
            {
                Axis ay = new Axis();
                ay.Title = valueY.Item2.ToString();
                this.chart1.ChartAreas[0].AxisY = ay;
            }

            double left = 0, x, y;
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
                x += valueX.Item1;
            }
        }
        private void buttonCreateGrafic(object sender, EventArgs e)
        {
            //CreateHelper()
            CreateGrafic();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            valueY = new Tuple<int, CurrencyType>(0, CurrencyType.USD);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            valueY = new Tuple<int, CurrencyType>(0, CurrencyType.EUR);
        }
           
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            valueY = new Tuple<int, CurrencyType>(0, CurrencyType.CNY);
        }
        void SaveInDocement()
        {

        }

        private void buttonSave(object sender, EventArgs e)
        {
            SaveInDocement();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButtonStepYear(object sender, EventArgs e)
        {
            valueX = new Tuple<int, string>(1, "Year");
        }

        private void radioButtonStepMonth(object sender, EventArgs e)
        {
            valueX = new Tuple<int, string>(1, "Month");
        }

        private void radioButtonStepDay(object sender, EventArgs e)
        {
            valueX = new Tuple<int, string>(1, "Day");
        }

        private void buttonCreateInvesment(object sender, EventArgs e)
        {
            var investmentCreationForm = new InvestmentCreationForm(investments);
            investmentCreationForm.Show();
            //var investmentInfoForm = new InvestmentInfoForm(investment);
            //investmentInfoForm.Show();//открытие другого окна
            this.Hide();//закрыть текущее окно
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonOneDay_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonHalfYear_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonOneMonth_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonOneYear_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonThreeMonth_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}