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
    public partial class RegisterFrm : Form
    {
        MY_DB db = new MY_DB();
        public RegisterFrm()
        {
            InitializeComponent();
            this.AcceptButton = regisBtn;
        }

        public bool isValidAcc(string user)
        {
            int affectedRows = 0;

            SqlCommand cmd_log_in = new SqlCommand("select count(*) from log_in where username = @user", db.getConnection);
            cmd_log_in.Parameters.AddWithValue("@user", user);

            db.openConnection();

            affectedRows += Convert.ToInt32(cmd_log_in.ExecuteScalar());

            db.closeConnection();

            if (affectedRows > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isValidAcc(usernameTB.Text))
                {
                    MessageBox.Show("Tài khoản đã tồn tại");
                    return;
                }
                if (passwordTB.Text == confirmPassTB.Text)
                {
                    SqlCommand command = new SqlCommand("INSERT INTO PendingAccount (username, password, role) VALUES (@User, @Pass, @Rol) ", db.getConnection);
                    {
                        command.Parameters.AddWithValue("User", usernameTB.Text);
                        command.Parameters.AddWithValue("Pass", passwordTB.Text);
                        command.Parameters.AddWithValue("Rol", "student");
                    }

                    // Mở kết nối
                    db.openConnection();

                    //KQ thực thi câu truy vấn INSERT INTO
                    int rowsAffected = command.ExecuteNonQuery();

                    //Đóng kết nối
                    db.closeConnection();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm thành công");
                        usernameTB.Clear();
                        passwordTB.Clear();
                        confirmPassTB.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Thất bại");
                    }
                }
                else
                {
                    MessageBox.Show("Password đã nhập không khớp");
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

        private void showpassCb_CheckedChanged(object sender, EventArgs e)
        {
            if (showpassCb.Checked == true)
            {
                passwordTB.PasswordChar = '\0';
                confirmPassTB.PasswordChar = '\0';
            }
            else
            {
                passwordTB.PasswordChar = '*';
                confirmPassTB.PasswordChar = '*';
            }
        }
    }
}
