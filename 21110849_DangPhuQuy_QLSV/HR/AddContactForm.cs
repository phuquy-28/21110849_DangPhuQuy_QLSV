using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110849_DangPhuQuy_QLSV
{
    public partial class AddContactForm : Form
    {
        public AddContactForm()
        {
            InitializeComponent();
        }
        CONTACT contact = new CONTACT();

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image (*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                picbxPic.Image = Image.FromFile(opf.FileName);
            }
        }

        public bool verify()
        {
            if (tbContactId.Text == "" ||
                tbFname.Text == "" ||
                tbLname.Text == "" ||
                tbLname.Text == "" ||
                cbGrp.Text == "" ||
                tbPhone.Text == "" ||
                tbEmail.Text == "" ||
                rtbAdrs.Text == "" ||
                picbxPic.Image == null
                )
                return false;
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbContactId.Text);
            string fname = tbFname.Text.Trim();
            string lname = tbLname.Text.Trim();
            int grp = Convert.ToInt32(cbGrp.Text);
            string phone = tbPhone.Text.Trim();
            string email = tbEmail.Text.Trim();
            string adrs = rtbAdrs.Text.Trim();
            MemoryStream pic = new MemoryStream();

            if (verify())
            {
                picbxPic.Image.Save(pic, picbxPic.Image.RawFormat);
                if (contact.insertContact(id, fname, lname, grp, phone, email, adrs, pic))
                {
                    MessageBox.Show("Adding Successfully", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbContactId.Text = "";
                    tbFname.Text = "";
                    tbLname.Text = "";
                    cbGrp.SelectedIndex = -1;
                    tbPhone.Text = "";
                    tbEmail.Text = "";
                    rtbAdrs.Text = "";
                    picbxPic.Image = null;
                }
                else
                {
                    MessageBox.Show("Adding Fail", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void isDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only input digits, control keys
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Only enter digits", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void emailTb_Validating(object sender, CancelEventArgs e)
        {
            if (!(new EmailAddressAttribute().IsValid(tbEmail.Text)))
            {
                MessageBox.Show("Email Address is not valid", "Email Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbEmail.Text = "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
