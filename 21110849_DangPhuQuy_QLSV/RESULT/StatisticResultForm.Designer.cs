namespace _21110849_DangPhuQuy_QLSV
{
    partial class StatisticResultForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartByCourse = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartByResult = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartByCourse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartByResult)).BeginInit();
            this.SuspendLayout();
            // 
            // chartByCourse
            // 
            chartArea1.Name = "ChartArea1";
            this.chartByCourse.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartByCourse.Legends.Add(legend1);
            this.chartByCourse.Location = new System.Drawing.Point(12, 12);
            this.chartByCourse.Name = "chartByCourse";
            this.chartByCourse.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Enabled = false;
            series1.Legend = "Legend1";
            series1.Name = "Average Score";
            this.chartByCourse.Series.Add(series1);
            this.chartByCourse.Size = new System.Drawing.Size(484, 499);
            this.chartByCourse.TabIndex = 2;
            this.chartByCourse.Text = "chart1";
            // 
            // chartByResult
            // 
            chartArea2.Name = "ChartArea1";
            this.chartByResult.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartByResult.Legends.Add(legend2);
            this.chartByResult.Location = new System.Drawing.Point(522, 12);
            this.chartByResult.Name = "chartByResult";
            this.chartByResult.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series2.ChartArea = "ChartArea1";
            series2.Enabled = false;
            series2.Legend = "Legend1";
            series2.Name = "Average Score";
            this.chartByResult.Series.Add(series2);
            this.chartByResult.Size = new System.Drawing.Size(469, 499);
            this.chartByResult.TabIndex = 3;
            this.chartByResult.Text = "chart1";
            // 
            // StatisticResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 522);
            this.Controls.Add(this.chartByResult);
            this.Controls.Add(this.chartByCourse);
            this.Name = "StatisticResultForm";
            this.Text = "StatisticResultForm";
            this.Load += new System.EventHandler(this.StatisticResultForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartByCourse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartByResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chartByCourse;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartByResult;
    }
}