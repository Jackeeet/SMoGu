using System;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace SMoGu.App
{
    /// <summary>
    /// Класс, описывающий форму с информацией о конкретном варианте инвестиции. 
    /// </summary>
    public class InvestmentInfoForm : Form
    {
        private static int labelHeight = 30;
        private static int textBoxHeight = 50;
        private static Size cSize = new Size(800, 600);
        private static int panelWidth = 240;
        private static Panel chartPanel, infoPanel;
        private Chart chart;
        /// <summary>
        /// Конструктор класса. 
        /// </summary>
        /// <param name="investment"> Вариант инвестиции, информация о котором будет отображена. </param>
        public InvestmentInfoForm(Investment investment)
        {
            BackColor = Color.AliceBlue;
            var nameLabel = new Label
            {
                Location = new Point(0, 0),
                Text = investment.InvestmentName,
                Font = new Font("Arial", 16),
                TextAlign = ContentAlignment.MiddleCenter
            };

            chartPanel = new Panel
            {
                Location = new Point(0, 30),
                Size = new Size(ClientSize.Width - panelWidth, ClientSize.Height - labelHeight),
            };
            CreateChart(investment);

            infoPanel = new FlowLayoutPanel
            {
                Size = new Size(panelWidth, ClientSize.Width - labelHeight)
            };

            Load += (sender, args) =>
            {
                ClientSize = cSize;
                Text = investment.InvestmentName;
                ActiveControl = null;
            };

            SizeChanged += (sender, args) =>
            {
                nameLabel.Size = new Size(ClientSize.Width, labelHeight);
                nameLabel.TextAlign = ContentAlignment.MiddleCenter;
                chartPanel.Size = new Size(ClientSize.Width - panelWidth, ClientSize.Height - labelHeight);
                infoPanel.Location = new Point(chartPanel.Width, labelHeight);
            };

            #region adders
            Controls.Add(nameLabel);
            Controls.Add(chartPanel);
            Controls.Add(infoPanel);

            infoPanel.Controls.Add(CreateLabel("Предполагаемый доход:"));
            infoPanel.Controls.Add(CreateTextBox(Math.Round(investment.ProceedsEstimate, 3).ToString()));
            infoPanel.Controls.Add(CreateLabel("Предполагаемые риски:"));
            infoPanel.Controls.Add(CreateTextBox(Math.Round(investment.RiskEstimate,5).ToString()));
            infoPanel.Controls.Add(CreateLabel("Процент выгодности:"));
            infoPanel.Controls.Add(CreateTextBox(Math.Round(investment.ProfitPercentage, 5).ToString()));
            #endregion
        }

        /// <summary>
        /// Строит график, отображающий изменения прогнозируемого курса валюты. 
        /// </summary>
        /// <param name="investment"> Вариант инвестиции. </param>
        private void CreateChart(Investment investment)
        {
            chart = new Chart
            {
                Size = chartPanel.Size,
                Dock = DockStyle.Fill
            };

            chart.ChartAreas.Add("invChart");
            chart.ChartAreas[0].AxisX = new Axis { Title = "Дата" };
            chart.ChartAreas[0].AxisY = new Axis { Title = "Прогнозируемый курс валюты"};
            chart.Series.Clear();
            chart.Series.Add(new Series());
            chart.Series[0].ChartType = SeriesChartType.Line;

            foreach (var value in investment.ValuesOverTime)
            {
                decimal y;
                var x = value.Item2.ToString("d");
                try
                {
                    y = value.Item1;
                }
                catch (InvalidOperationException)
                {
                    break;
                }
                chart.Series[0].Points.AddXY(x, y);
            }
            chartPanel.Controls.Add(chart);
        }

        /// <summary>
        /// Создает лейбл с указанным текстом.
        /// </summary>
        /// <param name="text"> Текст лейбла. </param>
        /// <returns> Созданный лейбл. </returns>
        private Label CreateLabel(string text)
        {
            return new Label
            {
                Size = new Size(infoPanel.Width, labelHeight),
                Text = text,
                Font = new Font("Arial", 12),
                Margin = new Padding(2, 5, 0, 0),
                TextAlign = ContentAlignment.TopLeft
            };
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvestmentInfoForm));
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InvestmentInfoForm";
            this.ResumeLayout(false);
        }
        /// <summary>
        /// Создает текстовое поле с указанным содержимым. 
        /// Созданное поле не допускает изменения.
        /// </summary>
        /// <param name="contents"> Содержимое поля. </param>
        /// <returns> Созданное поле. </returns>
        private TextBox CreateTextBox(string contents)
        {
            return new TextBox
            {
                Size = new Size((int)(infoPanel.Width * 0.95), textBoxHeight),
                ReadOnly = true,
                Text = contents
            };
        }
    }
}