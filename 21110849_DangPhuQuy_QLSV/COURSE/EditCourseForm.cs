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
    public partial class EditCourseForm : Form
    {
        COURSE course = new COURSE();
        public EditCourseForm()
        {
            InitializeComponent();
        }

        private void EditCourseForm_Load(object sender, EventArgs e)
        {
            cbSelectedCourse.DataSource = course.getAllCourse();
            cbSelectedCourse.DisplayMember = "label";
            cbSelectedCourse.ValueMember = "id";

            cbSelectedCourse.SelectedItem = null;
        }

        //course name and id
        public void fillCombo(int index)
        {
            cbSelectedCourse.DataSource = course.getAllCourse();
            cbSelectedCourse.DisplayMember= "label";
            cbSelectedCourse.ValueMember = "id";
            cbSelectedCourse.SelectedIndex = index;
        }

        //khi selected index changed
        private void cbSelectedCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //lay du lieu
                int id = Convert.ToInt32(cbSelectedCourse.SelectedValue);
                DataTable table = new DataTable();
                table = course.getCourseById(id);
                tbCName.Text = table.Rows[0][1].ToString();
                numericUpDownPeriod.Value = Convert.ToInt32(table.Rows[0][2].ToString());
                rtbDes.Text = table.Rows[0][3].ToString();
            }
            catch { }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string name = tbCName.Text;
            int hrs = Convert.ToInt32(numericUpDownPeriod.Value);
            string descrip = rtbDes.Text;
            int id = Convert.ToInt32(cbSelectedCourse.SelectedValue);

            //lấy lại phần kiểm tra tên course
            if(!course.checkCourseName(name, Convert.ToInt32(cbSelectedCourse.SelectedValue)))
            {
                MessageBox.Show("This Coursename has already exist", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if(course.updateCourse(id, name, hrs, descrip))
            {
                MessageBox.Show("Course updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillCombo(cbSelectedCourse.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Course not updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
