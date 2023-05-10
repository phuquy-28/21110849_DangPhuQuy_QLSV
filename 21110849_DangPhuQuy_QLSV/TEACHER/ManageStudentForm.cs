using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110849_DangPhuQuy_QLSV
{
    public partial class ManageStudentForm : Form
    {
        MY_DB mydb = new MY_DB();
        STUDENTs student = new STUDENTs();
        public ManageStudentForm()
        {
            InitializeComponent();
        }

        public string selectedCourse(int studentId)
        {
            SqlCommand command = new SqlCommand("SELECT dbo.course.label " +
                "FROM dbo.course JOIN dbo.course_student " +
                "ON course.id = dbo.course_student.course_id " +
                "WHERE dbo.course_student.student_id = @sid ", mydb.getConnection);
            command.Parameters.Add("sid", SqlDbType.Int).Value = studentId;

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(table);

            string selectedCourse = "";

            foreach(DataRow row in table.Rows)
            {
                selectedCourse += row["label"] + ", ";
            }

            int lengthToRemove = 2;

            if (selectedCourse.Length >= lengthToRemove)
            {
                selectedCourse = selectedCourse.Remove(selectedCourse.Length - lengthToRemove);
            }

            return selectedCourse;
        }

        public void fillGrid(SqlCommand command)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable table = new DataTable();
                table.Clear();
                adapter.Fill(table);
                for (int i = 7; i < table.Columns.Count - 1; i++)
                {
                    table.Columns[i].SetOrdinal(i + 1);
                }
                stdListDgv.DataSource = table;

                //Đổi tên các cột trong studentList DataGridView;
                stdListDgv.Columns[0].HeaderText = "ID";
                stdListDgv.Columns[1].HeaderText = "First Name";
                stdListDgv.Columns[2].HeaderText = "Last Name";
                stdListDgv.Columns[3].HeaderText = "Birthdate";
                stdListDgv.Columns[4].HeaderText = "Gender";
                stdListDgv.Columns[5].HeaderText = "Phone Number";
                stdListDgv.Columns[6].HeaderText = "Address";
                stdListDgv.Columns[7].HeaderText = "Email";
                stdListDgv.Columns[8].HeaderText = "Faculty";
                stdListDgv.Columns[9].HeaderText = "Major";
                stdListDgv.Columns[10].HeaderText = "Place of birth";
                stdListDgv.Columns[11].HeaderText = "Nationality";
                stdListDgv.Columns[12].HeaderText = "State";
                stdListDgv.Columns[13].HeaderText = "Picture";

                //Xu ly hinh anh
                DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                stdListDgv.RowTemplate.Height = 80;

                DataTable table2 = new DataTable();
                table2 = student.getStudents(command);
                table2.Columns.Add(new DataColumn("Selected Course", typeof(string)));
                foreach(DataRow row in table2.Rows)
                {
                    row["selected Course"] = selectedCourse(Convert.ToInt32(row["id"].ToString()));
                }

                stdListDgv.DataSource = table2;
                picCol = (DataGridViewImageColumn)stdListDgv.Columns[13];
                picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                stdListDgv.AllowUserToAddRows = false; ;

                stdListDgv.Columns["Selected Course"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                //Đổi thử tự hiển thị các cột 
                //stdListDgv.Columns[7].DisplayIndex = 13;

                lbTotalStd.Text = ("Total Students: " + stdListDgv.Rows.Count.ToString());
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

        private void ManageStudentForm_Load(object sender, EventArgs e)
        {
            fillGrid(new SqlCommand("select * from std", mydb.getConnection));
        }

        private void stdListDgv_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //thu tu cua cac cot: id  - fname - lname - bd - gdr - phone - adrs - pic - email - faculty - major - pob - nationality - state
                idTB.Text = stdListDgv.CurrentRow.Cells[0].Value.ToString();
                fNameTB.Text = stdListDgv.CurrentRow.Cells[1].Value.ToString();
                lNameTB.Text = stdListDgv.CurrentRow.Cells[2].Value.ToString();
                dobDTP.Value = (DateTime)stdListDgv.CurrentRow.Cells[3].Value;

                //gender
                if (stdListDgv.CurrentRow.Cells[4].Value.ToString() == "Female")
                {
                    femaleRBtn.Checked = true;
                }
                else
                    maleRBtn.Checked = true;

                phoneTB.Text = stdListDgv.CurrentRow.Cells[5].Value.ToString();
                addressTB.Text = stdListDgv.CurrentRow.Cells[6].Value.ToString();

                //code xu ly hinh anh up len
                byte[] pic;
                pic = (byte[])stdListDgv.CurrentRow.Cells[13].Value;
                MemoryStream picture = new MemoryStream(pic);
                stdPicPB.Image = Image.FromStream(picture);

                emailTb.Text = stdListDgv.CurrentRow.Cells[7].Value.ToString();
                facultyCb.Text = stdListDgv.CurrentRow.Cells[8].Value.ToString();
                majorCb.Text = stdListDgv.CurrentRow.Cells[9].Value.ToString();
                pobTb.Text = stdListDgv.CurrentRow.Cells[10].Value.ToString();
                nationalityTb.Text = stdListDgv.CurrentRow.Cells[11].Value.ToString();
                stateCb.Text = stdListDgv.CurrentRow.Cells[12].Value.ToString();
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

        private void btnFind_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM std WHERE CONCAT (fname, lname) LIKE '%" + findTb.Text + "%'", mydb.getConnection);
            fillGrid(command);
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
                        fillGrid(new SqlCommand("select * from std", mydb.getConnection));
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

        private void clearBtn_Click(object sender, EventArgs e)
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

        private void editBtn_Click(object sender, EventArgs e)
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
                if (this_year - born_year < 10 || this_year - born_year > 100)
                {
                    MessageBox.Show("The student's age must be between 10 to 100!", "Invalid BithDate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (verif())
                {
                    int id = Convert.ToInt32(idTB.Text);
                    facul = facultyCb.SelectedItem.ToString();
                    major = majorCb.SelectedItem.ToString();
                    state = stateCb.SelectedItem.ToString();
                    stdPicPB.Image.Save(pic, stdPicPB.Image.RawFormat);
                    if (std.updateStudent(id, fname, lname, bdate, gender, phone, adrs, pic, email, facul, major, pob, nation, state))
                    {
                        MessageBox.Show("Student's Info Updated", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fillGrid(new SqlCommand("select * from std", mydb.getConnection));
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

        private void removeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int studentID = Convert.ToInt32(idTB.Text);
                //int studentID = int.Parse(idTb.Text);
                //display a comfirmation message before the delete
                if (MessageBox.Show("Are you sure to delete this student", "Delete Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (student.deleteStudent(studentID))
                    {
                        idTB.Text = "";
                        fNameTB.Text = "";
                        lNameTB.Text = "";
                        dobDTP.Value = DateTime.ParseExact("01/01/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        maleRBtn.Checked = true;
                        phoneTB.Text = "";
                        emailTb.Text = "";
                        addressTB.Text = "";
                        facultyCb.Text = "";
                        majorCb.Text = "";
                        pobTb.Text = "";
                        nationalityTb.Text = "";
                        stateCb.Text = "";
                        stdPicPB.Image = null;
                        MessageBox.Show("Deleting successfully");
                        fillGrid(new SqlCommand("select * from std", mydb.getConnection));
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

        private void btnDowload_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.FileName = ("student_" + idTB.Text);
            if (stdPicPB.Image == null)
            {
                MessageBox.Show("No imagine in the PictureBox");
            }
            else if (svf.ShowDialog() == DialogResult.OK)
            {
                stdPicPB.Image.Save((svf.FileName + ("." + ImageFormat.Jpeg.ToString())));
            }
        }
    }
}
