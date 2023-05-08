using ExcelDataReader;
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
using Z.Dapper.Plus;

namespace _21110849_DangPhuQuy_QLSV
{
    public partial class ImportCourseForm : Form
    {
        public ImportCourseForm()
        {
            InitializeComponent();
        }
        MY_DB mydb = new MY_DB();
        BindingSource courseBindingSource = new BindingSource();

        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("select * from course", mydb.getConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                courseBindingSource.DataSource = table;

                DataTable dt = tableCollection[cbSheet.SelectedItem.ToString()];
                dgvReadFile.DataSource = dt;
                dgvReadFile.AllowUserToAddRows = false;

                if (dt != null)
                {
                    List<COURSE> course = new List<COURSE>();
                    for (int i = 0; i < dgvReadFile.Rows.Count; i++)
                    {
                        COURSE c = new COURSE();
                        c.Id = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                        c.Label = dt.Rows[i]["label"].ToString();
                        c.Period = Convert.ToInt32(dt.Rows[i]["period"].ToString());
                        c.Description = dt.Rows[i]["description"].ToString();
                        c.Semester = Convert.ToInt32(dt.Rows[i]["semester"].ToString());
                        course.Add(c);
                    }
                    courseBindingSource.DataSource = course;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                foreach (DataTable tbl in tableCollection)
                {
                    cbSheet.Items.Add(tbl.TableName);
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                DapperPlusManager.Entity<COURSE>()
                    .Table("course")
                    .Map(x => x.Id, "id")
                    .Map(x => x.Label, "label")
                    .Map(x => x.Period, "period")
                    .Map(x => x.Description, "description")
                    .Map(x => x.Semester, "semester");

                List<COURSE> course = courseBindingSource.DataSource as List<COURSE>;
                if (course != null)
                {
                    IDbConnection db = mydb.getConnection;
                    db.BulkInsert(course);
                    MessageBox.Show("Finish");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
