namespace _21110849_DangPhuQuy_QLSV
{
    partial class StatisticForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartGender = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelTotal = new System.Windows.Forms.Panel();
            this.lbTotal = new System.Windows.Forms.Label();
            this.panelFemale = new System.Windows.Forms.Panel();
            this.lbFemale = new System.Windows.Forms.Label();
            this.panelMale = new System.Windows.Forms.Panel();
            this.lbMale = new System.Windows.Forms.Label();
            this.chartGenderPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartGender)).BeginInit();
            this.panelTotal.SuspendLayout();
            this.panelFemale.SuspendLayout();
            this.panelMale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGenderPie)).BeginInit();
            this.SuspendLayout();
            // 
            // chartGender
            // 
            chartArea1.Name = "ChartArea1";
            this.chartGender.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartGender.Legends.Add(legend1);
            this.chartGender.Location = new System.Drawing.Point(354, 12);
            this.chartGender.Name = "chartGender";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Students";
            this.chartGender.Series.Add(series1);
            this.chartGender.Size = new System.Drawing.Size(366, 497);
            this.chartGender.TabIndex = 0;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "chartGender";
            title1.Text = "Gender Chart";
            this.chartGender.Titles.Add(title1);
            // 
            // panelTotal
            // 
            this.panelTotal.Controls.Add(this.lbTotal);
            this.panelTotal.Location = new System.Drawing.Point(12, 12);
            this.panelTotal.Name = "panelTotal";
            this.panelTotal.Size = new System.Drawing.Size(262, 100);
            this.panelTotal.TabIndex = 1;
            // 
            // lbTotal
            // 
            this.lbTotal.BackColor = System.Drawing.Color.Aquamarine;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(0, 0);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(262, 100);
            this.lbTotal.TabIndex = 1;
            this.lbTotal.Text = "Total";
            this.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelFemale
            // 
            this.panelFemale.Controls.Add(this.lbFemale);
            this.panelFemale.Location = new System.Drawing.Point(12, 118);
            this.panelFemale.Name = "panelFemale";
            this.panelFemale.Size = new System.Drawing.Size(128, 100);
            this.panelFemale.TabIndex = 2;
            // 
            // lbFemale
            // 
            this.lbFemale.BackColor = System.Drawing.Color.DarkViolet;
            this.lbFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFemale.Location = new System.Drawing.Point(0, 0);
            this.lbFemale.Name = "lbFemale";
            this.lbFemale.Size = new System.Drawing.Size(128, 100);
            this.lbFemale.TabIndex = 0;
            this.lbFemale.Text = "Famale";
            this.lbFemale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMale
            // 
            this.panelMale.Controls.Add(this.lbMale);
            this.panelMale.Location = new System.Drawing.Point(146, 118);
            this.panelMale.Name = "panelMale";
            this.panelMale.Size = new System.Drawing.Size(128, 100);
            this.panelMale.TabIndex = 3;
            // 
            // lbMale
            // 
            this.lbMale.BackColor = System.Drawing.Color.DarkViolet;
            this.lbMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMale.Location = new System.Drawing.Point(0, 0);
            this.lbMale.Name = "lbMale";
            this.lbMale.Size = new System.Drawing.Size(128, 100);
            this.lbMale.TabIndex = 1;
            this.lbMale.Text = "Male";
            this.lbMale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartGenderPie
            // 
            chartArea2.Name = "ChartArea1";
            this.chartGenderPie.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartGenderPie.Legends.Add(legend2);
            this.chartGenderPie.Location = new System.Drawing.Point(12, 251);
            this.chartGenderPie.Name = "chartGenderPie";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Students";
            this.chartGenderPie.Series.Add(series2);
            this.chartGenderPie.Size = new System.Drawing.Size(258, 258);
            this.chartGenderPie.TabIndex = 4;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "chartGender";
            title2.Text = "Gender Chart";
            this.chartGenderPie.Titles.Add(title2);
            // 
            // StatisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 521);
            this.Controls.Add(this.chartGenderPie);
            this.Controls.Add(this.panelMale);
            this.Controls.Add(this.panelFemale);
            this.Controls.Add(this.panelTotal);
            this.Controls.Add(this.chartGender);
            this.Name = "StatisticForm";
            this.Text = "StatisticForm";
            this.Load += new System.EventHandler(this.StatisticForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartGender)).EndInit();
            this.panelTotal.ResumeLayout(false);
            this.panelFemale.ResumeLayout(false);
            this.panelMale.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartGenderPie)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartGender;
        private System.Windows.Forms.Panel panelTotal;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Panel panelFemale;
        private System.Windows.Forms.Label lbFemale;
        private System.Windows.Forms.Panel panelMale;
        private System.Windows.Forms.Label lbMale;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGenderPie;
    }
}