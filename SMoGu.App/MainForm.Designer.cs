namespace SMoGu.App
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonForCreateGrafic = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.buttonForCreateInvestment = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonThreeMonth = new System.Windows.Forms.RadioButton();
            this.radioButtonOneYear = new System.Windows.Forms.RadioButton();
            this.radioButtonHalfYear = new System.Windows.Forms.RadioButton();
            this.radioButtonOneMonth = new System.Windows.Forms.RadioButton();
            this.radioButtonOneWeek = new System.Windows.Forms.RadioButton();
            this.textPeriod = new System.Windows.Forms.TextBox();
            this.listBoxInvestments = new System.Windows.Forms.ListBox();
            this.investmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.investmentsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BorderSkin.BorderWidth = 0;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(12, 81);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Lime;
            series1.Name = "Series1";
            series1.ShadowColor = System.Drawing.Color.Lime;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(541, 336);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            title1.BorderWidth = 3;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            title1.Name = "Title1";
            title1.Text = "Grafic value";
            this.chart1.Titles.Add(title1);
            // 
            // buttonForCreateGrafic
            // 
            this.buttonForCreateGrafic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonForCreateGrafic.Location = new System.Drawing.Point(336, 32);
            this.buttonForCreateGrafic.Name = "buttonForCreateGrafic";
            this.buttonForCreateGrafic.Size = new System.Drawing.Size(103, 29);
            this.buttonForCreateGrafic.TabIndex = 3;
            this.buttonForCreateGrafic.Text = "Create grafic ";
            this.buttonForCreateGrafic.UseVisualStyleBackColor = true;
            this.buttonForCreateGrafic.Click += new System.EventHandler(this.buttonCreateGrafic);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(192, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 29);
            this.button2.TabIndex = 4;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonSave);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(61, 12);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(76, 17);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.Text = "USD/RUB";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(61, 35);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(76, 17);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.Text = "EUR/RUB";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(61, 58);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(75, 17);
            this.radioButton3.TabIndex = 7;
            this.radioButton3.Text = "CNY/RUB";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // buttonForCreateInvestment
            // 
            this.buttonForCreateInvestment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonForCreateInvestment.Location = new System.Drawing.Point(572, 32);
            this.buttonForCreateInvestment.Name = "buttonForCreateInvestment";
            this.buttonForCreateInvestment.Size = new System.Drawing.Size(158, 29);
            this.buttonForCreateInvestment.TabIndex = 8;
            this.buttonForCreateInvestment.Text = "Create investment ";
            this.buttonForCreateInvestment.UseVisualStyleBackColor = true;
            this.buttonForCreateInvestment.Click += new System.EventHandler(this.buttonCreateInvesment);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(572, 76);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(158, 29);
            this.button4.TabIndex = 9;
            this.button4.Text = "Track investment";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.buttonTrackInvestment_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButtonThreeMonth);
            this.panel2.Controls.Add(this.radioButtonOneYear);
            this.panel2.Controls.Add(this.radioButtonHalfYear);
            this.panel2.Controls.Add(this.radioButtonOneMonth);
            this.panel2.Controls.Add(this.radioButtonOneWeek);
            this.panel2.Controls.Add(this.textPeriod);
            this.panel2.Location = new System.Drawing.Point(112, 423);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 80);
            this.panel2.TabIndex = 16;
            // 
            // radioButtonThreeMonth
            // 
            this.radioButtonThreeMonth.AutoSize = true;
            this.radioButtonThreeMonth.Location = new System.Drawing.Point(113, 17);
            this.radioButtonThreeMonth.Name = "radioButtonThreeMonth";
            this.radioButtonThreeMonth.Size = new System.Drawing.Size(83, 17);
            this.radioButtonThreeMonth.TabIndex = 7;
            this.radioButtonThreeMonth.TabStop = true;
            this.radioButtonThreeMonth.Text = "ThreeMonth";
            this.radioButtonThreeMonth.UseVisualStyleBackColor = true;
            this.radioButtonThreeMonth.CheckedChanged += new System.EventHandler(this.radioButtonThreeMonth_CheckedChanged);
            // 
            // radioButtonOneYear
            // 
            this.radioButtonOneYear.AutoSize = true;
            this.radioButtonOneYear.Location = new System.Drawing.Point(113, 60);
            this.radioButtonOneYear.Name = "radioButtonOneYear";
            this.radioButtonOneYear.Size = new System.Drawing.Size(68, 17);
            this.radioButtonOneYear.TabIndex = 6;
            this.radioButtonOneYear.TabStop = true;
            this.radioButtonOneYear.Text = "One year";
            this.radioButtonOneYear.UseVisualStyleBackColor = true;
            this.radioButtonOneYear.CheckedChanged += new System.EventHandler(this.radioButtonOneYear_CheckedChanged);
            // 
            // radioButtonHalfYear
            // 
            this.radioButtonHalfYear.AutoSize = true;
            this.radioButtonHalfYear.Location = new System.Drawing.Point(113, 40);
            this.radioButtonHalfYear.Name = "radioButtonHalfYear";
            this.radioButtonHalfYear.Size = new System.Drawing.Size(67, 17);
            this.radioButtonHalfYear.TabIndex = 5;
            this.radioButtonHalfYear.TabStop = true;
            this.radioButtonHalfYear.Text = "Half year";
            this.radioButtonHalfYear.UseVisualStyleBackColor = true;
            this.radioButtonHalfYear.CheckedChanged += new System.EventHandler(this.radioButtonHalfYear_CheckedChanged);
            // 
            // radioButtonOneMonth
            // 
            this.radioButtonOneMonth.AutoSize = true;
            this.radioButtonOneMonth.Location = new System.Drawing.Point(22, 60);
            this.radioButtonOneMonth.Name = "radioButtonOneMonth";
            this.radioButtonOneMonth.Size = new System.Drawing.Size(77, 17);
            this.radioButtonOneMonth.TabIndex = 3;
            this.radioButtonOneMonth.TabStop = true;
            this.radioButtonOneMonth.Text = "One month";
            this.radioButtonOneMonth.UseVisualStyleBackColor = true;
            this.radioButtonOneMonth.CheckedChanged += new System.EventHandler(this.radioButtonOneMonth_CheckedChanged);
            // 
            // radioButtonOneWeek
            // 
            this.radioButtonOneWeek.AutoSize = true;
            this.radioButtonOneWeek.Location = new System.Drawing.Point(22, 40);
            this.radioButtonOneWeek.Name = "radioButtonOneWeek";
            this.radioButtonOneWeek.Size = new System.Drawing.Size(74, 17);
            this.radioButtonOneWeek.TabIndex = 2;
            this.radioButtonOneWeek.TabStop = true;
            this.radioButtonOneWeek.Text = "One week";
            this.radioButtonOneWeek.UseVisualStyleBackColor = true;
            this.radioButtonOneWeek.CheckedChanged += new System.EventHandler(this.radioButtonOneWeek_CheckedChanged);
            // 
            // textPeriod
            // 
            this.textPeriod.Enabled = false;
            this.textPeriod.Location = new System.Drawing.Point(14, 14);
            this.textPeriod.Name = "textPeriod";
            this.textPeriod.Size = new System.Drawing.Size(82, 20);
            this.textPeriod.TabIndex = 0;
            this.textPeriod.Text = "Select period";
            this.textPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listBoxInvestments
            // 
            this.listBoxInvestments.DataSource = this.investmentsBindingSource;
            this.listBoxInvestments.FormattingEnabled = true;
            this.listBoxInvestments.Location = new System.Drawing.Point(580, 145);
            this.listBoxInvestments.Name = "listBoxInvestments";
            this.listBoxInvestments.Size = new System.Drawing.Size(123, 251);
            this.listBoxInvestments.TabIndex = 17;
            // 
            // investmentsBindingSource
            // 
            this.investmentsBindingSource.DataSource = typeof(SMoGu.App.Investments);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 515);
            this.Controls.Add(this.listBoxInvestments);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.buttonForCreateInvestment);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonForCreateGrafic);
            this.Controls.Add(this.chart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.investmentsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button buttonForCreateGrafic;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button buttonForCreateInvestment;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textPeriod;
        private System.Windows.Forms.RadioButton radioButtonHalfYear;
        private System.Windows.Forms.RadioButton radioButtonOneMonth;
        private System.Windows.Forms.RadioButton radioButtonOneWeek;
        private System.Windows.Forms.RadioButton radioButtonOneYear;
        private System.Windows.Forms.RadioButton radioButtonThreeMonth;
        private System.Windows.Forms.ListBox listBoxInvestments;
        private System.Windows.Forms.BindingSource investmentsBindingSource;
    }
}

