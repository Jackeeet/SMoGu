using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace Smogu
{
    class InvestmentForm : Form
    {
        private static int labelHeight = 30;
        private static int textBoxHeight = 50;
        public InvestmentForm(Investment investment)
        {
            ClientSize = new Size(800, 600);
            var panelWidth = ClientSize.Width / 2;
            Name = investment.InvestmentName;

            var nameLabel = new Label
            {
                Location = new Point(0, 0),
                Size = new Size(ClientSize.Width, labelHeight),
                Text = investment.InvestmentName,
                Font = new Font("Arial", 16),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var chartPanel = new Panel
            {
                Location = new Point(0, 30),
                Size = new Size(panelWidth, ClientSize.Width - labelHeight)
                // временная заливка цветом 
                ,
                BackColor = Color.Black,

            };

            var infoPanel = new FlowLayoutPanel
            {
                Location = new Point(ClientSize.Width / 2, 30),
                Size = new Size(panelWidth, ClientSize.Width - labelHeight)
            };
            infoPanel.FlowDirection = FlowDirection.TopDown;


            Controls.Add(nameLabel);
            Controls.Add(chartPanel);
            Controls.Add(infoPanel);

            infoPanel.Controls.Add(CreateLabel("Предполагаемый доход:"));
            infoPanel.Controls.Add(CreateTextBox(investment.ProfitEstimate.ToString()));
            infoPanel.Controls.Add(CreateLabel("Предполагаемые риски:"));
            infoPanel.Controls.Add(CreateTextBox(investment.RiskEstimate.ToString()));
            infoPanel.Controls.Add(CreateLabel("Процент выгодности инвестиции:"));
            infoPanel.Controls.Add(CreateTextBox(investment.StonksPercentage.ToString()));
        }

        private Label CreateLabel(string text)
        {
            return new Label
            {
                Size = new Size(ClientSize.Width / 2, labelHeight),
                Text = text,
                Font = new Font("Arial", 12),
                Margin = new Padding(2, 5, 0, 0),
                TextAlign = ContentAlignment.TopLeft
            };
        }

        private TextBox CreateTextBox(string contents)
        {
            return new TextBox
            {
                Size = new Size(ClientSize.Width / 4, textBoxHeight),
                ReadOnly = true,
                Text = contents
            };
        }
    }
}
