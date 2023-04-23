using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Z.Dapper.Plus;

namespace _21110849_DangPhuQuy_QLSV
{
    public partial class ImportByExcelFile : Form
    {
        MY_DB mydb = new MY_DB();
        public ImportByExcelFile()
        {
            InitializeComponent();
        }

        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cbSheet.SelectedItem.ToString()];
            dgvReadFile.DataSource = dt;
            if (dt != null)
            {
                List<STUDENTs> student = new List<STUDENTs>();
                for (int i = 0; i < dgvReadFile.Rows.Count - 1; i++)
                {
                    STUDENTs s = new STUDENTs();
                    s.Id = dt.Rows[i]["id"].ToString();
                    s.FName = dt.Rows[i]["fname"].ToString();
                    s.LName = dt.Rows[i]["lname"].ToString();
                    s.Birthday = (DateTime)dt.Rows[i]["bdate"];
                    s.Gender = dt.Rows[i]["gender"].ToString();
                    s.Phone = dt.Rows[i]["phone"].ToString();
                    s.Address = dt.Rows[i]["address"].ToString();
                    //s.Picture = null;//(MemoryStream)dt.Rows[i]["picture"];

                    // Đọc hình ảnh mặc định từ tệp Resource
                    Bitmap defaultImage = Properties.Resources.user1;

                    // Chuyển đổi hình ảnh sang kiểu MemoryStream
                    MemoryStream ms = new MemoryStream();
                    defaultImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                    // Sử dụng MemoryStream
                    s.Picture = ms;

                    s.Email = dt.Rows[i]["email"].ToString();
                    s.Faculty = dt.Rows[i]["faculty"].ToString();
                    s.Major = dt.Rows[i]["major"].ToString();
                    s.Pob = dt.Rows[i]["pob"].ToString();
                    s.Nationality = dt.Rows[i]["nationality"].ToString();
                    s.State = dt.Rows[i]["state"].ToString();
                    student.Add(s);
                }
                stdBindingSource.DataSource = student;
            }
        }

        DataTableCollection tableCollection;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbFileName.Text = ofd.FileName;
                var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                });
                tableCollection = result.Tables;
                cbSheet.Items.Clear();
                foreach(DataTable tbl in tableCollection)
                {
                    cbSheet.Items.Add(tbl.TableName);
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                DapperPlusManager.Entity<STUDENTs>().Table("std");
                List<STUDENTs> student = stdBindingSource.DataSource as List<STUDENTs>;
                if (student != null)
                {
                    IDbConnection db = mydb.getConnection;
                    db.BulkInsert(student);
                    MessageBox.Show("Finish");
                    
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
