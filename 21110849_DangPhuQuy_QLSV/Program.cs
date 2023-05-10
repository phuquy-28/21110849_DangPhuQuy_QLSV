using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110849_DangPhuQuy_QLSV
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Login_Form fLogin = new Login_Form();

            if (fLogin.ShowDialog() == DialogResult.OK)
            {
                MainForm mainForm = new MainForm();
                if (fLogin.rbtnStudent.Checked)    //nếu là role Student
                {
                    mainForm.Username = fLogin.userTextBox.Text;
                    mainForm.TypeAccount = fLogin.rbtnStudent.Text;
                    //Ẩn phần Account
                    mainForm.accountToolStripMenuItem.Visible = false;
                    
                    //Ẩn phần Student
                    foreach(ToolStripMenuItem item in mainForm.sTUDENTToolStripMenuItem.DropDownItems)
                    {
                        if (item.Name == "addNewStudentToolStripMenuItem" ||
                            item.Name == "studentListToolStripMenuItem" ||
                            item.Name == "statisticToolStripMenuItem" ||
                            item.Name == "editRemoveToolStripMenuItem"||
                            item.Name == "managerStudentFormToolStripMenuItem"||
                            item.Name == "printToolStripMenuItem")
                        {
                            item.Visible = false;
                        }
                    }

                    //Ẩn phần Course
                    foreach (ToolStripMenuItem item in mainForm.cOURSEToolStripMenuItem.DropDownItems)
                    {
                        if (item.Name == "aDDCORSEToolStripMenuItem" ||
                            item.Name == "removeCourseToolStripMenuItem" ||
                            item.Name == "editCourseToolStripMenuItem" ||
                            item.Name == "manageCourseToolStripMenuItem" ||
                            item.Name == "printToolStripMenuItem1")
                        {
                            item.Visible = false;
                        }
                    }

                    //Ản phần Score
                    mainForm.sCOREToolStripMenuItem.Visible = false;

                    //Ẩn phần Result
                    foreach (ToolStripMenuItem item in mainForm.rESULTToolStripMenuItem1.DropDownItems)
                    {
                        if (item.Name == "resultFormToolStripMenuItem" ||
                            item.Name == "statisticResultFormToolStripMenuItem")
                        {
                            item.Visible = false;
                        }
                    }
                    Application.Run(mainForm);

                }
                else if (fLogin.rbtnTeacher.Checked)
                {
                    mainForm.Username = fLogin.userTextBox.Text;
                    mainForm.TypeAccount = fLogin.rbtnTeacher.Text;
                    mainForm.myInformationToolStripMenuItem.Visible = false;
                    mainForm.myCourseToolStripMenuItem.Visible = false;
                    mainForm.myResultToolStripMenuItem.Visible = false;
                    mainForm.accountToolStripMenuItem.Visible = false;
                    Application.Run(mainForm);
                }
                else if (fLogin.rbtnHr.Checked)
                {
                    MainFormHR mainFormHr = new MainFormHR();
                    Application.Run(mainFormHr);
                }
                else
                {
                    //Nếu là role Admin
                    mainForm.Username = fLogin.userTextBox.Text;
                    mainForm.lbChangePassword.Visible = false;
                    mainForm.myInformationToolStripMenuItem.Visible = false;
                    mainForm.myCourseToolStripMenuItem.Visible = false;
                    mainForm.myResultToolStripMenuItem.Visible = false;
                    Application.Run(mainForm);
                }
            }
            else
            {
                Application.Exit();
            }

            //ImportCourseForm form1 = new ImportCourseForm();
            //Application.Run(form1);

            //MainForm mainForm = new MainForm();
            //Application.Run(mainForm);

            //MainFormHR mainFormHr = new MainFormHR();
            //Application.Run(mainFormHr);

        }
    }
}
