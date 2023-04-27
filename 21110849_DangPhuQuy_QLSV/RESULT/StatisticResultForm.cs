using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Font = System.Drawing.Font;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;

namespace _21110849_DangPhuQuy_QLSV
{
    public partial class StatisticResultForm : Form
    {
        public StatisticResultForm()
        {
            InitializeComponent();
        }
        SCORE score = new SCORE();

        private void StatisticResultForm_Load(object sender, EventArgs e)
        {
            // Tạo series cho biểu đồ cột
            Series series = new Series();
            series.Name = "AVG Score";
            series.ChartType = SeriesChartType.Column;
            series.XValueMember = "label";
            series.YValueMembers = "AverageScore";
            series.IsValueShownAsLabel = true;
            series.IsVisibleInLegend = true;

            // Thiết lập dữ liệu nguồn cho biểu đồ
            chartByCourse.DataSource = score.getAvgScoreCourse();
            chartByCourse.Series.Add(series);
            chartByCourse.DataBind();

            chartByCourse.Palette = ChartColorPalette.SeaGreen;
            chartByCourse.Titles.Add("Statistic By Course");
            chartByCourse.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);

            // Hiển thị biểu đồ cột trên form
            Controls.Add(chartByCourse);


            // Tạo series cho biểu đồ cột
            Series series2 = new Series();
            series2.Name = "Students";
            series2.ChartType = SeriesChartType.Pie;
            series2.IsValueShownAsLabel = true;

            // Thiết lập dữ liệu nguồn cho series
            series2.Points.AddXY("Pass", Convert.ToInt32(score.getNumPass()));
            series2.Points.AddXY("Fail", Convert.ToInt32(score.getNumFail()));


            chartByResult.Series.Add(series2);
            chartByResult.Palette = ChartColorPalette.SeaGreen;
            chartByResult.Titles.Add("Statistic By Result");
            chartByResult.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);

            // Hiển thị biểu đồ cột trên form
            Controls.Add(chartByResult);
        }

    }
}
