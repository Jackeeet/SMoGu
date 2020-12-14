using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SMoGu.App
{
    /// <summary>
    /// Класс, описывающий форму для создания варианта инвестиции.
    /// </summary>
    class InvestmentCreationForm : Form
    {

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="invs"> Список созданных пользователем вариантов инвестиций. </param>
        public InvestmentCreationForm(Investments invs, CurrencyType currency)
        {
            optionsPanel = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(ClientSize.Width, 250),
            };
            FillOptionsPanel(currency);

            buttonPanel = new Panel
            {
                Location = new Point(0, 250),
                Size = new Size(ClientSize.Width, 50),
            };
            FillButtonPanel();

            Controls.Add(optionsPanel);
            Controls.Add(buttonPanel);

            saveButton.Click += (sender, args) =>
            {
                // Проверка того, все ли поля формы были заполнены.
                if (!AllFieldsAreFilled())
                {
                    MessageBox.Show("Заполните все поля формы");
                }
                // Создание варианта инвестиции.
                else
                {
                    // Проверка соответствия ввода маске. 
                    // Максимальное допустимое значение - 9999999.99.
                    // При вводе более 2 знаков после запятой значение округляется до 2 знаков.
                    if (amountRegex.IsMatch(amountBox.Text))
                    {
                        var amount = new decimal(Math.Round(double.Parse(amountBox.Text, CultureInfo.InvariantCulture), 2));
                        if (amount < 0.01m)
                        {
                            MessageBox.Show("Сумма должна быть ненулевой");
                        }
                        else
                        {
                            var name = nameBox.Text;
                            var selectedCurrButton = currencyPanel.Controls.OfType<RadioButton>().FirstOrDefault(b => b.Checked);
                            var curr = DetermineCurrency(selectedCurrButton);
                            var selectedTime = timeBox.SelectedItem.ToString();
                            var period = DeterminePeriod(selectedTime);

                            invs.AddInvestment(name, amount, curr, period);
                            var dialog = MessageBox.Show("Вариант инвестиции сохранен.");
                            if (dialog == DialogResult.OK)
                            {
                                this.DialogResult = DialogResult.OK;
                                Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введенная сумма не является числом или превышает допустимую сумму");
                    }
                }
            };
            cancelButton.Click += (sender, args) =>
            {
                this.DialogResult = DialogResult.Cancel;
                Close();
            };
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ClientSize = new Size(width, 300);
            Text = "Создание инвестиции";
            BackColor = Color.AliceBlue;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            toolTip = new ToolTip
            {
                AutoPopDelay = 3000,
                InitialDelay = 1000,
                ReshowDelay = 500,
            };

            toolTip.SetToolTip(nameBox, "Название варианта инвестиции");
            toolTip.SetToolTip(amountBox, "Предполагаемая сумма инвестиции; значение в пределах [0,01; 9999999,99]");
            toolTip.SetToolTip(timeBox, "Период, в течение которого будет спрогнозировано изменение курса");
            toolTip.SetToolTip(saveButton, "Сохранить созданный вариант");
            toolTip.SetToolTip(cancelButton, "Отменить создание варианта");
        }
        /// <summary>
        /// Проверяет, все ли поля формы заполнены.
        /// </summary>
        /// <returns> True, если все поля заполнены. </returns>
        private bool AllFieldsAreFilled()
        {
            return !string.IsNullOrEmpty(nameBox.Text) &&
                   !string.IsNullOrEmpty(amountBox.Text) &&
                   (usd.Checked || eur.Checked || cny.Checked) &&
                   !(timeBox.SelectedItem == null);
        }

        #region Parsers 
        /// <summary>
        /// Переводит выбранное в timeBox значение в int. 
        /// </summary>
        /// <param name="selectedTime"> Выбранное значение. </param>
        /// <returns> Соответствующее значению целое число дней. </returns>
        private int DeterminePeriod(string selectedTime)
        {
            switch (selectedTime)
            {
                case "1 месяц":
                    return 30;
                case "3 месяца":
                    return 91;
                case "6 месяцев":
                    return 183;
                case "9 месяцев":
                    return 274;
                case "1 год":
                    return 365;
                case "2 года":
                    return 730;
                case "5 лет":
                    return 1825;
                case "10 лет":
                    return 3650;
                default: throw new ArgumentException("Несуществующая опция");
            }
        }

        /// <summary>
        /// Определяет выбранную пользователем валюту.
        /// </summary>
        /// <param name="b"> Активированная пользователем радио-кнопка. </param>
        /// <returns> Соответствующий тип валюты. </returns>
        private CurrencyType DetermineCurrency(RadioButton b)
        {
            return (b.Text == "USD") ? CurrencyType.USD :
                    (b.Text == "EUR") ? CurrencyType.EUR : CurrencyType.CNY;
        }
        #endregion

        #region Initializers 
        /// <summary>
        /// Инициализирует кнопки "Сохранить" и "Отмена".
        /// </summary>
        private void FillButtonPanel()
        {
            saveButton = new Button()
            {
                Text = "Сохранить",
                Size = new Size(80, 30),
                Location = new Point(60, 10),
                BackColor = Color.White
            };
            cancelButton = new Button()
            {
                Text = "Отмена",
                Size = new Size(80, 30),
                Location = new Point(160, 10),
                BackColor = Color.White
            };
            buttonPanel.Controls.Add(saveButton);
            buttonPanel.Controls.Add(cancelButton);
        }
        /// <summary>
        /// Инициализирует поля формы.
        /// </summary>
        private void FillOptionsPanel(CurrencyType c)
        {
            nameBox = new TextBox()
            {
                Location = new Point(40, 30),
                Size = new Size(optionsPanel.Width * 3 / 4, 30)
            };

            amountBox = new TextBox()
            {
                Location = new Point(40, 90),
                Size = new Size(optionsPanel.Width * 3 / 4, 30),
            };

            currencyPanel = new Panel()
            {
                Location = new Point(0, 150),
                Size = new Size(optionsPanel.Width, 30)
            };
            InitialiseCurrencyButtons(c);

            timeBox = new ComboBox()
            {
                Location = new Point(40, 210),
                Size = new Size(optionsPanel.Width * 3 / 4, 30),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            InitialiseTimeBox();
           
            optionsPanel.Controls.Add(CreateOptionsLabel("Введите название инвестиции:", new Point(0, 0)));
            optionsPanel.Controls.Add(nameBox);
            optionsPanel.Controls.Add(CreateOptionsLabel("Введите сумму инвестиции:", new Point(0, 60)));
            optionsPanel.Controls.Add(amountBox);
            optionsPanel.Controls.Add(CreateOptionsLabel("Выберите валюту:", new Point(0, 120)));
            optionsPanel.Controls.Add(currencyPanel);
            optionsPanel.Controls.Add(CreateOptionsLabel("Выберите время прогнозирования:", new Point(0, 180)));
            optionsPanel.Controls.Add(timeBox);
        }
        /// <summary>
        /// Инициализирует timeBox.
        /// </summary>
        private void InitialiseTimeBox()
        {
            foreach (var time in times)
                timeBox.Items.Add(time);
        }
        /// <summary>
        /// Инициализирует радио-кнопки для выбора валюты.
        /// </summary>
        private void InitialiseCurrencyButtons(CurrencyType c)
        {
            usd = new RadioButton()
            {
                Location = new Point(40, 0),
                Size = new Size(75, 30),
                Text = "USD"
            };
            eur = new RadioButton()
            {
                Location = new Point(115, 0),
                Size = new Size(75, 30),
                Text = "EUR"
            };
            cny = new RadioButton()
            {
                Location = new Point(190, 0),
                Size = new Size(75, 30),
                Text = "CNY"
            };

            currencyPanel.Controls.Add(usd);
            currencyPanel.Controls.Add(eur);
            currencyPanel.Controls.Add(cny);

            if (c == CurrencyType.USD) usd.Checked = true;
            else if (c == CurrencyType.EUR) eur.Checked = true;
            else if (c == CurrencyType.CNY) cny.Checked = true;
        }
        /// <summary>
        /// Создает лейбл с указанным текстом и локацией.
        /// </summary>
        /// <param name="text"> Текст лейбла. </param>
        /// <param name="location"> Локация лейбла. </param>
        /// <returns></returns>
        private Label CreateOptionsLabel(string text, Point location)
        {
            return new Label
            {
                Location = location,
                Size = new Size(optionsPanel.Width, 30),
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvestmentCreationForm));
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InvestmentCreationForm";
            this.ResumeLayout(false);

        }
        #endregion

        #region Fields
        private TextBox nameBox, amountBox;
        private ComboBox timeBox;
        private RadioButton usd, eur, cny;

        private static Panel optionsPanel, buttonPanel, currencyPanel;
        private static Button saveButton, cancelButton;

        private static ToolTip toolTip;
        private static Regex amountRegex = new Regex("^\\d{1,7}([,\\.]\\d{1,2})?");

        private static int width = 300;
        private static List<string> times = new List<string>
        {
            "1 месяц", "3 месяца", "6 месяцев", "9 месяцев",
            "1 год", "2 года", "5 лет", "10 лет"
        };
        #endregion
    }
}