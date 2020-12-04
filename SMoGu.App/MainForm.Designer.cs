﻿namespace SMoGu.App
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
            this.solidGauge1 = new LiveCharts.WinForms.SolidGauge();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonThreeMonth = new System.Windows.Forms.RadioButton();
            this.radioButtonOneYear = new System.Windows.Forms.RadioButton();
            this.radioButtonHalfYear = new System.Windows.Forms.RadioButton();
            this.radioButtonOneMonth = new System.Windows.Forms.RadioButton();
            this.radioButtonOneWeek = new System.Windows.Forms.RadioButton();
            this.textPeriod = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // solidGauge1
            // 
            this.solidGauge1.Location = new System.Drawing.Point(752, 430);
            this.solidGauge1.Name = "solidGauge1";
            this.solidGauge1.Size = new System.Drawing.Size(200, 100);
            this.solidGauge1.TabIndex = 1;
            this.solidGauge1.Text = "solidGauge1";
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
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(336, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "Create grafic ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonCreateGrafic);
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
            this.radioButton1.TabStop = true;
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
            this.radioButton2.TabStop = true;
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
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "CNY/RUB";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(572, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(158, 29);
            this.button3.TabIndex = 8;
            this.button3.Text = "Create investment ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonCreateInvesment);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 515);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.solidGauge1);
            this.Name = "MainForm";
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private LiveCharts.WinForms.SolidGauge solidGauge1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textPeriod;
        private System.Windows.Forms.RadioButton radioButtonHalfYear;
        private System.Windows.Forms.RadioButton radioButtonOneMonth;
        private System.Windows.Forms.RadioButton radioButtonOneWeek;
        private System.Windows.Forms.RadioButton radioButtonOneYear;
        private System.Windows.Forms.RadioButton radioButtonThreeMonth;
    }
}

