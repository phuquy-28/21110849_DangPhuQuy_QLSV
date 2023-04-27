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
    public partial class SelectedContact : Form
    {
        public SelectedContact()
        {
            InitializeComponent();
            
        }
        CONTACT contact = new CONTACT();

        private void SelectedContact_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from mycontact");
            dgvSelectedContact.DataSource = contact.selectContactList(command);

            dgvSelectedContact.Columns["id"].HeaderText = "Id";
            dgvSelectedContact.Columns["fname"].HeaderText = "First name";
            dgvSelectedContact.Columns["lname"].HeaderText = "Last name";
            dgvSelectedContact.Columns["group_id"].HeaderText = "Group id";

            dgvSelectedContact.Columns["phone"].Visible = false;
            dgvSelectedContact.Columns["email"].Visible = false;
            dgvSelectedContact.Columns["address"].Visible = false;
            dgvSelectedContact.Columns["pic"].Visible = false;
            dgvSelectedContact.Columns["userid"].Visible = false;
            dgvSelectedContact.AllowUserToAddRows = false;
        }

        private void dgvSelectedContact_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
