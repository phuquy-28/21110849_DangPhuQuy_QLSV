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
    public partial class MainFormHR : Form
    {
        public MainFormHR()
        {
            InitializeComponent();
        }

        MY_DB mydb = new MY_DB();

        public void getImageAndUsername()
        {
            SqlCommand command = new SqlCommand("select * from hr where id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = Globals.GlobalUserId;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                byte[] pic = (byte[])table.Rows[0]["fig"];
                MemoryStream picture = new MemoryStream(pic);
                picbxAvatar.Image = Image.FromStream(picture);
                lbUsername.Text = "Welcome back ( " + table.Rows[0]["uname"].ToString().Trim() + " )";
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void MainFormHR_Load(object sender, EventArgs e)
        {
            getImageAndUsername();
        }

        private void labEditInfo_Click(object sender, EventArgs e)
        {
            EditUserDataForm editUserDataFrm = new EditUserDataForm();
            editUserDataFrm.Show(this);
        }

        private void lbRefresh_Click(object sender, EventArgs e)
        {
            getImageAndUsername();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddContactForm addContactFrm = new AddContactForm();
            addContactFrm.Show(this);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
