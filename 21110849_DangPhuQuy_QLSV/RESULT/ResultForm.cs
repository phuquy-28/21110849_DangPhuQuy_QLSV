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
    public partial class ResultForm : Form
    {
        public ResultForm()
        {
            InitializeComponent();
        }
        SCORE score = new SCORE();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            dgvResult.DataSource = score.getResultStudent();

            dgvResult.Columns[0].HeaderText = "ID";
            dgvResult.Columns[1].HeaderText = "FirstName";
            dgvResult.Columns[2].HeaderText = "LastName";
            dgvResult.Columns[3].HeaderText = "Average";
            dgvResult.Columns[4].HeaderText = "Result";
        }
    }
}
