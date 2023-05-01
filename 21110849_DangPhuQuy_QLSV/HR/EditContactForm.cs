using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110849_DangPhuQuy_QLSV.HR
{
    public partial class EditContactForm : Form
    {
        public EditContactForm()
        {
            InitializeComponent();
        }
        CONTACT contact = new CONTACT();

        private void btnSelect_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbContactId.Text);

            DataTable table = new DataTable();
            table = contact.getContactById(id);
            if (table.Rows.Count > 0)
            {
                tbFname.Text = table.Rows[0]["fname"].ToString();
                tbLname.Text = table.Rows[0]["lname"].ToString();
                cbGrp.Text = table.Rows[0]["group_id"].ToString();
                tbPhone.Text = table.Rows[0]["phone"].ToString();
                tbEmail.Text = table.Rows[0]["email"].ToString();
                rtbAdrs.Text = table.Rows[0]["address"].ToString();
                byte[] pic = (byte[])table.Rows[0]["pic"];
                MemoryStream picture = new MemoryStream(pic);
                picbxPic.Image = Image.FromStream(picture);
            }
            else
            {
                MessageBox.Show("Not found", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public bool verify()
        {
            if (tbContactId.Text == "" ||
                tbFname.Text == "" ||
                tbLname.Text == "" ||
                tbLname.Text == "" ||
                cbGrp.Text == "" ||
                tbPhone.Text == "" ||
                tbEmail.Text == "" ||
                rtbAdrs.Text == "" ||
                picbxPic.Image == null
                )
                return false;
            return true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbContactId.Text);
            string fname = tbFname.Text.Trim();
            string lname = tbLname.Text.Trim();
            int grp = Convert.ToInt32(cbGrp.Text);
            string phone = tbPhone.Text.Trim();
            string email = tbEmail.Text.Trim();
            string adrs = rtbAdrs.Text.Trim();
            MemoryStream pic = new MemoryStream();

            if (verify())
            {
                picbxPic.Image.Save(pic, picbxPic.Image.RawFormat);
                if (contact.updateContact(id, fname, lname, grp, phone, email, adrs, pic))
                {
                    MessageBox.Show("Editing Successfully", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvContactList.DataSource = contact.selectContactList(new SqlCommand("select * from mycontact"));
                }
                else
                {
                    MessageBox.Show("Editing Fail", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void isDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only input digits, control keys
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Only enter digits", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void emailTb_Validating(object sender, CancelEventArgs e)
        {
            if (!(new EmailAddressAttribute().IsValid(tbEmail.Text)))
            {
                MessageBox.Show("Email Address is not valid", "Email Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbEmail.Text = "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image (*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                picbxPic.Image = Image.FromFile(opf.FileName);
            }
        }


        private void EditContactForm_Load(object sender, EventArgs e)
        {
            //tbContactId.Enabled = false;

            SqlCommand command = new SqlCommand("select * from mycontact");
            //dgvContactList.DataSource = contact.selectContactList(command);

            //Xu ly hinh anh
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dgvContactList.RowTemplate.Height = 80;
            dgvContactList.DataSource = contact.selectContactList(command);
            picCol = (DataGridViewImageColumn)dgvContactList.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dgvContactList.AllowUserToAddRows = false;

            dgvContactList.Columns[0].HeaderText = "Contact ID";
            dgvContactList.Columns[1].HeaderText = "Firstname";
            dgvContactList.Columns[2].HeaderText = "Lastname";
            dgvContactList.Columns[3].HeaderText = "Group ID";
            dgvContactList.Columns[4].HeaderText = "Phone number";
            dgvContactList.Columns[5].HeaderText = "Email";
            dgvContactList.Columns[6].HeaderText = "Address";
            dgvContactList.Columns[7].HeaderText = "Picture";
            dgvContactList.Columns[8].HeaderText = "UserID";
        
        }

        private void dgvContactList_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvContactList.CurrentRow;

            tbContactId.Text = selectedRow.Cells["id"].Value.ToString();

            int id = Convert.ToInt32(tbContactId.Text);

            DataTable table = new DataTable();
            table = contact.getContactById(id);
            if (table.Rows.Count > 0)
            {
                tbFname.Text = table.Rows[0]["fname"].ToString();
                tbLname.Text = table.Rows[0]["lname"].ToString();
                cbGrp.Text = table.Rows[0]["group_id"].ToString();
                tbPhone.Text = table.Rows[0]["phone"].ToString();
                tbEmail.Text = table.Rows[0]["email"].ToString();
                rtbAdrs.Text = table.Rows[0]["address"].ToString();
                byte[] pic = (byte[])table.Rows[0]["pic"];
                MemoryStream picture = new MemoryStream(pic);
                picbxPic.Image = Image.FromStream(picture);
            }
            else
            {
                MessageBox.Show("Not found", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            AddCourseContactForm addCourseContactFrm = new AddCourseContactForm();
            addCourseContactFrm.tbContactId.Text = dgvContactList.CurrentRow.Cells["id"].Value.ToString();
            addCourseContactFrm.Show(this);
        }
    }
}
