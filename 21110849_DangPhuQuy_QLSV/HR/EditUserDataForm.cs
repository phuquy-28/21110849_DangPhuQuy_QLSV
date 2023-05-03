using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110849_DangPhuQuy_QLSV
{
    public partial class EditUserDataForm : Form
    {
        public EditUserDataForm()
        {
            InitializeComponent();
        }

        MY_DB mydb = new MY_DB();
        USER user = new USER();

        private void EditUserDataForm_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table = user.getUserById(Globals.GlobalUserId);

            tbID.Text = table.Rows[0]["id"].ToString();
            tbID.Enabled = false;
            tbFname.Text = table.Rows[0]["f_name"].ToString();
            tbLname.Text = table.Rows[0]["l_name"].ToString();
            tbUname.Text = table.Rows[0]["uname"].ToString();
            tbPass.Text = table.Rows[0]["pwd"].ToString();

            //xu ly hinh anh
            byte[] pic = (byte[])table.Rows[0]["fig"];
            MemoryStream picture = new MemoryStream(pic);
            picbxPic.Image = Image.FromStream(picture);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image (*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                picbxPic.Image = Image.FromFile(opf.FileName);
            }
        }

        public bool verif()
        {
            if (tbFname.Text.Trim() == ""
                || tbLname.Text.Trim() == ""
                || tbUname.Text.Trim() == ""
                || tbPass.Text.Trim() == ""
                || picbxPic.Image == null)
            {
                return false;
            }
            return true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int userId = Globals.GlobalUserId;
                string fname = tbFname.Text.Trim();
                string lname = tbLname.Text.Trim();
                string uname = tbUname.Text.Trim();
                string pass = tbPass.Text.Trim();
                MemoryStream pic = new MemoryStream();

                if (verif())
                {
                    picbxPic.Image.Save(pic, picbxPic.Image.RawFormat);

                    if (!user.usernameExist(uname, "edit", userId))
                    {
                        if (user.updaterUser(userId, fname, lname, uname, pass, pic))
                        {
                            MessageBox.Show("Updating Successfully", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Updating Fail", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username has already exist", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void showpassCb_CheckedChanged(object sender, EventArgs e)
        {
            if (showpassCb.Checked == true)
            {
                tbPass.PasswordChar = '\0';
            }
            else
            {
                tbPass.PasswordChar = '●';
            }
        }
    }
}
