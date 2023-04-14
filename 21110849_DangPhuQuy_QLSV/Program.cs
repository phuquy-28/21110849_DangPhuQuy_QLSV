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

            //Login_Form fLogin = new Login_Form();

            //if (fLogin.ShowDialog() == DialogResult.OK)
            //{
            //    MainForm mainForm = new MainForm();
            //    if (fLogin.rbtnUser.Checked)    //nếu là role User
            //    {
            //        //Ẩn phần Account
            //        mainForm.accountToolStripMenuItem.Visible = false;
            //        Application.Run(mainForm);

            //    }
            //    else if (fLogin.rbtnHr.Checked)
            //    {
            //        MainFormHR mainFormHr = new MainFormHR();
            //        Application.Run(mainFormHr);
            //    }
            //    else
            //    {
            //        //Nếu là role Admin
            //        Application.Run(mainForm);
            //    }
            //}
            //else
            //{
            //    Application.Exit();
            //}

            //MainForm mainForm = new MainForm();
            //Application.Run(mainForm);

            MainFormHR mainFormHr = new MainFormHR();
            Application.Run(mainFormHr);

        }
    }
}
