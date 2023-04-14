using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110849_DangPhuQuy_QLSV
{
    public partial class EditRemoveStudentForm : Form
    {
        public EditRemoveStudentForm()
        {
            InitializeComponent();
        }

        MY_DB mydb = new MY_DB();

        STUDENTs student = new STUDENTs();

        void loadData(SqlCommand command)
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
                stdListDGV.DataSource = table;

                //Đổi tên các cột trong studentList DataGridView;
                stdListDGV.Columns[0].HeaderText = "ID";
                stdListDGV.Columns[1].HeaderText = "First Name";
                stdListDGV.Columns[2].HeaderText = "Last Name";
                stdListDGV.Columns[3].HeaderText = "Birthdate";
                stdListDGV.Columns[4].HeaderText = "Gender";
                stdListDGV.Columns[5].HeaderText = "Phone Number";
                stdListDGV.Columns[6].HeaderText = "Address";
                stdListDGV.Columns[7].HeaderText = "Email";
                stdListDGV.Columns[8].HeaderText = "Faculty";
                stdListDGV.Columns[9].HeaderText = "Major";
                stdListDGV.Columns[10].HeaderText = "Place of birth";
                stdListDGV.Columns[11].HeaderText = "Nationality";
                stdListDGV.Columns[12].HeaderText = "State";
                stdListDGV.Columns[13].HeaderText = "Picture";

                //Xu ly hinh anh
                DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                stdListDGV.RowTemplate.Height = 80;
                stdListDGV.DataSource = student.getStudents(command);
                //picCol = (DataGridViewImageColumn)stdListDGV.Columns[7];
                picCol = (DataGridViewImageColumn)stdListDGV.Columns[13];
                picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                stdListDGV.AllowUserToAddRows = false;

                //Đổi thử tự hiển thị các cột 
                //stdListDGV.Columns[7].DisplayIndex = 13;
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

        private void EditRemoveStudentForm_Load(object sender, EventArgs e)
        {
            mydb.openConnection();
            SqlCommand cmd = new SqlCommand("select * from std", mydb.getConnection);
            loadData(cmd);
            mydb.closeConnection();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from std", mydb.getConnection);
            loadData(cmd);
        }

        private void stdListDGV_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                UpdateDeleteStudentForm updateDeleteStdF = new UpdateDeleteStudentForm();
                //thu tu cua cac cot: id  - fname - lname - bd - gdr - phone - adrs - pic - email - faculty - major - pob - nationality - state
                updateDeleteStdF.idTb.Text = stdListDGV.CurrentRow.Cells[0].Value.ToString();
                updateDeleteStdF.firstnameTb.Text = stdListDGV.CurrentRow.Cells[1].Value.ToString();
                updateDeleteStdF.lastnameTb.Text = stdListDGV.CurrentRow.Cells[2].Value.ToString();
                updateDeleteStdF.dobDtp.Value = (DateTime)stdListDGV.CurrentRow.Cells[3].Value;

                //gender
                if (stdListDGV.CurrentRow.Cells[4].Value.ToString() == "Female")
                {
                    updateDeleteStdF.FemaleBtn.Checked = true;
                }

                updateDeleteStdF.phoneTB.Text = stdListDGV.CurrentRow.Cells[5].Value.ToString();
                updateDeleteStdF.addressTb.Text = stdListDGV.CurrentRow.Cells[6].Value.ToString();

                //code xu ly hinh anh up len
                if ((byte[])stdListDGV.CurrentRow.Cells[13].Value != null)
                {
                    byte[] pic;
                    pic = (byte[])stdListDGV.CurrentRow.Cells[13].Value;
                    MemoryStream picture = new MemoryStream(pic);
                    updateDeleteStdF.picturePb.Image = Image.FromStream(picture);
                }

                updateDeleteStdF.emailTb.Text = stdListDGV.CurrentRow.Cells[7].Value.ToString();
                updateDeleteStdF.facultyCb.Text = stdListDGV.CurrentRow.Cells[8].Value.ToString();
                updateDeleteStdF.majorCb.Text = stdListDGV.CurrentRow.Cells[9].Value.ToString();
                updateDeleteStdF.pobTb.Text = stdListDGV.CurrentRow.Cells[10].Value.ToString();
                updateDeleteStdF.nationalityTb.Text = stdListDGV.CurrentRow.Cells[11].Value.ToString();
                updateDeleteStdF.stateCb.Text = stdListDGV.CurrentRow.Cells[12].Value.ToString();

                //Ẩn đi nút find
                updateDeleteStdF.findIdBtn.Visible = false;
                updateDeleteStdF.findFNameBtn.Visible = false;
                updateDeleteStdF.findPhoneBtn.Visible = false;

                //Disable tbId
                updateDeleteStdF.idTb.Enabled = false;

                updateDeleteStdF.Show();
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
            SqlCommand cmd = new SqlCommand("SELECT * FROM std WHERE CONCAT (id, fname, lname) LIKE '%" + findTb.Text + "%'", mydb.getConnection);
            mydb.openConnection();
            loadData(cmd);
            mydb.closeConnection();
        }
    }
}
