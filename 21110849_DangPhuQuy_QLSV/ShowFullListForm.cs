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
    public partial class ShowFullListForm : Form
    {
        public ShowFullListForm()
        {
            InitializeComponent();
        }

        CONTACT contact = new CONTACT();

        private void SelectContactForm_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from mycontact");
            DataTable table = new DataTable();
            table = contact.selectContactList(cmd);
            dgvContactList.DataSource = table;
        }

        private void dgvContactList_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
