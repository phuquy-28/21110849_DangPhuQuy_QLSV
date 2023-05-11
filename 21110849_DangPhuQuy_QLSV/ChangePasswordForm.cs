using SendGrid.Helpers.Mail;
using SendGrid;
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
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }
        MY_DB mydb = new MY_DB();

        private string returnEmailUser(string username)
        {
            SqlCommand command = new SqlCommand("select * from log_in where username = @uname", mydb.getConnection);
            command.Parameters.Add("uname", SqlDbType.NChar).Value = username;

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(table);

            string email = "";

            if (table.Rows.Count > 0)
            {
                email = table.Rows[0]["email"].ToString();
            }

            return email;
        }
        private string returnEmailHR(string username)
        {
            SqlCommand command = new SqlCommand("select * from hr where uname = @uname", mydb.getConnection);
            command.Parameters.Add("uname", SqlDbType.NChar).Value = username;

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(table);

            string email = "";

            if (table.Rows.Count > 0)
            {
                email = table.Rows[0]["email"].ToString();
            }

            return email;
        }


        //Hàm tạo chuỗi random có độ dài length
        public static string GenerateRandomString(int length)
        {
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();

            var result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(validChars[random.Next(validChars.Length)]);
            }

            return result.ToString();
        }

        private string optCode = GenerateRandomString(8);
        private async void sendCode(string email, string optCode)
        {
            // Khởi tạo API Key của bạn
            var apiKey = "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";

            // Khởi tạo đối tượng SendGridClient với API Key của bạn
            var client = new SendGridClient(apiKey);


            // Khởi tạo đối tượng EmailAddress cho người gửi và người nhận
            var from = new EmailAddress("phuquypro.2003@gmail.com", "Admin");
            var to = new EmailAddress(email, email);

            // Thiết lập tiêu đề và nội dung email
            var subject = "To verify valid access";
            var plainTextContent = $"Your OTP code is: {optCode}";
            var htmlContent = $"<strong>Your OTP code is: {optCode}</strong>";

            // Tạo đối tượng SendGridMessage và thiết lập thông tin người gửi, người nhận, tiêu đề và nội dung email
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            // Gửi email bằng cách sử dụng API của SendGrid
            var response = await client.SendEmailAsync(msg);

            // In ra kết quả gửi email
            MessageBox.Show("StatusCode: " + response.StatusCode.ToString(), "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbTypeAccount.Text.ToUpper() == "STUDENT ACCOUNT" || lbTypeAccount.Text.ToUpper() == "TEACHER ACCOUNT")
                {
                    if (returnEmailUser(usernameTB.Text) != "")
                    {
                        string email = returnEmailUser(usernameTB.Text);
                        optCode = GenerateRandomString(8);
                        sendCode(email, optCode);
                    }
                    else
                    {
                        MessageBox.Show("Username does not exist", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (lbTypeAccount.Text == "HR ACCOUNT")
                {
                    if (returnEmailHR(usernameTB.Text) != "")
                    {
                        string email = returnEmailHR(usernameTB.Text);
                        optCode = GenerateRandomString(8);
                        sendCode(email, optCode);
                    }
                    else
                    {
                        MessageBox.Show("Username does not exist", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbTypeAccount.Text.ToUpper() == "STUDENT ACCOUNT" && tbVerifCode.Text == optCode ||
                    lbTypeAccount.Text.ToUpper() == "TEACHER ACCOUNT" && tbVerifCode.Text == optCode)
                {
                    SqlCommand command = new SqlCommand("update log_in set password = @pwd where username = @uname", mydb.getConnection);
                    command.Parameters.Add("uname", SqlDbType.NChar).Value = usernameTB.Text;
                    command.Parameters.Add("pwd", SqlDbType.NChar).Value = passwordTB.Text;

                    mydb.openConnection();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        mydb.closeConnection();
                        MessageBox.Show("Changing successfully", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        optCode = GenerateRandomString(8);

                    }
                    else
                    {
                        mydb.closeConnection();
                        MessageBox.Show("Changing fail", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        optCode = GenerateRandomString(8);
                    }
                }
                else if (lbTypeAccount.Text == "HR ACCOUNT" && tbVerifCode.Text == optCode)
                {
                    SqlCommand command = new SqlCommand("update hr set pwd = @pwd where uname = @uname", mydb.getConnection);
                    command.Parameters.Add("uname", SqlDbType.NChar).Value = usernameTB.Text;
                    command.Parameters.Add("pwd", SqlDbType.NChar).Value = passwordTB.Text;

                    mydb.openConnection();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        mydb.closeConnection();
                        MessageBox.Show("Changing successfully", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        optCode = GenerateRandomString(8);

                    }
                    else
                    {
                        mydb.closeConnection();
                        MessageBox.Show("Changing fail", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        optCode = GenerateRandomString(8);
                    }
                }
                else
                {
                    MessageBox.Show("Wrong OPT code", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void showpassCb_CheckedChanged(object sender, EventArgs e)
        {
            if (showpassCb.Checked == true)
            {
                passwordTB.PasswordChar = '\0';
            }
            else
            {
                passwordTB.PasswordChar = '*';
            }
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {

        }
    }
}
