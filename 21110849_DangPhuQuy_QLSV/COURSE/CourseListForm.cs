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
    public partial class CourseListForm : Form
    {
        public CourseListForm()
        {
            InitializeComponent();
        }
        SCORE score = new SCORE();

        private void dgvCourseStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CourseListForm_Load(object sender, EventArgs e)
        {
            string temp = tbCourseName.Text.ToString().Trim();
            dgvCourseStudent.DataSource = score.getCourseScore(temp);

            dgvCourseStudent.Columns[0].HeaderText = "Id";
            dgvCourseStudent.Columns[1].HeaderText = "FirstName";
            dgvCourseStudent.Columns[2].HeaderText = "LastName";
            dgvCourseStudent.Columns[3].HeaderText = "CourseID";
            dgvCourseStudent.Columns[4].HeaderText = "CourseName";
            dgvCourseStudent.Columns[5].HeaderText = "StudentCourse";

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
