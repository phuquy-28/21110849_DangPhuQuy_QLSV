using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110849_DangPhuQuy_QLSV
{
    public partial class ManageCourseForm : Form
    {
        public ManageCourseForm()
        {
            InitializeComponent();
        }

        COURSE course = new COURSE();
        int pos;

        private void ManageCourseForm_Load(object sender, EventArgs e)
        {
            reLoadListBoxData();
        }

        void reLoadListBoxData()
        {
            lisbCourse.DataSource = course.getAllCourse();
            lisbCourse.ValueMember = "id";
            lisbCourse.DisplayMember = "label";

            lisbCourse.SelectedItem = null;

            lbTotalCourse.Text = ("Total Course: " + course.totalCourse().ToString());
        }

        //Dùng để lấy data theo chỉ mục index, dùng datarow để lấy dữ liệu hàng của table 
        void showData(int index)
        {
            DataRow dr = course.getAllCourse().Rows[index];

            lisbCourse.SelectedIndex = index;
            tbID.Text = dr.ItemArray[0].ToString();
            tbLabel.Text = dr.ItemArray[1].ToString();
            numPeriod.Value = Convert.ToInt32(dr.ItemArray[2].ToString());
            rtbDes.Text = dr.ItemArray[3].ToString();
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbID.Text);
            string label = tbLabel.Text;
            int period = Convert.ToInt32(numPeriod.Text);
            string des = rtbDes.Text;


            if (label.Trim() == "")
            {
                MessageBox.Show("A Course Name is null", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (course.checkCourseName(label))
            {
                try
                {
                    if (course.insertCourse(id, label, period, des))
                    {
                        MessageBox.Show("New Course Inserted", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbID.Text = "";
                        tbLabel.Text = "";
                        numPeriod.Value = 10;
                        rtbDes.Text = "";

                        reLoadListBoxData();
                    }
                    else
                    {
                        MessageBox.Show("Course Not Inserted", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("ID đã tồn tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Course have already exist", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string name = tbLabel.Text;
            int hrs = Convert.ToInt32(numPeriod.Value);
            string descrip = rtbDes.Text;
            int id = Convert.ToInt32(tbID.Text);

            //lấy lại phần kiểm tra tên course
            if (!course.checkCourseName(name, Convert.ToInt32(tbID.Text)))
            {
                MessageBox.Show("This Coursename has already exist", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (course.updateCourse(id, name, hrs, descrip))
            {
                MessageBox.Show("Course updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reLoadListBoxData();
            }
            else
            {
                MessageBox.Show("Course not updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            pos = 0;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int cID = Convert.ToInt32(tbID.Text);

                if (MessageBox.Show("Are you sure you want to delete this course", "Remove course", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (course.deleteCourse(cID))
                    {
                        MessageBox.Show("Course Deleted", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbID.Text = "";
                        tbLabel.Text = "";
                        numPeriod.Value = 10;
                        rtbDes.Text = "";

                        reLoadListBoxData();
                    }
                    else
                    {
                        MessageBox.Show("Course is not Deleted", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Enter a numeric", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            pos = 0;
        }

        private void lisbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lisbCourse_Click(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)lisbCourse.SelectedItem;
            pos = lisbCourse.SelectedIndex;
            showData(pos);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            pos = 0;
            showData(pos);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            pos = course.totalCourse() - 1;
            showData(pos);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pos < course.totalCourse() - 1)
            {
                pos++;
                showData(pos);
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (pos > 0)
            {
                pos--;
                showData(pos);
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

        private void lisbCourse_DoubleClick(object sender, EventArgs e)
        {
            CourseListForm courseListFrm = new CourseListForm();
            

            int index = lisbCourse.SelectedIndex;
            DataRow dr = course.getAllCourse().Rows[index];

            courseListFrm.tbCourseName.Clear();
            courseListFrm.tbCourseName.Text = dr.ItemArray[1].ToString();

            courseListFrm.Show(this);
        }
    }
}
