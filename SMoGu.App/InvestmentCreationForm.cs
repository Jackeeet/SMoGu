using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace SMoGu.App
{
    class InvestmentCreationForm : Form
    {
        private static int width = 300;
        private static List<string> times = new List<string>
        {
            "1 месяц", "3 месяца", "6 месяцев", "9 месяцев",
            "1 год", "2 года", "5 лет", "10 лет"
        };

        public InvestmentCreationForm()
        {
            ClientSize = new Size(width, 300);
            Text = "Создание инвестиции";
            BackColor = Color.AliceBlue;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            var optionsPanel = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(ClientSize.Width, 250),
            };
            FillOptionsPanel(optionsPanel);

            var buttonPanel = new Panel()
            {
                Location = new Point(0, 250),
                Size = new Size(ClientSize.Width, 50),
            };
            FillButtonPanel(buttonPanel);

            Controls.Add(optionsPanel);
            Controls.Add(buttonPanel);
        }

        private void FillButtonPanel(Panel buttonPanel)
        {
            var saveButton = new Button()
            {
                Text = "Сохранить",
                Size = new Size(80, 30),
                Location = new Point(60, 10), 
                BackColor = Color.White
            };

            var cancelButton = new Button()
            {
                Text = "Отмена",
                Size = new Size(80, 30),
                Location = new Point(160, 10),
                BackColor = Color.White
            };

            buttonPanel.Controls.Add(saveButton);
            buttonPanel.Controls.Add(cancelButton);
        }

        private void FillOptionsPanel(Panel options)
        {
            var nameBox = new TextBox()
            {
                Location = new Point(40, 30),
                Size = new Size(options.Width * 3 / 4, 30)
            };

            var amountBox = new TextBox()
            {
                Location = new Point(40, 90),
                Size = new Size(options.Width * 3 / 4, 30),
            };

            var currencyPanel = new Panel()
            {
                Location = new Point(0, 150),
                Size = new Size(options.Width, 30)
            };
            InitialiseCurrencyButtons(currencyPanel);

            var timeBox = new ComboBox()
            {
                Location = new Point(40, 210),
                Size = new Size(options.Width * 3 / 4, 30),
            };
            InitialiseTimeBox(timeBox);

            options.Controls.Add(CreateOptionsLabel(options, "Введите название инвестиции:", new Point(0, 0)));
            options.Controls.Add(nameBox);
            options.Controls.Add(CreateOptionsLabel(options, "Введите сумму инвестиции:", new Point(0, 60)));
            options.Controls.Add(amountBox);
            options.Controls.Add(CreateOptionsLabel(options, "Выберите валюту:", new Point(0, 120)));
            options.Controls.Add(currencyPanel);
            options.Controls.Add(CreateOptionsLabel(options, "Выберите время прогнозирования:", new Point(0, 180)));
            options.Controls.Add(timeBox);
        }

        private void InitialiseTimeBox(ComboBox timeBox)
        {
            foreach (var time in times)
                timeBox.Items.Add(time);
        }

        private void InitialiseCurrencyButtons(Panel groupBox)
        {
            var usd = new RadioButton()
            {
                Location = new Point(40, 0),
                Size = new Size(75, 30),
                Text = "USD"
            };
            var eur = new RadioButton()
            {
                Location = new Point(115, 0),
                Size = new Size(75, 30),
                Text = "EUR"
            };
            var cny = new RadioButton()
            {
                Location = new Point(190, 0),
                Size = new Size(75, 30),
                Text = "CNY"
            };

            groupBox.Controls.Add(usd);
            groupBox.Controls.Add(eur);
            groupBox.Controls.Add(cny);
        }

        private Label CreateOptionsLabel(Panel options, string text, Point location)
        {
            return new Label
            {
                Location = location,
                Size = new Size(options.Width, 30),
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter
            };
        }
    }
}