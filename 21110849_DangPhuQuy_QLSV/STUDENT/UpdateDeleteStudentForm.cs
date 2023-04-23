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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110849_DangPhuQuy_QLSV
{
    public partial class UpdateDeleteStudentForm : Form
    {
        STUDENTs student = new STUDENTs();
        public UpdateDeleteStudentForm()
        {
            InitializeComponent();
        }

        private void findBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(idTb.Text);
                SqlCommand command = new SqlCommand("SELECT * FROM std WHERE id = " + id);

                DataTable table = student.getStudents(command);

                if (table.Rows.Count > 0)
                {
                    //first name, last name, date of birth
                    firstnameTb.Text = table.Rows[0]["fname"].ToString();
                    lastnameTb.Text = table.Rows[0]["lname"].ToString();
                    dobDtp.Value = (DateTime)table.Rows[0]["bdate"];

                    //gender
                    if (table.Rows[0]["gender"].ToString() == "Female")
                    {
                        FemaleBtn.Checked = true;
                    }
                    else
                    {
                        maleBtn.Checked = true;
                    }

                    phoneTB.Text = table.Rows[0]["phone"].ToString();
                    addressTb.Text = table.Rows[0]["address"].ToString();

                    //picture
                    byte[] pic = (byte[])table.Rows[0]["picture"];
                    MemoryStream picture = new MemoryStream(pic);
                    picturePb.Image = Image.FromStream(picture);

                    //email, faculty, major, place of birth, nationality, state
                    emailTb.Text = table.Rows[0]["email"].ToString();
                    facultyCb.Text = table.Rows[0]["faculty"].ToString();
                    majorCb.Text = table.Rows[0]["major"].ToString();
                    pobTb.Text = table.Rows[0]["pob"].ToString();
                    nationalityTb.Text = table.Rows[0]["nationality"].ToString();
                    stateCb.Text = table.Rows[0]["state"].ToString();
                }
                else
                {
                    MessageBox.Show("Not found", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void findFNameBtn_Click(object sender, EventArgs e)
        {
            MY_DB mydb = new MY_DB();
            SqlCommand command = new SqlCommand("SELECT * FROM std WHERE fname = '" + firstnameTb.Text + "' ", mydb.getConnection);

            StudentListForm stdlistFrm = new StudentListForm();
            stdlistFrm.findTb.Text = firstnameTb.Text;
            stdlistFrm.refreshBtn.Visible = false;

            stdlistFrm.Show();
        }

        private void findPhoneBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //int id = int.Parse(idTb.Text);
                SqlCommand command = new SqlCommand("SELECT * FROM std WHERE phone = '" + phoneTB.Text + "'");

                DataTable table = student.getStudents(command);

                if (table.Rows.Count > 0)
                {
                    //first name, last name, date of birth
                    firstnameTb.Text = table.Rows[0]["fname"].ToString();
                    lastnameTb.Text = table.Rows[0]["lname"].ToString();
                    dobDtp.Value = (DateTime)table.Rows[0]["bdate"];

                    //gender
                    if (table.Rows[0]["gender"].ToString() == "Female")
                    {
                        FemaleBtn.Checked = true;
                    }
                    else
                    {
                        maleBtn.Checked = true;
                    }

                    phoneTB.Text = table.Rows[0]["phone"].ToString();
                    addressTb.Text = table.Rows[0]["address"].ToString();

                    //picture
                    byte[] pic = (byte[])table.Rows[0]["picture"];
                    MemoryStream picture = new MemoryStream(pic);
                    picturePb.Image = Image.FromStream(picture);

                    //email, faculty, major, place of birth, nationality, state
                    emailTb.Text = table.Rows[0]["email"].ToString();
                    facultyCb.Text = table.Rows[0]["faculty"].ToString();
                    majorCb.Text = table.Rows[0]["major"].ToString();
                    pobTb.Text = table.Rows[0]["pob"].ToString();
                    nationalityTb.Text = table.Rows[0]["nationality"].ToString();
                    stateCb.Text = table.Rows[0]["state"].ToString();
                }
                else
                {
                    MessageBox.Show("Not found", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                STUDENTs std = new STUDENTs();

                string fname = firstnameTb.Text;
                string lname = lastnameTb.Text;
                DateTime bdate = dobDtp.Value;

                string gender = "Male";

                if (FemaleBtn.Checked)
                {
                    gender = "Female";
                }

                string phone = phoneTB.Text;
                string email = emailTb.Text;
                string adrs = addressTb.Text;
                MemoryStream pic = new MemoryStream();

                string facul = facultyCb.SelectedText.ToString();
                string major = majorCb.SelectedText.ToString();
                string pob = pobTb.Text;
                string nation = nationalityTb.Text;
                string state = stateCb.SelectedText.ToString();

                int born_year = dobDtp.Value.Year;
                int this_year = DateTime.Now.Year;
                //Age must be between 15 to 100
                if (this_year - born_year < 10 || this_year - born_year > 100)
                {
                    MessageBox.Show("The student's age must be between 10 to 100!", "Invalid BithDate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (verif())
                {
                    int id = Convert.ToInt32(idTb.Text);
                    facul = facultyCb.SelectedItem.ToString();
                    major = majorCb.SelectedItem.ToString();
                    state = stateCb.SelectedItem.ToString();
                    picturePb.Image.Save(pic, picturePb.Image.RawFormat);
                    if (std.updateStudent(id, fname, lname, bdate, gender, phone, adrs, pic, email, facul, major, pob, nation, state))
                    {
                        MessageBox.Show("Student's Info Updated", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                bool verif()
                {
                    if (firstnameTb.Text.Trim() == ""
                        || idTb.Text.Trim() == ""
                        || lastnameTb.Text.Trim() == ""
                        || addressTb.Text.Trim() == ""
                        || phoneTB.Text.Trim() == ""
                        || picturePb.Image == null
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

        private void removeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int studentID = Convert.ToInt32(idTb.Text);
                //int studentID = int.Parse(idTb.Text);
                //display a comfirmation message before the delete
                if (MessageBox.Show("Are you sure to delete this student", "Delete Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (student.deleteStudent(studentID))
                    {
                        idTb.Text = "";
                        firstnameTb.Text = "";
                        lastnameTb.Text = "";
                        dobDtp.Value = DateTime.ParseExact("01/01/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        maleBtn.Checked = true;
                        phoneTB.Text = "";
                        emailTb.Text = "";
                        addressTb.Text = "";
                        facultyCb.Text = "";
                        majorCb.Text = "";
                        pobTb.Text = "";
                        nationalityTb.Text = "";
                        stateCb.Text = "";
                        picturePb.Image = null;
                        MessageBox.Show("Deleting successfully");

                    }
                    else
                    {
                        MessageBox.Show("Student Not Deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please enter a valid ID", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            AddCourseStudentForm addCourseStudentForm = new AddCourseStudentForm();
            addCourseStudentForm.tbStdId.Text = idTb.Text;
            addCourseStudentForm.Show(this);
        }
    }
}
