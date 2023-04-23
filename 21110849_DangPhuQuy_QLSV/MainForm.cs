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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

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
    }
}
