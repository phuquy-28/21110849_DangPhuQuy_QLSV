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
    public partial class ImportScoreForm : Form
    {
        public ImportScoreForm()
        {
            InitializeComponent();
        }
        public int CourseId { get; set; }
        MY_DB mydb = new MY_DB();
        BindingSource courseBindingSource = new BindingSource();

        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("select * from score", mydb.getConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                courseBindingSource.DataSource = table;

                DataTable dt = tableCollection[cbSheet.SelectedItem.ToString()];
                dt.Columns[0].ColumnName = "id";
                dt.Columns[1].ColumnName = "fname";
                dt.Columns[2].ColumnName = "lname";
                dt.Columns[3].ColumnName = "score";
                dt.Columns[4].ColumnName = "description";
                for (int i = 2; i >= 0; i--)
                {
                    dt.Rows.RemoveAt(i);
                }
                dgvReadFile.DataSource = dt;
                dgvReadFile.Columns["id"].HeaderText = "Id";
                dgvReadFile.Columns["fname"].HeaderText = "First name";
                dgvReadFile.Columns["lname"].HeaderText = "Last name";
                dgvReadFile.Columns["score"].HeaderText = "Score";
                dgvReadFile.Columns["description"].HeaderText = "Description";
                dgvReadFile.AllowUserToAddRows = false;


                if (dt != null)
                {
                    List<SCORE> score = new List<SCORE>();
                    for (int i = 0; i < dgvReadFile.Rows.Count; i++)
                    {
                        SCORE s = new SCORE();
                        s.StudentId = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                        s.CourseId = CourseId;
                        s.StudentScore = Convert.ToInt32(dt.Rows[i]["score"].ToString());
                        s.Description = dt.Rows[i]["description"].ToString();
                        score.Add(s);
                    }
                    courseBindingSource.DataSource = score;
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
                DapperPlusManager.Entity<SCORE>()
                    .Table("score")
                    .Map(x => x.StudentId, "student_id")
                    .Map(x => x.CourseId, "course_id")
                    .Map(x => x.StudentScore, "student_score")
                    .Map(x => x.Description, "description");

                List<SCORE> score = courseBindingSource.DataSource as List<SCORE>;
                if (score != null)
                {
                    IDbConnection db = mydb.getConnection;
                    db.BulkInsert(score);
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
