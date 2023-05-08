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
    public partial class CourseContactForm : Form
    {
        public CourseContactForm()
        {
            InitializeComponent();
            //cbSem.SelectedIndex = 0;
        }
        MY_DB mydb = new MY_DB();

        private void CourseContactForm_Load(object sender, EventArgs e)
        {
            
        }

        private void cbSem_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select course.id as [Course Id], course.label [Course name]" +
                "from mycontact join course_contact on mycontact.id = course_contact.contact_id " +
                "join course on course_contact.course_id = course.id " +
                "where mycontact.id = @ctid and course.semester = @sem ", mydb.getConnection);
            command.Parameters.Add("ctid", SqlDbType.Int).Value = Convert.ToInt32(tbContactId.Text.ToString());
            command.Parameters.Add("sem", SqlDbType.Int).Value = Convert.ToInt32(cbSem.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dgvCourseContact.DataSource = table;
        }

        private void dgvCourseContact_DoubleClick(object sender, EventArgs e)
        {
            CourseStudentListForm courseListFrm = new CourseStudentListForm();

            courseListFrm.labelCourseId.Text = dgvCourseContact.CurrentRow.Cells["Course Id"].Value.ToString();
            courseListFrm.labelCourseName.Text = dgvCourseContact.CurrentRow.Cells["Course name"].Value.ToString();
            courseListFrm.labelSemester.Text = cbSem.Text;

            courseListFrm.lbLecturer.Visible = true;

            courseListFrm.lbLecName.Visible = true;

            courseListFrm.lbLecName.Text = lbName.Text;

            courseListFrm.Show(this);
        }
    }
}
