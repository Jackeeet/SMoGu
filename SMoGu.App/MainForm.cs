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

            // Инициализация контейнера для хранения вариантов инвестиций.
            investments = new Investments();
            // Отключение кнопки создания графика.
            buttonForCreateGrafic.Enabled = false;
            // Отключение кнопки создания инвестиции.
            buttonForCreateInvestment.Enabled = false;
            // Отключение кнопки для подробной информации об инвестиции.
            buttonInfo.Enabled = false;
            buttonSave.Enabled = false;
            buttonSort.Enabled = false;
            buttonForCreateGrafic.Enabled = false;

            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("Отсутствует или ограниченно физическое подключение к сети\nПроверьте настройки вашего сетевого подключения");
            }

            toolTip = new ToolTip
            {
                AutoPopDelay = 3000,
                InitialDelay = 1000,
                ReshowDelay = 500,
            };
            AddToolTips();
        }
        /// <summary>
        /// Метод для инициализации подсказок.
        /// </summary>
        private void AddToolTips()
        {
            toolTip.SetToolTip(radioButton1, "Курс доллара к рублю");
            toolTip.SetToolTip(radioButton2, "Курс евро к рублю");
            toolTip.SetToolTip(radioButton3, "Курс юаня к рублю");
            toolTip.SetToolTip(radioButtonOneWeek, "Динамика курса за прошедшую неделю");
            toolTip.SetToolTip(radioButtonOneMonth, "Динамика курса за прошедший месяц");
            toolTip.SetToolTip(radioButtonThreeMonth, "Динамика курса за 3 прошедших месяца");
            toolTip.SetToolTip(radioButtonHalfYear, "Динамика курса за 6 прошедших месяцев");
            toolTip.SetToolTip(radioButtonOneYear, "Динамика курса за прошедший год");

            toolTip.SetToolTip(buttonForCreateGrafic, "Построить график по указанным параметрам");
            toolTip.SetToolTip(buttonForCreateInvestment, "Создать предполагаемый вариант инвестиции");
            toolTip.SetToolTip(buttonSort, "Отсортировать варианты по убыванию доходности");
            toolTip.SetToolTip(buttonInfo, "Показать подробную информацию о выбранном варианте инвестиции");
            toolTip.SetToolTip(buttonSave, "Записать информацию о всех созданных вариантах в текстовый файл");
        }

        /// <summary>
        /// Метод для создания графика.
        /// </summary>
        public void CreateGrafic()
        {
            var queue = new ChartData(WhatPeriodOn());
            // Получаем лист данных о выбранной валюте.
            var queueItems = queue.CreateNewTupleList(currency);
            // Cеанс прогнозирования изменения курса валют.
            investments.SetCalc(queue);
            // Интервал отметок по оси X.
            chart1.ChartAreas[0].AxisX.Interval = queueItems.Count / 10;
            // Отображение отметки интервала под углом.
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -60;

            var ax = new Axis();
            ax.Title = WhatPeriodOn().ToString();
            // Название оси в соотвествии с периодом.
            chart1.ChartAreas[0].AxisX = ax;
            // Удаление предыдущего графика.
            chart1.Series[0].Points.Clear();
            foreach (var element in queueItems)
            {
                decimal y;
                // Форматирование времени по типу ДД.ММ.ГГГГ.
                var x = element.Item2.ToString("d");
                try
                {
                    y = element.Item1;
                }
                catch (InvalidOperationException)
                {
                    break;
                }
                // Отрисовка точки.
                chart1.Series[0].Points.AddXY(x, y);
            }
            // Включение кнопки создания инвестиции (только после построения графика). 
            buttonForCreateInvestment.Enabled = true;
        }
        /// <summary>
        /// Метод отслеживания однократного нажатия на кнопку Создания графика.
        /// </summary>
        /// <param name="sender">Ссылка на элемент управления.</param>
        /// <param name="e">Событие однократного нажатия.</param>
        private void buttonCreateGrafic(object sender, EventArgs e)
        {
            try
            {
                CreateGrafic();
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("Отсутствует или ограниченно физическое подключение к сети\nПроверьте настройки вашего сетевого подключения");
            }
        }
        /// <summary>
        /// Метод отслеживания нажатия на радиокнопку USD.
        /// </summary>
        /// <param name="sender">Ссылка на элемент управления.</param>
        /// <param name="e">Событие нажатия.</param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            currency = CurrencyType.USD;
            OnOffBtnsCreateGrafAndInvs();
        }
        /// <summary>
        /// Метод отслеживания нажатия на радиокнопку EUR.
        /// </summary>
        /// <param name="sender">Ссылка на элемент управления.</param>
        /// <param name="e">Событие нажатия.</param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            currency = CurrencyType.EUR;
            OnOffBtnsCreateGrafAndInvs();
        }
        /// <summary>
        /// Метод отслеживания нажатия на радиокнопку CNY.
        /// </summary>
        /// <param name="sender">Ссылка на элемент управления.</param>
        /// <param name="e">Событие нажатия.</param>
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            currency = CurrencyType.CNY;
            OnOffBtnsCreateGrafAndInvs();
        }
        /// <summary>
        /// Метод, который сохраняет инвестицию на коипьютер.
        /// </summary>
        private void SaveInDocument()
        {
            
            var saveToFile = new DBManager();
            saveToFile.SaveFile(investments);
        }
        /// <summary>
        /// Метод отслеживания нажатия на кнопку Сохранения.
        /// </summary>
        /// <param name="sender">Ссылка на элемент управления.</param>
        /// <param name="e">Событие однократного нажатия.</param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveInDocument();
        }
        /// <summary>
        /// Метод отслеживания нажатия на кнопку Создания инвестиции.
        /// </summary>
        /// <param name="sender">Ссылка на элемент управления.</param>
        /// <param name="e">Событие одноератного нажатия.</param>
        private void buttonCreateInvesment(object sender, EventArgs e)
        {
            var investmentCreationForm = new InvestmentCreationForm(this.investments, CheckedCurrency());
            // Открытие формы создания инвестиции.
            investmentCreationForm.Show();
            // Закрытие текущего окна.
            this.Hide(); 
            // Возвращение главного окна при закрытии investmentCreationForm.
            investmentCreationForm.FormClosing += (sender2, args) =>
            {
                this.Show();

                var form = (InvestmentCreationForm)sender2;

                if (form.DialogResult == DialogResult.OK)
                {
                    this.listBoxInvestments.Items.Add(this.investments.Invs.Last());
                    if (this.listBoxInvestments.Items.Count > 0)
                    {
                        buttonSave.Enabled = true;
                        buttonSort.Enabled = true;
                    }
                }
            };
        }
        /// <summary>
        /// Метод отслеживания нажатия на кнопку Информация о инвестиции.
        /// </summary>
        /// <param name="sender">Ссылка на элемент управления. </param>
        /// <param name="e">Событие одноератного нажатия.</param>
        private void buttonTrackInvestment_Click(object sender, EventArgs e)
        {
            try
            {
                var element = investments.Invs[listBoxInvestments.SelectedIndex];
                var formInfo = new InvestmentInfoForm(element);
                // Открытие окна с подробной информацией.
                formInfo.Show();
            }
            catch(ArgumentOutOfRangeException)
            {
            }
        }
        /// <summary>
        /// Метод отслеживания нажатия на радиокнопку Half Year.
        /// </summary>
        /// <param name="sender">Ссылка на элемент управления.</param>
        /// <param name="e">Событие одноератного нажатия.</param>
        private void radioButtonHalfYear_CheckedChanged(object sender, EventArgs e)
        {
            OnOffBtnsCreateGrafAndInvs();
        }
        /// <summary>
        /// Метод отслеживания нажатия на радиокнопку One Month.
        /// </summary>
        /// <param name="sender">Ссылка на элемент управления.</param>
        /// <param name="e">Событие одноератного нажатия.</param>
        private void radioButtonOneMonth_CheckedChanged(object sender, EventArgs e)
        {
            OnOffBtnsCreateGrafAndInvs();
        }
        /// <summary>
        /// Метод отслеживания нажатия на радиокнопку One Year.
        /// </summary>
        /// <param name="sender">Ссылка на элемент управления.</param>
        /// <param name="e">Событие одноератного нажатия.</param>
        private void radioButtonOneYear_CheckedChanged(object sender, EventArgs e)
        {
            OnOffBtnsCreateGrafAndInvs();
        }
        /// <summary>
        /// Метод отслеживания нажатия на радиокнопку Three Month.
        /// </summary>
        /// <param name="sender">Ссылка на элемент управления.</param>
        /// <param name="e">Событие одноератного нажатия.</param>
        private void radioButtonThreeMonth_CheckedChanged(object sender, EventArgs e)
        {
            OnOffBtnsCreateGrafAndInvs();
        }
        /// <summary>
        /// Метод отслеживания нажатия на радиокнопку One Week.
        /// </summary>
        /// <param name="sender">Ссылка на элемент управления.</param>
        /// <param name="e">Событие одноератного нажатия.</param>
        private void radioButtonOneWeek_CheckedChanged(object sender, EventArgs e)
        {
            OnOffBtnsCreateGrafAndInvs();
        }
        /// <summary>
        /// Метод, который определяет, какой период выбран.
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
        /// Метод, который активирует кнопки Создания Графика.
        /// </summary>
        private void OnOffBtnsCreateGrafAndInvs()
        {
            if ((radioButton1.Checked || radioButton2.Checked || radioButton3.Checked) &&
                    (radioButtonOneWeek.Checked || radioButtonThreeMonth.Checked || radioButtonOneYear.Checked
                    || radioButtonOneMonth.Checked || radioButtonHalfYear.Checked))
                // Включение кнопки создания графика.
                buttonForCreateGrafic.Enabled = true;
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

        private static ToolTip toolTip;

        private void buttonSort_Click(object sender, EventArgs e)
        {
            investments.GetBestOptions();
            this.listBoxInvestments.Items.Clear();
            foreach (var f in investments.Invs)
            this.listBoxInvestments.Items.Add(f);
        }
    }
}
