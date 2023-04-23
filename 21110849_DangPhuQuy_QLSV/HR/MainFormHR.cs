using _21110849_DangPhuQuy_QLSV.HR;
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
        GROUP group = new GROUP();
        CONTACT contact = new CONTACT();

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
            cbSelectdGrp.DataSource = group.selectGroupList(new SqlCommand("Select * from mygroups"));
            cbSelectedGrpRemove.DataSource = group.selectGroupList(new SqlCommand("Select * from mygroups"));
            cbSelectdGrp.DisplayMember = "name";
            cbSelectedGrpRemove.DisplayMember = "name";
            cbSelectdGrp.Text = "";
            cbSelectedGrpRemove.Text = "";
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
            EditContactForm editContactForm = new EditContactForm();
            editContactForm.Show(this);
        }

        private void btnAddGrpName_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbGrpId.Text);
            string name = tbGrpName.Text;
            int userid = Globals.GlobalUserId;
            try
            {
                if (group.insertGroup(id, name, userid))
                {
                    MessageBox.Show("Adding Successfully", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tbGrpId.Text = "";
                    tbGrpName.Text = "";
                }
                else
                {
                    MessageBox.Show("Adding Fail", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbContactId.Text);
            try
            {
                if (contact.deleteContact(id))
                {
                    MessageBox.Show("Deleting Successfully", "Delete Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbContactId.Text = "";
                }
                else
                {
                    MessageBox.Show("Deleting Fail", "Delete Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void btnEditGrp_Click(object sender, EventArgs e)
        {
            DataRowView selected = cbSelectdGrp.SelectedItem as DataRowView;
            int id = Convert.ToInt32(selected["id"]);
            string name = tbNewNameGrp.Text;
            //MessageBox.Show(id.ToString() + "  " + name);

            if (group.updateGroup(id, name))
            {
                MessageBox.Show("Editing Successfully", "Editing Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbSelectdGrp.DataSource = group.selectGroupList(new SqlCommand("Select * from mygroups"));
                cbSelectdGrp.DisplayMember = "name";
                cbSelectdGrp.Text = "";
                tbNewNameGrp.Text = "";
            }
            else
            {
                MessageBox.Show("Editing Fail", "Editing Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveGrp_Click(object sender, EventArgs e)
        {
            DataRowView selected = cbSelectdGrp.SelectedItem as DataRowView;
            int id = Convert.ToInt32(selected["id"]);

            if (group.deleteGroup(id))
            {
                MessageBox.Show("Deleting Successfully", "Deleting Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbSelectdGrp.DataSource = group.selectGroupList(new SqlCommand("Select * from mygroups"));
                cbSelectdGrp.DisplayMember = "name";
                cbSelectdGrp.Text = "";
                tbNewNameGrp.Text = "";
            }
            else
            {
                MessageBox.Show("Deleting Fail", "Deleting Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
