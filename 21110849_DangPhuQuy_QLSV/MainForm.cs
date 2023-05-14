using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using DataTable = System.Data.DataTable;

namespace _21110849_DangPhuQuy_QLSV
{
    public partial class MainForm : Form
    {
        public string Username { get; set; }
        public string TypeAccount { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }
        STUDENTs student = new STUDENTs();

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudentForm addStdF = new AddStudentForm();
            addStdF.Show(this);
        }

        private void studentsListsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentListForm stdListFrm = new StudentListForm();
            stdListFrm.Show(this);
        }

        private void staticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatisticForm statisticFrm = new StatisticForm();
            statisticFrm.Show(this);
        }

        private void managerStudentFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageStudentForm mngStudentFrm = new ManageStudentForm();
            mngStudentFrm.Show(this);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print printFrm = new Print();
            printFrm.Show(this);
        }

        private void aDDCORSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewCourse addCourseFrm = new AddNewCourse();
            addCourseFrm.Show(this);
        }

        private void removeCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveCourseForm removeCourseFrm = new RemoveCourseForm();
            removeCourseFrm.Show(this);
        }

        private void editCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCourseForm editCourseFrm = new EditCourseForm();
            editCourseFrm.Show(this);
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void manageCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageCourseForm mngCourseFrm = new ManageCourseForm();
            mngCourseFrm.Show(this);
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintCourseForm printCourseFrm = new PrintCourseForm();
            printCourseFrm.Show(this);
        }

        private void addScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScoreForm addScoreFrm = new AddScoreForm();
            addScoreFrm.Show(this);
        }

        private void averageScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AverageScoreByCourse avgScoreFrm = new AverageScoreByCourse();
            avgScoreFrm.Show(this);
        }

        private void removeScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveScoreForm removeScoreFrm = new RemoveScoreForm();
            removeScoreFrm.Show(this);
        }

        private void manageScoreToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ManageScoreForm mngScoreFrm = new ManageScoreForm();
            mngScoreFrm.Show(this);
        }

        private void editRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditRemoveStudentForm editRemoveStudentFrm = new EditRemoveStudentForm();
            editRemoveStudentFrm.Show(this);
        }

        private void pendingAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountForm accForm = new AccountForm();
            accForm.Show(this);
        }

        private void accountListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountListForm accListFrm = new AccountListForm();
            accListFrm.Show(this);
        }

        private void resultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintScoreForm printScoreFrm = new PrintScoreForm();
            printScoreFrm.Show(this);
        }

        private void statisticResultFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatisticResultForm statisticResultFrm = new StatisticResultForm();
            statisticResultFrm.Show(this);
        }

        private void resultFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResultForm resultFrm = new ResultForm();
            resultFrm.Show(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lbUname.Text = Username; 
        }

        private void myInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDeleteStudentForm updateDeleteStudentFrm = new UpdateDeleteStudentForm();
            updateDeleteStudentFrm.idTb.Text = lbUname.Text;
            updateDeleteStudentFrm.idTb.Enabled = false;
            updateDeleteStudentFrm.removeBtn.Visible = false;
            updateDeleteStudentFrm.findIdBtn.Visible = false;
            updateDeleteStudentFrm.findFNameBtn.Visible = false;
            updateDeleteStudentFrm.findPhoneBtn.Visible = false;
            updateDeleteStudentFrm.stateCb.Enabled = false;
            updateDeleteStudentFrm.facultyCb.Enabled = false;
            updateDeleteStudentFrm.majorCb.Enabled = false;

            int id = int.Parse(updateDeleteStudentFrm.idTb.Text);
            SqlCommand command = new SqlCommand("SELECT * FROM std WHERE id = " + id);

            DataTable table = student.getStudents(command);

            if (table.Rows.Count > 0)
            {
                //first name, last name, date of birth
                updateDeleteStudentFrm.firstnameTb.Text = table.Rows[0]["fname"].ToString();
                updateDeleteStudentFrm.lastnameTb.Text = table.Rows[0]["lname"].ToString();
                updateDeleteStudentFrm.dobDtp.Value = (DateTime)table.Rows[0]["bdate"];

                //gender
                if (table.Rows[0]["gender"].ToString() == "Female")
                {
                    updateDeleteStudentFrm.FemaleBtn.Checked = true;
                }
                else
                {
                    updateDeleteStudentFrm.maleBtn.Checked = true;
                }

                updateDeleteStudentFrm.phoneTB.Text = table.Rows[0]["phone"].ToString();
                updateDeleteStudentFrm.addressTb.Text = table.Rows[0]["address"].ToString();

                //picture
                byte[] pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                updateDeleteStudentFrm.picturePb.Image = Image.FromStream(picture);

                //email, faculty, major, place of birth, nationality, state
                updateDeleteStudentFrm.emailTb.Text = table.Rows[0]["email"].ToString();
                updateDeleteStudentFrm.facultyCb.Text = table.Rows[0]["faculty"].ToString();
                updateDeleteStudentFrm.majorCb.Text = table.Rows[0]["major"].ToString();
                updateDeleteStudentFrm.pobTb.Text = table.Rows[0]["pob"].ToString();
                updateDeleteStudentFrm.nationalityTb.Text = table.Rows[0]["nationality"].ToString();
                updateDeleteStudentFrm.stateCb.Text = table.Rows[0]["state"].ToString();

                updateDeleteStudentFrm.Show(this);
            }
        }

        private void myCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyCourse mycourseFrm = new MyCourse();
            mycourseFrm.labelId.Text = lbUname.Text;
            mycourseFrm.Show(this);
        }

        private void myResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyResultForm myresultFrm = new MyResultForm();
            myresultFrm.labelId.Text = lbUname.Text;
            myresultFrm.Show(this);
        }

        private void lbChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePassFrm = new ChangePasswordForm();
            changePassFrm.usernameTB.Text = lbUname.Text;
            changePassFrm.usernameTB.Enabled = false;
            changePassFrm.lbTypeAccount.Text = TypeAccount.ToUpper() + " ACCOUNT";
            changePassFrm.Show(this);
        }
    }
}
