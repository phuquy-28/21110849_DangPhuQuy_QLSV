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
    public partial class AverageScore : Form
    {
        SCORE score = new SCORE();
        public AverageScore()
        {
            InitializeComponent();
        }

        private void AverageScore_Load(object sender, EventArgs e)
        {
            dgvAvgScore.DataSource = score.getAvgScoreCourse();
        }
    }
}
