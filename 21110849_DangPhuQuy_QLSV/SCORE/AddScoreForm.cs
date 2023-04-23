using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110849_DangPhuQuy_QLSV
{
    public partial class AddScoreForm : Form
    {
        public AddScoreForm()
        {
            InitializeComponent();
        }

        SCORE score = new SCORE();
        COURSE course = new COURSE();
        STUDENTs student = new STUDENTs();

        private void AddScoreForm_Load(object sender, EventArgs e)
        {
            //lay thong tin all course
            cbSelectedCourse.DataSource = course.getAllCourse();
            cbSelectedCourse.DisplayMember = "label";
            cbSelectedCourse.ValueMember = "id";

            //dua no voi student
            SqlCommand cmd = new SqlCommand("select id, fname, lname from std");
            dgvListScore.DataSource = student.getStudents(cmd);

            //đổi tên cột
            dgvListScore.Columns["id"].HeaderText = "Id";
            dgvListScore.Columns["fname"].HeaderText = "First name";
            dgvListScore.Columns["lname"].HeaderText = "Last name";
        }

        private void dgvListScore_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //get the id of the selected student
            tbId.Text = dgvListScore.CurrentRow.Cells[0].Value.ToString();
        }

        bool isValidScore(float score)
        {
            if (score >= 0 && score <= 10)
                return true;
            return false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int studentId = Convert.ToInt32(tbId.Text);
                int courseId = Convert.ToInt32(cbSelectedCourse.SelectedValue);
                decimal scorevalue_temp = Convert.ToDecimal(tbScore.Text);
                float scoreValue = (float)scorevalue_temp;
                string descript = rtbDes.Text;

                if (!isValidScore(scoreValue))
                {
                    MessageBox.Show("The score must between 0 to 10", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //check if the score is already set for this student on this course
                if (!score.studentScoreExist(studentId, courseId))
                {
                    if (score.insertScore(studentId, courseId, scoreValue, descript))
                    {
                        tbId.Text = "";
                        cbSelectedCourse.SelectedIndex = -1;
                        tbScore.Text = "";
                        rtbDes.Text = "";
                        MessageBox.Show("Student Score Inserted", "Add score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Student Score not Inserted", "Add score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("This score for this course have already set", "Add score", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Add score", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void isDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only input digits, control keys
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Only enter digits", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }
    }
}
