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
    public partial class AccountListForm : Form
    {
        public AccountListForm()
        {
            InitializeComponent();
        }

        MY_DB mydb = new MY_DB();

        private void AccountListForm_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from log_in", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dgvAccList.DataSource = table;

            dgvAccList.Columns[0].HeaderText = "Username";
            dgvAccList.Columns[1].HeaderText = "Password";
            dgvAccList.Columns[2].HeaderText = "Role";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                AccountListForm_Load(null, null);
            }
            else if(tabControl1.SelectedIndex == 1)
            {
                loadTabHr();
            }
        }

        public void loadTabHr()
        {
            SqlCommand command = new SqlCommand("select * from hr", mydb.getConnection);

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
    }
}
