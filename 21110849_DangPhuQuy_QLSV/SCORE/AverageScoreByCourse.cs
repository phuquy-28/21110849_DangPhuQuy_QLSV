using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110849_DangPhuQuy_QLSV
{
    public partial class AverageScoreByCourse : Form
    {
        SCORE score = new SCORE();
        public AverageScoreByCourse()
        {
            InitializeComponent();
        }

        private void AverageScore_Load(object sender, EventArgs e)
        {
            dgvAvgScore.DataSource = score.getAvgScoreCourse();

            //đổi tên
            dgvAvgScore.Columns["label"].HeaderText = "Course name";
            dgvAvgScore.Columns[1].HeaderText = "Average score";

        }
    }
}
