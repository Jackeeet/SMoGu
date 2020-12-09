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
        private CurrencyType Y;
        public readonly Investments investments;
        public MainForm()
        {   
            InitializeComponent();

            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // эта штука хранит варианты инвестиций и должна быть инициализирована
            investments = new Investments();

            buttonForCreateGrafic.Enabled = false;//отключение кнопки создания графика
            buttonForCreateInvestment.Enabled = false;//отключение кнопки создания инвестиции

            /*if (investments.invs.Count == 0)
                listBoxInvestments.Items.Add("У вас пока нет сохраненных инвестиций");
            else
            {
                listBoxInvestments.Items.Clear();
                listBoxInvestments.Items.Add(investments.invs);
            }*/


        }

        public void CreateGrafic()
        {
            var queue = new ChartData(WhatPeriodOn());
            var queueItems = queue.CreateNewTupleList(Y);//получаем лист данных о выбранной валюте
            
            investments.SetCalc(queue);//сеанс предсказывания
            
            chart1.ChartAreas[0].AxisX.Interval = queueItems.Count/10;//интервал отметок по оси X
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -60;//отметка интервала отображается под углом

            var ax = new Axis();
            ax.Title = WhatPeriodOn().ToString();
            chart1.ChartAreas[0].AxisX = ax;//название оси в соотвествии с периодом

            chart1.Series[0].Points.Clear();//отчищаем график от предыдущего
            foreach (var element in queueItems)
            {
                decimal y;
                var x = element.Item2.ToString("d");//форматирование времени по типу ДД.ММ.ГГГГ
                try
                {
                    y = element.Item1;
                }
                catch (InvalidOperationException)
                {
                    break;
                }
                chart1.Series[0].Points.AddXY(x, y);//рисуем точку
            }
        }
        private void buttonCreateGrafic(object sender, EventArgs e)
        {
            //CreateHelper()
            CreateGrafic();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Y = CurrencyType.USD;
            OnOffBtnsCreateGrafAndInvs();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Y = CurrencyType.EUR;
            OnOffBtnsCreateGrafAndInvs();
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Y = CurrencyType.CNY;
            OnOffBtnsCreateGrafAndInvs();
        }
        private void SaveInDocement()
        {
            //TODO
        }
        private void buttonSave(object sender, EventArgs e)
        {
            SaveInDocement();
        }
        private void buttonCreateInvesment(object sender, EventArgs e)
        {
            var investmentCreationForm = new InvestmentCreationForm(investments);
            investmentCreationForm.Show(); // открытие другого окна
            Hide(); // закрыть текущее окно
            // возвращение главного окна при закрытии investmentCreationForm
            investmentCreationForm.FormClosing += (sender2, args) => Show();
        }
        private void buttonTrackInvestment_Click(object sender, EventArgs e)
        {
            //TODO
        }
        private void radioButtonHalfYear_CheckedChanged(object sender, EventArgs e)
        {
            OnOffBtnsCreateGrafAndInvs();
        }
        private void radioButtonOneMonth_CheckedChanged(object sender, EventArgs e)
        {
            OnOffBtnsCreateGrafAndInvs();
        }
        private void radioButtonOneYear_CheckedChanged(object sender, EventArgs e)
        {
            OnOffBtnsCreateGrafAndInvs();
        }
        private void radioButtonThreeMonth_CheckedChanged(object sender, EventArgs e)
        {
            OnOffBtnsCreateGrafAndInvs();
        }
        private void radioButtonOneWeek_CheckedChanged(object sender, EventArgs e)
        {
            OnOffBtnsCreateGrafAndInvs();
        }
        private TimeOptions WhatPeriodOn()
        {
            if (radioButtonHalfYear.Checked)
                return TimeOptions.Half_Year;
            else if (radioButtonOneMonth.Checked)
                return TimeOptions.One_Month;
            else if (radioButtonOneYear.Checked)
                return TimeOptions.One_Year;
            else if (radioButtonThreeMonth.Checked)
                return TimeOptions.Three_Months;
            else if (radioButtonOneWeek.Checked)
                return TimeOptions.One_Week;
            else throw new ArgumentException("Ни одна из кнопок периода времени не была выбрана");
        }
        private void OnOffBtnsCreateGrafAndInvs() {
            if ((radioButton1.Checked || radioButton2.Checked || radioButton3.Checked) &&
                    (radioButtonOneWeek.Checked || radioButtonThreeMonth.Checked || radioButtonOneYear.Checked
                    || radioButtonOneMonth.Checked || radioButtonHalfYear.Checked))
            {
                buttonForCreateGrafic.Enabled = true;//включение кнопки создания графика
                buttonForCreateInvestment.Enabled = true;//включение кнопки создания инвестиции
            }
        }
    }
}
