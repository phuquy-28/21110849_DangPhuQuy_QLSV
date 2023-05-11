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
    public partial class MyResultForm : Form
    {
        public MyResultForm()
        {
            InitializeComponent();
        }
        MY_DB mydb = new MY_DB();
        SCORE score = new SCORE();


        private void MyResultForm_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from std where Id = @id", mydb.getConnection);
            command.Parameters.Add("id", SqlDbType.Int).Value = Convert.ToInt32(labelId.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            labelName.Text = table.Rows[0]["fname"].ToString() + " " + table.Rows[0]["lname"].ToString();
        }

        private void loadDgvCourse()
        {
            int id = Convert.ToInt32(labelId.Text.ToString());
            int sem = Convert.ToInt32(cbSem.Text.ToString());
            dgvMyResult.DataSource = score.getStudentResultDetail(id, sem);
            dgvMyResult.AllowUserToAddRows = false;

            dgvMyResult.Columns["course_id"].HeaderText = "Course Id";
            dgvMyResult.Columns["label"].HeaderText = "Course name";
            dgvMyResult.Columns["student_score"].HeaderText = "Score";
        }

        private void cbSem_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDgvCourse();
        }
    }
}
