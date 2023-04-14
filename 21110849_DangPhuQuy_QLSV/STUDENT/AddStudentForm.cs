using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110849_DangPhuQuy_QLSV
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
            this.AcceptButton = addBtn;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                STUDENTs std = new STUDENTs();

                string fname = fNameTB.Text;
                string lname = lNameTB.Text;
                DateTime bdate = dobDTP.Value;

                string gender = "Male";

                if (femaleRBtn.Checked)
                {
                    gender = "Female";
                }

                string phone = phoneTB.Text;
                string email = emailTb.Text;
                string adrs = addressTB.Text;
                MemoryStream pic = new MemoryStream();

                string facul = facultyCb.SelectedText.ToString();
                string major = majorCb.SelectedText.ToString();
                string pob = pobTb.Text;
                string nation = nationalityTb.Text;
                string state = stateCb.SelectedText.ToString();

                int born_year = dobDTP.Value.Year;
                int this_year = DateTime.Now.Year;
                //Age must be between 15 to 100
                if (this_year - born_year < 18 || this_year - born_year > 100)
                {
                    MessageBox.Show("The student's age must be between 18 to 100!", "Invalid BithDate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (verif())
                {
                    int id = Convert.ToInt32(idTB.Text);
                    facul = facultyCb.SelectedItem.ToString();
                    major = majorCb.SelectedItem.ToString();
                    state = stateCb.SelectedItem.ToString();
                    stdPicPB.Image.Save(pic, stdPicPB.Image.RawFormat);
                    if (std.insertStudent(id, fname, lname, bdate, gender, phone, adrs, pic, email, facul, major, pob, nation, state))
                    {
                        MessageBox.Show("New Student Added", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                bool verif()
                {
                    if (fNameTB.Text.Trim() == ""
                        || idTB.Text.Trim() == ""
                        || lNameTB.Text.Trim() == ""
                        || addressTB.Text.Trim() == ""
                        || phoneTB.Text.Trim() == ""
                        || stdPicPB.Image == null
                        || emailTb.Text == ""
                        || facultyCb.SelectedIndex == -1
                        || majorCb.SelectedIndex == -1
                        || pobTb.Text == ""
                        || nationalityTb.Text == ""
                        || stateCb.SelectedIndex == -1)
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("ID đã tồn tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image (*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                stdPicPB.Image = Image.FromFile(opf.FileName);
            }
        }

        private void idTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only input digits, control keys
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Only enter digits", "Student ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void fNameTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only input letters, control keys and blanksapce
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !(e.KeyChar == (char)Keys.Space))
            {
                MessageBox.Show("Only enter letters", "First Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void phoneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only input digits, control keys
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Only enter digits", "Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void lNameTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only input letters, control keys and blanksapce
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !(e.KeyChar == (char)Keys.Space))
            {
                MessageBox.Show("Only enter letters", "Last Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }


        private void emailTb_Validating(object sender, CancelEventArgs e)
        {
            if (!(new EmailAddressAttribute().IsValid(emailTb.Text)))
            {
                MessageBox.Show("Email Address is not valid", "Email Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                emailTb.Text = "";
            }
        }

        private void pobTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only input letters, control keys and blanksapce
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !(e.KeyChar == (char)Keys.Space))
            {
                MessageBox.Show("Only enter letters", "Last Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void nationalityTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only input letters, control keys and blanksapce
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !(e.KeyChar == (char)Keys.Space))
            {
                MessageBox.Show("Only enter letters", "Last Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void clearBtn_Click_1(object sender, EventArgs e)
        {
            //Close();
            idTB.Text = "";
            fNameTB.Text = "";
            lNameTB.Text = "";
            dobDTP.Value = DateTime.ParseExact("01/01/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            maleRBtn.Checked = true;
            phoneTB.Text = "";
            addressTB.Text = "";
            emailTb.Text = "";
            stdPicPB.Image = null;
            facultyCb.Text = "";
            majorCb.Text = "";
            pobTb.Text = "";
            nationalityTb.Text = "";
            stateCb.Text = "";
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportByExcelFile importFrm = new ImportByExcelFile();
            importFrm.Show(this);
        }
    }
}
