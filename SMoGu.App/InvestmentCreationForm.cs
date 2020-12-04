using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Globalization;

namespace SMoGu.App
{
    class InvestmentCreationForm : Form
    {
        public InvestmentCreationForm(Investments invs)
        {
            ClientSize = new Size(width, 300);
            Text = "Создание инвестиции";
            BackColor = Color.AliceBlue;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            optionsPanel = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(ClientSize.Width, 250),
            };
            FillOptionsPanel();

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
                var name = nameBox.Text;
                var amount = decimal.Parse(amountBox.Text, CultureInfo.InvariantCulture);
                var selectedCurrButton = currencyPanel.Controls.OfType<RadioButton>().FirstOrDefault(b => b.Checked);
                var curr = DetermineCurrency(selectedCurrButton);
                var selectedTime = timeBox.SelectedItem.ToString();
                var period = DeterminePeriod(selectedTime);
                invs.AddInvestment(name, amount, curr, period);
                var dialog = MessageBox.Show("Вариант инвестиции сохранен.");
                if (dialog == DialogResult.OK)
                    Close();
            };
            cancelButton.Click += (sender, args) => Close();
            /*{
                this.Hide();
                var mainForm = new MainForm();
                mainForm.Show();
            };*/
        }

        #region Parsers 
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

        private CurrencyType DetermineCurrency(RadioButton b)
        {
            return (b.Text == "USD") ? CurrencyType.USD :
                    (b.Text == "EUR") ? CurrencyType.EUR : CurrencyType.CNY;
        }
        #endregion

        #region Initializers 
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

        private void FillOptionsPanel()
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
            InitialiseCurrencyButtons();

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

        private void InitialiseTimeBox()
        {
            foreach (var time in times)
                timeBox.Items.Add(time);
        }

        private void InitialiseCurrencyButtons()
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
        }

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
        #endregion

        #region StaticFields
        private static int width = 300;
        private static List<string> times = new List<string>
        {
            "1 месяц", "3 месяца", "6 месяцев", "9 месяцев",
            "1 год", "2 года", "5 лет", "10 лет"
        };

        private static Panel optionsPanel, buttonPanel, currencyPanel;
        private static Button saveButton, cancelButton;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvestmentCreationForm));
            this.SuspendLayout();
            // 
            // InvestmentCreationForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InvestmentCreationForm";
            this.ResumeLayout(false);

        }

        private static TextBox nameBox, amountBox;
        private static ComboBox timeBox;
        private static RadioButton usd, eur, cny; 
        #endregion
    }
}