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
    public partial class AccountForm : Form
    {
        MY_DB mydb = new MY_DB();
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
    }
}
