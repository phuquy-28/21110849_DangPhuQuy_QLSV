using Microsoft.Office.Interop.Word;
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
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace _21110849_DangPhuQuy_QLSV
{
    public partial class RegisterFormHR : Form
    {
        public RegisterFormHR()
        {
            InitializeComponent();
        }

        private void RegisterFormHR_Load(object sender, EventArgs e)
        {
            picbxPic.Image = null;
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

        private void lbExistAcc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            USER user = new USER();

            int id = Convert.ToInt32(tbId.Text);
            string fname = tbFname.Text.Trim();
            string lname = tbLastname.Text.Trim();
            string uname = tbUsername.Text.Trim();
            string pass = tbPass.Text.Trim();
            MemoryStream pic = new MemoryStream();

            if (verif())
            {
                if (!user.usernameExist(uname, "register"))
                {
                    picbxPic.Image.Save(pic, picbxPic.Image.RawFormat);
                    if (user.insertUser(id, fname, lname, uname, pass, pic))
                    {
                        MessageBox.Show("New HR Added", "Add HR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Add HR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Username has already exist", "Add HR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            else
            {
                MessageBox.Show("Empty Fields", "Add HR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            bool verif()
            {
                if (tbFname.Text.Trim() == ""
                    || tbLastname.Text.Trim() == ""
                    || tbUsername.Text.Trim() == ""
                    || tbPass.Text.Trim() == ""
                    || picbxPic.Image == null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
