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
    public partial class StatisticResultForm : Form
    {
        public StatisticResultForm()
        {
            InitializeComponent();
        }
        SCORE score = new SCORE();

        private void StatisticResultForm_Load(object sender, EventArgs e)
        {
            dgvAvgCourseScore.DataSource = score.getAvgScoreCourse();
        }
    }
}
