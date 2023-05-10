using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace _21110849_DangPhuQuy_QLSV
{
    public partial class ForgetPasswordForm : Form
    {
        public ForgetPasswordForm()
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
            MessageBox.Show("StatusCode: " + response.StatusCode.ToString(), "Recovery Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (lbTypeAccount.Text == "STUDENT ACCOUNT" || lbTypeAccount.Text == "TEACHER ACCOUNT")
            {
                if (returnEmailUser(usernameTB.Text) != "")
                {
                    string email = returnEmailUser(usernameTB.Text);
                    optCode = GenerateRandomString(8);
                    sendCode(email, optCode);
                }
                else
                {
                    MessageBox.Show("Username does not exist", "Recovery Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Username does not exist", "Recovery Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnRecovery_Click(object sender, EventArgs e)
        {
            if(lbTypeAccount.Text == "STUDENT ACCOUNT" && tbVerifCode.Text == optCode)
            {
                SqlCommand command = new SqlCommand("update log_in set password = @pwd where username = @uname", mydb.getConnection);
                command.Parameters.Add("uname", SqlDbType.NChar).Value = usernameTB.Text;
                command.Parameters.Add("pwd", SqlDbType.NChar).Value = passwordTB.Text;

                mydb.openConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                    mydb.closeConnection();
                    MessageBox.Show("Recovering successfully", "Recovery Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    optCode = GenerateRandomString(8);

                }
                else
                {
                    mydb.closeConnection();
                    MessageBox.Show("Recovering fail", "Recovery Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Recovering successfully", "Recovery Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    optCode = GenerateRandomString(8);

                }
                else
                {
                    mydb.closeConnection();
                    MessageBox.Show("Recovering fail", "Recovery Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    optCode = GenerateRandomString(8);
                }
            }
            else
            {
                MessageBox.Show("Wrong OPT code", "Recovery Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    }
}
