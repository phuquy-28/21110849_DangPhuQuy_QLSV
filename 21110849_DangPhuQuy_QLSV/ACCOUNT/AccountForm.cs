using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110849_DangPhuQuy_QLSV
{
    public partial class AccountForm : Form
    {
        MY_DB mydb = new MY_DB();
        USER user = new USER();
        public AccountForm()
        {
            InitializeComponent();
        }

        public void getData()
        {
            mydb.openConnection();

            SqlCommand command = new SqlCommand("SELECT * FROM PendingAccount", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            table.Clear();
            adapter.Fill(table);

            dgvStudent.DataSource = table;

            dgvStudent.Columns[0].HeaderText = "Username";
            dgvStudent.Columns[1].HeaderText = "Password";
            dgvStudent.Columns[2].HeaderText = "Role";
            dgvStudent.AllowUserToAddRows = false;

            mydb.closeConnection();
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (dgvStudent.SelectedRows.Count <= 0)
                return;
            try
            {
                // Mở kết nối
                mydb.openConnection();

                DataGridViewRow selectedRow = dgvStudent.SelectedRows[0];
                SqlCommand command = new SqlCommand("INSERT INTO log_in (username, password, role) VALUES (@User, @Pass, @Rol) ", mydb.getConnection);
                {
                    command.Parameters.AddWithValue("User", selectedRow.Cells[0].Value.ToString());
                    command.Parameters.AddWithValue("Pass", selectedRow.Cells[1].Value.ToString());
                    command.Parameters.AddWithValue("Rol", selectedRow.Cells[2].Value.ToString());
                }

                //KQ thực thi câu truy vấn INSERT INTO
                int rowsAffectedByIn = command.ExecuteNonQuery();


                command = new SqlCommand("DELETE FROM PendingAccount WHERE username = @User", mydb.getConnection);
                command.Parameters.AddWithValue("@User", selectedRow.Cells[0].Value.ToString());
                int rowsAffectedDel = command.ExecuteNonQuery();


                getData();

                //Đóng kết nối
                mydb.closeConnection();
                if (rowsAffectedByIn == rowsAffectedDel)
                {
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Tài khoản đã tồn tại!");
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

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvStudent.SelectedRows.Count <= 0)
                return;
            try
            {
                // Mở kết nối
                mydb.openConnection();

                DataGridViewRow selectedRow = dgvStudent.SelectedRows[0];

                SqlCommand command = new SqlCommand("DELETE FROM PendingAccount WHERE username = @User", mydb.getConnection);
                command.Parameters.AddWithValue("@User", selectedRow.Cells[0].Value.ToString());
                int rowsAffectedDel = command.ExecuteNonQuery();

                getData();

                //Đóng kết nối
                mydb.closeConnection();
                if (rowsAffectedDel > 0)
                {
                    MessageBox.Show("Loại bỏ thành công");
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAccAll_Click(object sender, EventArgs e)
        {
            if (dgvStudent.Rows.Count <= 0)
                return;
            // Mở kết nối
            mydb.openConnection();
            int rowsAffectedIn = 0;
            int rowsAffectedDel = 0;
            for (int i = 0; i < dgvStudent.Rows.Count; i++)
            {
                DataGridViewRow selectedRow = dgvStudent.Rows[i];
                if (selectedRow.Cells[0].Value != null)
                {
                    try
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO log_in (username, password, role) VALUES (@User, @Pass, @Rol) ", mydb.getConnection);
                        {
                            command.Parameters.AddWithValue("User", selectedRow.Cells[0].Value.ToString());
                            command.Parameters.AddWithValue("Pass", selectedRow.Cells[1].Value.ToString());
                            command.Parameters.AddWithValue("Rol", selectedRow.Cells[2].Value.ToString());
                        }

                        //KQ thực thi câu truy vấn INSERT INTO
                        rowsAffectedIn += command.ExecuteNonQuery();


                        command = new SqlCommand("DELETE FROM PendingAccount WHERE username = @User", mydb.getConnection);
                        command.Parameters.AddWithValue("@User", selectedRow.Cells[0].Value.ToString());
                        rowsAffectedDel += command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627)
                        {
                            MessageBox.Show($"Tài khoản {selectedRow.Cells[0].Value.ToString().Trim()} đã tồn tại!");
                        }
                        else
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                }
            }
            getData();
            //Đóng kết nối
            mydb.closeConnection();
            if (rowsAffectedIn == rowsAffectedDel)
            {
                MessageBox.Show("Thêm thành công " + rowsAffectedIn.ToString() + " user");
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void tabStudent_Click(object sender, EventArgs e)
        {

        }

        public void loadTabHr()
        {
            SqlCommand command = new SqlCommand("select * from pendingHr", mydb.getConnection);

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(table);

            dgvHr.RowTemplate.Height = 80;
            dgvHr.DataSource = table;
            dgvHr.AllowUserToAddRows = false;
            dgvHr.Columns["id"].HeaderText = "Id";
            dgvHr.Columns["f_name"].HeaderText = "First name";
            dgvHr.Columns["l_name"].HeaderText = "Last name";
            dgvHr.Columns["uname"].HeaderText = "Username";
            dgvHr.Columns["pwd"].HeaderText = "Password";
            dgvHr.Columns["fig"].HeaderText = "Image";

            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            picCol = (DataGridViewImageColumn)dgvHr.Columns["fig"];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

        }

        private void tabtablePending_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabtablePending.SelectedIndex == 0)
            {
                AccountForm_Load(null, null);
            }
            else if (tabtablePending.SelectedIndex == 1)
            {
                loadTabHr();
            }
        }

        private void btnHrAcpt_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvHr.CurrentRow.Cells["id"].Value.ToString());
                string fname = dgvHr.CurrentRow.Cells["f_name"].Value.ToString();
                string lname = dgvHr.CurrentRow.Cells["l_name"].Value.ToString();
                string uname = dgvHr.CurrentRow.Cells["uname"].Value.ToString();
                string password = dgvHr.CurrentRow.Cells["pwd"].Value.ToString();
                byte[] pic = (byte[])dgvHr.CurrentRow.Cells["fig"].Value;
                MemoryStream picture = new MemoryStream(pic);
                if (user.insertUser(id, fname, lname, uname, password, picture))
                {
                    user.deletePendingHr(id);
                    loadTabHr();
                    MessageBox.Show("Adding succesfully", "Pending Account HR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Adding fail", "Pending Account HR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Pending Account HR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHrDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvHr.CurrentRow.Cells["id"].Value.ToString());
                if (user.deletePendingHr(id))
                {
                    loadTabHr();
                    MessageBox.Show("Deleting succesfully", "Pending Account HR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Deleting fail", "Pending Account HR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pending Account HR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHrAccAll_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dgvHr.Rows)
            {
                try
                {
                    int id = Convert.ToInt32(row.Cells["id"].Value.ToString());
                    string fname = row.Cells["f_name"].Value.ToString();
                    string lname = row.Cells["l_name"].Value.ToString();
                    string uname = row.Cells["uname"].Value.ToString();
                    string password = row.Cells["pwd"].Value.ToString();
                    byte[] pic = (byte[])row.Cells["fig"].Value;
                    MemoryStream picture = new MemoryStream(pic);
                    if (user.insertUser(id, fname, lname, uname, password, picture))
                    {
                        user.deletePendingHr(id);
                        //loadTabHr();
                        //MessageBox.Show("Adding succesfully", "Pending Account HR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Adding fail", "Pending Account HR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Pending Account HR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            loadTabHr();
            MessageBox.Show("Adding succesfully", "Pending Account HR", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
