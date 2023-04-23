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
    public partial class AddCourseStudentForm : Form
    {
        public AddCourseStudentForm()
        {
            InitializeComponent();
        }
        COURSE course = new COURSE();
        SCORE score = new SCORE();

        private void AddCourseStudentForm_Load(object sender, EventArgs e)
        {
            reLoadListBoxData();
        }

        void reLoadListBoxData()
        {
            lisbAvail.DataSource = course.getAllCourse();
            lisbAvail.ValueMember = "id";
            lisbAvail.DisplayMember = "label";

            lisbAvail.SelectedItem = null;

            lbTotalCourse.Text = ("Total Course: " + course.totalCourse().ToString());
        }

        
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lisbAvail.SelectedItem != null) // Kiểm tra nếu có item được chọn trong lisbAvail
            {
                // Lấy ra dòng đã chọn trong ListBox
                DataRowView selectedRow = (DataRowView)lisbAvail.SelectedItem;

                //Them khoa hoc cho sinh vien
                int sid = Convert.ToInt32(tbStdId.Text);
                int cid = (int)selectedRow["id"];

                // Thêm bản sao này vào ListBox
                lisbSelected.Items.Add(selectedRow);
                lisbSelected.ValueMember = "id";
                lisbSelected.DisplayMember = "label";

                //if (!score.studentExist(sid, cid))
                //{
                //    score.insertScore(sid, cid);
                //}
                //else
                //{
                //    MessageBox.Show("Thêm khoá học không thành công", "Add Course Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}

                // Lấy ra DataTable đã liên kết với ListBox
                DataTable dt = (DataTable)lisbAvail.DataSource;
                dt.Rows.Remove(selectedRow.Row);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lưu lại thành công", "Add Course Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
