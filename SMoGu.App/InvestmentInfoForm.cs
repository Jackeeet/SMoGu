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
    public class InvestmentInfoForm : Form
    {
        private static int labelHeight = 30;
        private static int textBoxHeight = 50;
        private static Size cSize = new Size(800, 600);
        //private static int panelWidth = (int)(cSize.Width * 0.3);
        private static int panelWidth = 240;
        private static Panel chartPanel, infoPanel;
        public InvestmentInfoForm(Investment investment)
        {
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
                Size = new Size(ClientSize.Width - panelWidth, ClientSize.Width - labelHeight),
                // временная заливка цветом 
                BackColor = Color.AliceBlue,
            };

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
                chartPanel.Size = new Size(ClientSize.Width - panelWidth, ClientSize.Width - labelHeight);
                infoPanel.Location = new Point(chartPanel.Width, labelHeight);
            };

            #region adders
            Controls.Add(nameLabel);
            Controls.Add(chartPanel);
            Controls.Add(infoPanel);

            infoPanel.Controls.Add(CreateLabel("Предполагаемый доход:"));
            infoPanel.Controls.Add(CreateTextBox(investment.ProceedsEstimate.ToString()));
            infoPanel.Controls.Add(CreateLabel("Предполагаемые риски:"));
            infoPanel.Controls.Add(CreateTextBox(investment.RiskEstimate.ToString()));
            infoPanel.Controls.Add(CreateLabel("Процент выгодности:"));
            infoPanel.Controls.Add(CreateTextBox(investment.ProfitPercentage.ToString()));
            #endregion
        }


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
