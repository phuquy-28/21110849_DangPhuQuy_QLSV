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
    public partial class AddCourseStudentForm : Form
    {
        public AddCourseStudentForm()
        {
            InitializeComponent();
            cbSemester.SelectedIndex = 0;
        }
        MY_DB mydb = new MY_DB();
        COURSE course = new COURSE();
        SCORE score = new SCORE();
        List<int> courseList = new List<int>();

        private void AddCourseStudentForm_Load(object sender, EventArgs e)
        {
            reLoadListBoxData();
        }

        void reLoadListBoxData()
        {
            lisbAvail.DataSource = course.getCourseBySem(Convert.ToInt32(cbSemester.Text));
            lisbAvail.ValueMember = "id";
            lisbAvail.DisplayMember = "label";
            lisbAvail.SelectedItem = null;

            lisbSelected.Items.Clear();

            lbTotalCourse.Text = ("Total Course: " + course.totalCourse().ToString());
        }

        
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lisbAvail.SelectedItem != null) // Kiểm tra nếu có item được chọn trong lisbAvail
            {
                // Lấy ra dòng đã chọn trong ListBox
                DataRowView selectedRow = (DataRowView)lisbAvail.SelectedItem;

                //Them ma khoa hoc vao listcourse
                int cid = (int)selectedRow["id"];
                courseList.Add(cid);

                // Thêm bản sao này vào ListBox
                lisbSelected.Items.Add(selectedRow);
                lisbSelected.ValueMember = "id";
                lisbSelected.DisplayMember = "label";

                // Lấy ra DataTable đã liên kết với ListBox
                DataTable dt = (DataTable)lisbAvail.DataSource;
                dt.Rows.Remove(selectedRow.Row);
            }

        }

        public bool isExist(int studentId , int courseId)
        {
            SqlCommand command = new SqlCommand("select * from course_student where student_id = @sid and course_id = @cid", mydb.getConnection);
            command.Parameters.Add("sid", SqlDbType.Int).Value = studentId;
            command.Parameters.Add("cid", SqlDbType.Int).Value = courseId;

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int flag = 1;
            
            
            foreach (var i in courseList)
            {
                if (!isExist(Convert.ToInt32(tbStdId.Text), (Int32)i))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = mydb.getConnection;
                    command.CommandText = "insert into course_student (course_id, student_id) values (@cid, @sid)";
                    command.Parameters.Add("sid", SqlDbType.Int).Value = Convert.ToInt32(tbStdId.Text);
                    command.Parameters.Add("cid", SqlDbType.Int).Value = (Int32)i;
                    mydb.openConnection();
                    if (command.ExecuteNonQuery() == 0)
                        flag = 0;
                    mydb.closeConnection();
                }
                else
                    flag = 0;
            }

            if (flag == 1)
            {
                MessageBox.Show("Adding successfully", "Add Course Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Some courses have been added", "Add Course Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddCourseStudentForm_Load(null, null);
        }
    }
}
