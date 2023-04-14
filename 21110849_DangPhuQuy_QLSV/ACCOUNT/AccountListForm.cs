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
    }
}
