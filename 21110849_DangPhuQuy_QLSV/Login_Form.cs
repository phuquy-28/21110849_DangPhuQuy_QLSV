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
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
            this.AcceptButton = loginButton;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (rbtnUser.Checked == true || rbtnAdmin.Checked == true)
            {
                try
                {
                    MY_DB db = new MY_DB();

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    DataTable table = new DataTable();

                    SqlCommand command = new SqlCommand("SELECT * FROM log_in WHERE username = @User AND password = @Pass and role = @Rol", db.getConnection);

                    command.Parameters.Add("@User", SqlDbType.VarChar).Value = userTextBox.Text;
                    command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = passwordTextBox.Text;
                    if (rbtnUser.Checked)
                    {
                        command.Parameters.Add("@Rol", SqlDbType.VarChar).Value = rbtnUser.Text;
                    }
                    else
                    {
                        command.Parameters.Add("@Rol", SqlDbType.VarChar).Value = rbtnAdmin.Text;
                    }


                    adapter.SelectCommand = command;

                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        //MessageBox.Show("Ok, next time will be go to Main of App");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (rbtnHr.Checked == true)
            {
                try
                {
                    MY_DB db = new MY_DB();

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    DataTable table = new DataTable();

                    SqlCommand command = new SqlCommand("SELECT * FROM hr WHERE uname = @User AND pwd = @Pass", db.getConnection);

                    command.Parameters.Add("@User", SqlDbType.VarChar).Value = userTextBox.Text;
                    command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = passwordTextBox.Text;

                    adapter.SelectCommand = command;

                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        int userid = Convert.ToInt32(table.Rows[0][0].ToString());

                        Globals.SetGlobalUserId(userid);
                        //MessageBox.Show("Ok, next time will be go to Main of App");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newUserLB_Click(object sender, EventArgs e)
        {
            if (rbtnHr.Checked == true)
            {
                RegisterFormHR registerFrmHr = new RegisterFormHR();
                registerFrmHr.Show();
                return;
            }
            Form frm = new RegisterFrm();
            frm.Show();
        }

        private void showPassCB_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassCB.Checked)
            {
                passwordTextBox.PasswordChar = '\0';
            }
            else
            {
                passwordTextBox.PasswordChar = '*';
            }
        }

        private void lbForgetPass_Click(object sender, EventArgs e)
        {
            if (rbtnUser.Checked)
            {
                ForgetPasswordForm forgetPasswordFrm = new ForgetPasswordForm();
                forgetPasswordFrm.lbTypeAccount.Text = "STUDENT ACCOUNT";
                forgetPasswordFrm.Show(this);
            }
            else if (rbtnHr.Checked)
            {
                ForgetPasswordForm forgetPasswordFrm = new ForgetPasswordForm();
                forgetPasswordFrm.lbTypeAccount.Text = "HR ACCOUNT";
                forgetPasswordFrm.Show(this);
            }
        }
    }
}
