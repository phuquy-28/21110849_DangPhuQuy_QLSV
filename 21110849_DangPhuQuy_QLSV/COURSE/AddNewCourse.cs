using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110849_DangPhuQuy_QLSV
{
    public partial class AddNewCourse : Form
    {
        COURSE course = new COURSE();
        public AddNewCourse()
        {
            InitializeComponent();
            this.AcceptButton = btnAdd;
            cbSem.SelectedIndex = 0;
        }
        
        bool checkPeriod(int period)
        {
            return period >= 30;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbID.Text);
            string label = tbLabel.Text;
            int period = Convert.ToInt32(tbPeriod.Text);
            string des = rtbDes.Text;
            int semester = Convert.ToInt32(cbSem.Text);


            if (label.Trim() == "")
            {
                MessageBox.Show("A Course Name is null", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!checkPeriod(period))
            {
                MessageBox.Show("The Period must greater than 30", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (course.checkCourseName(label))
            {
                try
                {
                    if (course.insertCourse(id, label, period, des, semester))
                    {
                        tbID.Text = "";
                        tbLabel.Text = "";
                        tbPeriod.Text = "";
                        rtbDes.Text = "";
                        MessageBox.Show("New Course Inserted", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
