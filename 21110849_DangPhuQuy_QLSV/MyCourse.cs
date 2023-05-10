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
    public partial class MyCourse : Form
    {
        public MyCourse()
        {
            InitializeComponent();
            //cbSem.SelectedIndex = 0;
        }
        MY_DB mydb = new MY_DB();

        private void MyCourse_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from std where Id = @id", mydb.getConnection);
            command.Parameters.Add("id", SqlDbType.Int).Value = Convert.ToInt32(labelId.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            labelName.Text = table.Rows[0]["fname"].ToString() + " " +table.Rows[0]["lname"].ToString();
            //loadDgvCourse(Convert.ToInt32(cbSem.Text));
        }

        private void loadDgvCourse()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            command.CommandText = "SELECT course_id, label, period, dbo.course.description " +
                "FROM dbo.score JOIN dbo.course ON course_id = dbo.course.id " +
                "JOIN dbo.std ON student_id = dbo.std.Id " +
                "WHERE std.Id = @id and semester = @sem";
            command.Parameters.Add("id", SqlDbType.Int).Value = Convert.ToInt32(labelId.Text);
            command.Parameters.Add("sem", SqlDbType.Int).Value = Convert.ToInt32(cbSem.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dgvMyCourses.DataSource = table;
            dgvMyCourses.Columns["course_id"].HeaderText = "Course Id";
            dgvMyCourses.Columns["label"].HeaderText = "Course name";
            dgvMyCourses.Columns["period"].HeaderText = "Period";
            dgvMyCourses.Columns["description"].HeaderText = "Description";
        }

        private void cbSem_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDgvCourse();
        }
    }
}
