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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonForCreateGrafic = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.buttonForCreateInvestment = new System.Windows.Forms.Button();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonThreeMonth = new System.Windows.Forms.RadioButton();
            this.radioButtonOneYear = new System.Windows.Forms.RadioButton();
            this.radioButtonHalfYear = new System.Windows.Forms.RadioButton();
            this.radioButtonOneMonth = new System.Windows.Forms.RadioButton();
            this.radioButtonOneWeek = new System.Windows.Forms.RadioButton();
            this.textPeriod = new System.Windows.Forms.TextBox();
            this.listBoxInvestments = new System.Windows.Forms.ListBox();
            this.buttonSort = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.chart1.Size = new System.Drawing.Size(541, 342);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            title1.BorderWidth = 3;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            title1.Name = "Title1";
            title1.Text = "Динамика курса";
            this.chart1.Titles.Add(title1);
            // 
            // buttonForCreateGrafic
            // 
            this.buttonForCreateGrafic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonForCreateGrafic.Location = new System.Drawing.Point(313, 32);
            this.buttonForCreateGrafic.Name = "buttonForCreateGrafic";
            this.buttonForCreateGrafic.Size = new System.Drawing.Size(142, 29);
            this.buttonForCreateGrafic.TabIndex = 3;
            this.buttonForCreateGrafic.Text = "Построить график";
            this.buttonForCreateGrafic.UseVisualStyleBackColor = true;
            this.buttonForCreateGrafic.Click += new System.EventHandler(this.ButtonCreateGrafic);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.Location = new System.Drawing.Point(146, 32);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(103, 29);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(24, 12);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(76, 17);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.Text = "USD/RUB";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(24, 35);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(76, 17);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.Text = "EUR/RUB";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(24, 58);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(75, 17);
            this.radioButton3.TabIndex = 7;
            this.radioButton3.Text = "CNY/RUB";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.RadioButton3_CheckedChanged);
            // 
            // buttonForCreateInvestment
            // 
            this.buttonForCreateInvestment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonForCreateInvestment.Location = new System.Drawing.Point(572, 32);
            this.buttonForCreateInvestment.Name = "buttonForCreateInvestment";
            this.buttonForCreateInvestment.Size = new System.Drawing.Size(166, 29);
            this.buttonForCreateInvestment.TabIndex = 8;
            this.buttonForCreateInvestment.Text = "Создать инвестицию";
            this.buttonForCreateInvestment.UseVisualStyleBackColor = true;
            this.buttonForCreateInvestment.Click += new System.EventHandler(this.ButtonCreateInvesment);
            // 
            // buttonInfo
            // 
            this.buttonInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonInfo.Location = new System.Drawing.Point(571, 429);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(167, 43);
            this.buttonInfo.TabIndex = 9;
            this.buttonInfo.Text = "Информация об инвестиции";
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.ButtonTrackInvestment_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButtonThreeMonth);
            this.panel2.Controls.Add(this.radioButtonOneYear);
            this.panel2.Controls.Add(this.radioButtonHalfYear);
            this.panel2.Controls.Add(this.radioButtonOneMonth);
            this.panel2.Controls.Add(this.radioButtonOneWeek);
            this.panel2.Controls.Add(this.textPeriod);
            this.panel2.Location = new System.Drawing.Point(12, 429);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(277, 64);
            this.panel2.TabIndex = 16;
            // 
            // radioButtonThreeMonth
            // 
            this.radioButtonThreeMonth.AutoSize = true;
            this.radioButtonThreeMonth.Location = new System.Drawing.Point(103, 43);
            this.radioButtonThreeMonth.Name = "radioButtonThreeMonth";
            this.radioButtonThreeMonth.Size = new System.Drawing.Size(72, 17);
            this.radioButtonThreeMonth.TabIndex = 7;
            this.radioButtonThreeMonth.TabStop = true;
            this.radioButtonThreeMonth.Text = "3 месяца";
            this.radioButtonThreeMonth.UseVisualStyleBackColor = true;
            this.radioButtonThreeMonth.CheckedChanged += new System.EventHandler(this.RadioButtonThreeMonth_CheckedChanged);
            // 
            // radioButtonOneYear
            // 
            this.radioButtonOneYear.AutoSize = true;
            this.radioButtonOneYear.Location = new System.Drawing.Point(199, 43);
            this.radioButtonOneYear.Name = "radioButtonOneYear";
            this.radioButtonOneYear.Size = new System.Drawing.Size(51, 17);
            this.radioButtonOneYear.TabIndex = 6;
            this.radioButtonOneYear.TabStop = true;
            this.radioButtonOneYear.Text = "1 год";
            this.radioButtonOneYear.UseVisualStyleBackColor = true;
            this.radioButtonOneYear.CheckedChanged += new System.EventHandler(this.RadioButtonOneYear_CheckedChanged);
            // 
            // radioButtonHalfYear
            // 
            this.radioButtonHalfYear.AutoSize = true;
            this.radioButtonHalfYear.Location = new System.Drawing.Point(199, 17);
            this.radioButtonHalfYear.Name = "radioButtonHalfYear";
            this.radioButtonHalfYear.Size = new System.Drawing.Size(78, 17);
            this.radioButtonHalfYear.TabIndex = 5;
            this.radioButtonHalfYear.TabStop = true;
            this.radioButtonHalfYear.Text = "6 месяцев";
            this.radioButtonHalfYear.UseVisualStyleBackColor = true;
            this.radioButtonHalfYear.CheckedChanged += new System.EventHandler(this.RadioButtonHalfYear_CheckedChanged);
            // 
            // radioButtonOneMonth
            // 
            this.radioButtonOneMonth.AutoSize = true;
            this.radioButtonOneMonth.Location = new System.Drawing.Point(103, 17);
            this.radioButtonOneMonth.Name = "radioButtonOneMonth";
            this.radioButtonOneMonth.Size = new System.Drawing.Size(66, 17);
            this.radioButtonOneMonth.TabIndex = 3;
            this.radioButtonOneMonth.TabStop = true;
            this.radioButtonOneMonth.Text = "1 месяц";
            this.radioButtonOneMonth.UseVisualStyleBackColor = true;
            this.radioButtonOneMonth.CheckedChanged += new System.EventHandler(this.RadioButtonOneMonth_CheckedChanged);
            // 
            // radioButtonOneWeek
            // 
            this.radioButtonOneWeek.AutoSize = true;
            this.radioButtonOneWeek.Location = new System.Drawing.Point(14, 43);
            this.radioButtonOneWeek.Name = "radioButtonOneWeek";
            this.radioButtonOneWeek.Size = new System.Drawing.Size(70, 17);
            this.radioButtonOneWeek.TabIndex = 2;
            this.radioButtonOneWeek.TabStop = true;
            this.radioButtonOneWeek.Text = "1 неделя";
            this.radioButtonOneWeek.UseVisualStyleBackColor = true;
            this.radioButtonOneWeek.CheckedChanged += new System.EventHandler(this.RadioButtonOneWeek_CheckedChanged);
            // 
            // textPeriod
            // 
            this.textPeriod.Enabled = false;
            this.textPeriod.Location = new System.Drawing.Point(6, 17);
            this.textPeriod.Name = "textPeriod";
            this.textPeriod.Size = new System.Drawing.Size(82, 20);
            this.textPeriod.TabIndex = 0;
            this.textPeriod.Text = "Период";
            this.textPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listBoxInvestments
            // 
            this.listBoxInvestments.FormattingEnabled = true;
            this.listBoxInvestments.Location = new System.Drawing.Point(572, 120);
            this.listBoxInvestments.Name = "listBoxInvestments";
            this.listBoxInvestments.ScrollAlwaysVisible = true;
            this.listBoxInvestments.Size = new System.Drawing.Size(166, 303);
            this.listBoxInvestments.TabIndex = 17;
            this.listBoxInvestments.SelectedIndexChanged += new System.EventHandler(this.ListBoxInvestments_SelectedIndexChanged);
            // 
            // buttonSort
            // 
            this.buttonSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.2F);
            this.buttonSort.Location = new System.Drawing.Point(572, 81);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(166, 33);
            this.buttonSort.TabIndex = 18;
            this.buttonSort.Text = "Сортировать по доходности";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.ButtonSort_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(750, 515);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.listBoxInvestments);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.buttonForCreateInvestment);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonForCreateGrafic);
            this.Controls.Add(this.chart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = " SMoGu";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button buttonForCreateGrafic;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button buttonForCreateInvestment;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textPeriod;
        private System.Windows.Forms.RadioButton radioButtonHalfYear;
        private System.Windows.Forms.RadioButton radioButtonOneMonth;
        private System.Windows.Forms.RadioButton radioButtonOneWeek;
        private System.Windows.Forms.RadioButton radioButtonOneYear;
        private System.Windows.Forms.RadioButton radioButtonThreeMonth;
        public System.Windows.Forms.ListBox listBoxInvestments;
        private System.Windows.Forms.Button buttonSort;
    }
}

