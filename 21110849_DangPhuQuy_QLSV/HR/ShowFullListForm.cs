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

        private void ShowFullListForm_Load(object sender, EventArgs e)
        {
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();

            dgvContactList.RowTemplate.Height = 80;
            //
            SqlCommand command = new SqlCommand("Select mycontact.id as [Id], fname as [First name], lname as [Last name], mygroups.name as 'Group', phone, email, address, pic " +
                "From mycontact join mygroups on mycontact.group_id = mygroups.id " +
                "Where mycontact.userid = @userid ");
            command.Parameters.Add("@userid", SqlDbType.Int).Value = Globals.GlobalUserId;
            dgvContactList.DataSource = contact.selectContactList(command);
            dgvContactList.AllowUserToAddRows = false;

            picCol = (DataGridViewImageColumn)dgvContactList.Columns["pic"];

            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            for (int i = 0; i < dgvContactList.Rows.Count; i++)
            {
                if (i % 2 != 0)
                {
                    dgvContactList.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }

            }

            GROUP group = new GROUP();
            lisboxGroup.DataSource = group.getGroups(Globals.GlobalUserId);
            lisboxGroup.DisplayMember = "name";
            lisboxGroup.ValueMember = "id";

            lisboxGroup.SelectedItem = null;
            dgvContactList.ClearSelection();

        }

        private void dgvContactList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i = 0; i < dgvContactList.Rows.Count; i++)
            {
                if (i % 2 != 0)
                {
                    dgvContactList.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }
        }

        private void lisboxGroup_Click(object sender, EventArgs e)
        {
            try
            {
                int groupId = (Int32)lisboxGroup.SelectedValue;
                SqlCommand command = new SqlCommand("Select mycontact.id as [Id], fname as [First name], lname as [Last name], mygroups.name as 'Group', phone, email, address, pic " +
                "From mycontact join mygroups on mycontact.group_id = mygroups.id " +
                "Where mycontact.userid = @userid and mycontact.group_id = @groupid ");
                command.Parameters.Add("@userid", SqlDbType.Int).Value = Globals.GlobalUserId;
                command.Parameters.Add("@groupid", SqlDbType.Int).Value = groupId;
                dgvContactList.DataSource = contact.selectContactList(command);

                for (int i = 0; i < dgvContactList.Rows.Count; i++)
                {
                    if (i %2 != 0)
                    {
                        dgvContactList.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgvContactList.ClearSelection();
        }

        private void lbShowAll_Click(object sender, EventArgs e)
        {
            ShowFullListForm_Load(null, null);
        }

        private void dgvContactList_DoubleClick(object sender, EventArgs e)
        {
            CourseContactForm courseContactFrm = new CourseContactForm();
            courseContactFrm.tbContactId.Text = dgvContactList.CurrentRow.Cells["id"].Value.ToString();
            string fname = dgvContactList.CurrentRow.Cells["First name"].Value.ToString();
            string lname = dgvContactList.CurrentRow.Cells["Last name"].Value.ToString();
            courseContactFrm.lbName.Text = $"Name contact: {fname} {lname}";
            

            courseContactFrm.Show(this);
        }
    }
}
