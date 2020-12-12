using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SMoGu.App
{
    /// <summary>
    /// Класс главной формы
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Поле, хранящая выбранную валюту
        /// </summary>
        public CurrencyType currency;
        /// <summary>
        /// Поле, хранящее все созданные инвестиции
        /// </summary>
        public readonly Investments investments;
        /// <summary>
        /// Конструктор главной формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // эта штука хранит варианты инвестиций и должна быть инициализирована
            investments = new Investments();

            buttonForCreateGrafic.Enabled = false;//отключение кнопки создания графика
            buttonForCreateInvestment.Enabled = false;//отключение кнопки создания инвестиции
            buttonInfo.Enabled = false;//отключение кнопки подробнйо информации об инвестциии
            buttonSave.Enabled = false;
        }
        /// <summary>
        /// Метод для создания графика
        /// </summary>
        public void CreateGrafic()
        {
            var queue = new ChartData(WhatPeriodOn());
            var queueItems = queue.CreateNewTupleList(currency);//получаем лист данных о выбранной валюте

            investments.SetCalc(queue);//сеанс предсказывания для графика

            chart1.ChartAreas[0].AxisX.Interval = queueItems.Count / 10;//интервал отметок по оси X
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
            buttonForCreateInvestment.Enabled = true;//включение кнопки создания инвестиции
            //только после построения графика
        }
        /// <summary>
        /// Метод отслеживания однократного нажатия на кнопку Создания графика
        /// </summary>
        /// <param name="sender">Ссылка на элемент управления</param>
        /// <param name="e">Событие однократного нажатия</param>
        private void buttonCreateGrafic(object sender, EventArgs e)
        {
            //CreateHelper()
            CreateGrafic();
        }
        /// <summary>
        /// Метод отслеживания нажатия на радиокнопку USD
        /// </summary>
        /// <param name="sender">Ссылка на элемент управления</param>
        /// <param name="e">Событие нажатия</param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            currency = CurrencyType.USD;
            OnOffBtnsCreateGrafAndInvs();
        }
        /// <summary>
        /// Метод отслеживания нажатия на радиокнопку EUR
        /// </summary>
        /// <param name="sender">Ссылка на элемент управления</param>
        /// <param name="e">Событие нажатия</param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            currency = CurrencyType.EUR;
            OnOffBtnsCreateGrafAndInvs();
        }
        /// <summary>
        /// Метод отслеживания нажатия на радиокнопку CNY
        /// </summary>
        /// <param name="sender">Ссылка на элемент управления</param>
        /// <param name="e">Событие нажатия</param>
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            currency = CurrencyType.CNY;
            OnOffBtnsCreateGrafAndInvs();
        }
        /// <summary>
        /// Метод, который сохраняет инвестицию на коипьютер
        /// </summary>
        private void SaveInDocement()
        {
            
            var saveToFile = new DBManager();
            saveToFile.SaveFile(investments);
        }
        /// <summary>
        /// Метод отслеживания нажатия на кнопку Сохранения
        /// </summary>
        /// <param name="sender">Ссылка на элемент управления</param>
        /// <param name="e">Событие одноератного нажатия</param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveInDocement();
        }
        /// <summary>
        /// Метод отслеживания нажатия на кнопку Создания инвестции
        /// </summary>
        /// <param name="sender">Ссылка на элемент управления</param>
        /// <param name="e">Событие одноератного нажатия</param>
        private void buttonCreateInvesment(object sender, EventArgs e)
        {
            var investmentCreationForm = new InvestmentCreationForm(this.investments, CheckedCurrency());//создание формы создания инвестиции
            investmentCreationForm.Show(); // открытие другого окна
            this.Hide(); // закрыть текущее окно
            // возвращение главного окна при закрытии investmentCreationForm
            investmentCreationForm.FormClosing += (sender2, args) =>
            {
                this.Show();

                var form = (InvestmentCreationForm)sender2;

                if (form.DialogResult == DialogResult.OK)
                {
                    this.listBoxInvestments.Items.Add(this.investments.invs.Last());
                    buttonSave.Enabled = true;
                }
            };
        }
        /// <summary>
        /// Метод отслеживания нажатия на кнопку Информация и инвестиции
        /// </summary>
        /// <param name="sender">Ссылка на элемент управления</param>
        /// <param name="e">Событие одноератного нажатия</param>
        private void buttonTrackInvestment_Click(object sender, EventArgs e)
        {
            try
            {
                var element = investments.invs[listBoxInvestments.SelectedIndex];
                var formInfo = new InvestmentInfoForm(element);
                formInfo.Show();//открытие окна с подробной информацией
            }
            catch(ArgumentOutOfRangeException)
            {
            }
        }
        /// <summary>
        /// Метод отслеживания нажатия на радиокнопку Half Year
        /// </summary>
        /// <param name="sender">Ссылка на элемент управления</param>
        /// <param name="e">Событие одноератного нажатия</param>
        private void radioButtonHalfYear_CheckedChanged(object sender, EventArgs e)
        {
            OnOffBtnsCreateGrafAndInvs();
        }
        /// <summary>
        /// Метод отслеживания нажатия на радиокнопку One Month
        /// </summary>
        /// <param name="sender">Ссылка на элемент управления</param>
        /// <param name="e">Событие одноератного нажатия</param>
        private void radioButtonOneMonth_CheckedChanged(object sender, EventArgs e)
        {
            OnOffBtnsCreateGrafAndInvs();
        }
        /// <summary>
        /// Метод отслеживания нажатия на радиокнопку One Year
        /// </summary>
        /// <param name="sender">Ссылка на элемент управления</param>
        /// <param name="e">Событие одноератного нажатия</param>
        private void radioButtonOneYear_CheckedChanged(object sender, EventArgs e)
        {
            OnOffBtnsCreateGrafAndInvs();
        }
        /// <summary>
        /// Метод отслеживания нажатия на радиокнопку Three Month
        /// </summary>
        /// <param name="sender">Ссылка на элемент управления</param>
        /// <param name="e">Событие одноератного нажатия</param>
        private void radioButtonThreeMonth_CheckedChanged(object sender, EventArgs e)
        {
            OnOffBtnsCreateGrafAndInvs();
        }
        /// <summary>
        /// Метод отслеживания нажатия на радиокнопку One Week
        /// </summary>
        /// <param name="sender">Ссылка на элемент управления</param>
        /// <param name="e">Событие одноератного нажатия</param>
        private void radioButtonOneWeek_CheckedChanged(object sender, EventArgs e)
        {
            OnOffBtnsCreateGrafAndInvs();
        }
        /// <summary>
        /// Метод, который определяет какой период выбран
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Метод, который активирует кнопки Создания Графика
        /// </summary>
        private void OnOffBtnsCreateGrafAndInvs()
        {
            if ((radioButton1.Checked || radioButton2.Checked || radioButton3.Checked) &&
                    (radioButtonOneWeek.Checked || radioButtonThreeMonth.Checked || radioButtonOneYear.Checked
                    || radioButtonOneMonth.Checked || radioButtonHalfYear.Checked))
                buttonForCreateGrafic.Enabled = true;//включение кнопки создания графика
        }

        private void listBoxInvestments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxInvestments.SelectedIndex >= 0)
                buttonInfo.Enabled = true;
             else
                buttonInfo.Enabled = false;
        }

        public CurrencyType CheckedCurrency()
        {
            if (radioButton1.Checked) return CurrencyType.USD;
            else if (radioButton2.Checked) return CurrencyType.EUR;
            else if (radioButton3.Checked) return CurrencyType.CNY;
            else throw new ArgumentException();
        }
    }
}
