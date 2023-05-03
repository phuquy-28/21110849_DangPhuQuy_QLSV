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
                string fullName = table.Rows[0]["f_name"].ToString().Trim() + " " + table.Rows[0]["l_name"].ToString().Trim();
                lbUsername.Text = "Welcome back ( " + fullName + " )";
            }
        }

        private void MainFormHR_Load(object sender, EventArgs e)
        {
            getImageAndUsername();
            loadComboBoxGrp();
            
        }

        private void loadComboBoxGrp()
        {
            cbSelectdGrp.DataSource = group.getGroups(Globals.GlobalUserId);
            cbSelectedGrpRemove.DataSource = group.getGroups(Globals.GlobalUserId);
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
                if (!group.groupExist(name, "add", userid, id) && !group.groupIdExist(id))
                {
                    if (group.insertGroup(id, name, userid))
                    {
                        MessageBox.Show("Adding Successfully", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadComboBoxGrp();
                        tbGrpId.Text = "";
                        tbGrpName.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Adding Fail", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Group name or Group Id has already exist", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(tbContactId.Text);
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
            try
            {
                if (!group.groupExist(name, "edit", Globals.GlobalUserId, id))
                {
                    if (group.updateGroup(id, name))
                    {
                        MessageBox.Show("Editing Successfully", "Editing Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadComboBoxGrp();
                        cbSelectdGrp.Text = "";
                        tbNewNameGrp.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Editing Fail", "Editing Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Group name has already exist", "Editing Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Editing Group", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void btnRemoveGrp_Click(object sender, EventArgs e)
        {
            DataRowView selected = cbSelectdGrp.SelectedItem as DataRowView;
            int id = Convert.ToInt32(selected["id"]);
            try
            {
                if (group.deleteGroup(id))
                {
                    MessageBox.Show("Deleting Successfully", "Deleting Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadComboBoxGrp();
                    cbSelectdGrp.Text = "";
                    tbNewNameGrp.Text = "";
                }
                else
                {
                    MessageBox.Show("Deleting Fail", "Deleting Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Deleting Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectedContact selectContactfrm = new SelectedContact();
            selectContactfrm.ShowDialog();
            int contactId = Convert.ToInt32(selectContactfrm.dgvSelectedContact.CurrentRow.Cells["id"].Value.ToString());
            tbContactId.Text = contactId.ToString();
            

            //tbContactId.Text = selectContactfrm.getContactId();
            ////MessageBox.Show(selectContactfrm.getContactId());
            //selectContactfrm.Show(this);


        }

        private void btnShowFull_Click(object sender, EventArgs e)
        {
            ShowFullListForm showFullListFrm = new ShowFullListForm();
            showFullListFrm.Show(this);
        }
    }
}
