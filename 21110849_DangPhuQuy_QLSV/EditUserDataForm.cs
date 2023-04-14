using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110849_DangPhuQuy_QLSV
{
    public partial class EditUserDataForm : Form
    {
        public EditUserDataForm()
        {
            InitializeComponent();
        }

        MY_DB mydb = new MY_DB();
        USER user = new USER();

        private void EditUserDataForm_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table = user.getUserById(Globals.GlobalUserId);

            tbID.Text = table.Rows[0]["id"].ToString();
            tbFname.Text = table.Rows[0]["f_name"].ToString();
            tbLname.Text = table.Rows[0]["l_name"].ToString();
            tbUname.Text = table.Rows[0]["uname"].ToString();
            tbPass.Text = table.Rows[0]["pwd"].ToString();

            //xu ly hinh anh
            byte[] pic = (byte[])table.Rows[0]["fig"];
            MemoryStream picture = new MemoryStream(pic);
            picbxPic.Image = Image.FromStream(picture);
        }
    }
}
