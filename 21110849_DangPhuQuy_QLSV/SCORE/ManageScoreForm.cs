using Microsoft.Office.Interop.Word;
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
    public partial class ManageScoreForm : Form
    {
        STUDENTs student = new STUDENTs();
        COURSE course = new COURSE();
        SCORE score = new SCORE();

        public ManageScoreForm()
        {
            InitializeComponent();
        }

        private void ManageScoreForm_Load(object sender, EventArgs e)
        {
            //lay thong tin all course
            cbSelectedCourse.DataSource = course.getAllCourse();
            cbSelectedCourse.DisplayMember = "label";
            cbSelectedCourse.ValueMember = "id";

            //dua no voi student
            SqlCommand cmd = new SqlCommand("select id, fname, lname from std");
            dgvStdAndScore.DataSource = student.getStudents(cmd);
        }

        private void btnShowStd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select id, fname, lname from std");
            dgvStdAndScore.DataSource = student.getStudents(cmd);

            //Đổi tên
            dgvStdAndScore.Columns["id"].HeaderText = "Id";
            dgvStdAndScore.Columns["fname"].HeaderText = "First name";
            dgvStdAndScore.Columns["lname"].HeaderText = "Last name";
        }

        private void dgvStdAndScore_Click(object sender, EventArgs e)
        {
            //get the id of the selected student
            tbId.Text = dgvStdAndScore.CurrentRow.Cells[0].Value.ToString();
            if (dgvStdAndScore.Columns.Count > 3)
            {
                cbSelectedCourse.Text = dgvStdAndScore.CurrentRow.Cells[4].Value.ToString();
                tbScore.Text = dgvStdAndScore.CurrentRow.Cells[5].Value.ToString();
            }
            
        }

        private void btnShowScore_Click(object sender, EventArgs e)
        {
            dgvStdAndScore.DataSource = score.getStudentScore();

            //đổi tên cột
            dgvStdAndScore.Columns["id"].HeaderText = "Id";
            dgvStdAndScore.Columns["fname"].HeaderText = "First name";
            dgvStdAndScore.Columns["lname"].HeaderText = "Last name";
            dgvStdAndScore.Columns["course_id"].HeaderText = "Course ID";
            dgvStdAndScore.Columns["label"].HeaderText = "Course name";
            dgvStdAndScore.Columns["student_score"].HeaderText = "Student score";

        }

        private void btnAvgScore_Click(object sender, EventArgs e)
        {
            AverageScoreByCourse avgScoreFrm = new AverageScoreByCourse();
            avgScoreFrm.Show(this);
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
            catch (Exception ex)
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvStdAndScore.Columns.Count > 3)
            {
                int studentId = Convert.ToInt32(tbId.Text);
                int courseId = Convert.ToInt32(dgvStdAndScore.CurrentRow.Cells[3].Value.ToString());
                if (score.deleteScore(studentId, courseId))
                {
                    MessageBox.Show("The Score has been deleted", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvStdAndScore.DataSource = score.getStudentScore();
                }
                else
                {
                    MessageBox.Show("The Score has not been deleted", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }

}
