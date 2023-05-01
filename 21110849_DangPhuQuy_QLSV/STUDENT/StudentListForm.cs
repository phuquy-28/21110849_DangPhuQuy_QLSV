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
using Word = Microsoft.Office.Interop.Word;

namespace _21110849_DangPhuQuy_QLSV
{
    public partial class StudentListForm : Form
    {
        public StudentListForm()
        {
            InitializeComponent();
        }

        MY_DB mydb = new MY_DB();

        STUDENTs student = new STUDENTs();

        internal void loadData(SqlCommand command)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable table = new DataTable();
                table.Clear();
                adapter.Fill(table);
                for (int i = 7; i < table.Columns.Count - 1; i++)
                {
                    table.Columns[i].SetOrdinal(i + 1);
                }
                stdListDGV.DataSource = table;

                //Đổi tên các cột trong studentList DataGridView;
                stdListDGV.Columns[0].HeaderText = "ID";
                stdListDGV.Columns[1].HeaderText = "First Name";
                stdListDGV.Columns[2].HeaderText = "Last Name";
                stdListDGV.Columns[3].HeaderText = "Birthdate";
                stdListDGV.Columns[4].HeaderText = "Gender";
                stdListDGV.Columns[5].HeaderText = "Phone Number";
                stdListDGV.Columns[6].HeaderText = "Address";
                stdListDGV.Columns[7].HeaderText = "Email";
                stdListDGV.Columns[8].HeaderText = "Faculty";
                stdListDGV.Columns[9].HeaderText = "Major";
                stdListDGV.Columns[10].HeaderText = "Place of birth";
                stdListDGV.Columns[11].HeaderText = "Nationality";
                stdListDGV.Columns[12].HeaderText = "State";
                stdListDGV.Columns[13].HeaderText = "Picture";

                //Xu ly hinh anh
                DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                stdListDGV.RowTemplate.Height = 80;
                stdListDGV.DataSource = student.getStudents(command);
                //picCol = (DataGridViewImageColumn)stdListDGV.Columns[7];
                picCol = (DataGridViewImageColumn)stdListDGV.Columns[13];
                picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                stdListDGV.AllowUserToAddRows = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void StudentListForm_Load(object sender, EventArgs e)
        {
            mydb.openConnection();
            SqlCommand cmd = new SqlCommand("select * from std", mydb.getConnection);
            loadData(cmd);
            mydb.closeConnection();
        }


        private void refreshBtn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from std", mydb.getConnection);
            loadData(cmd);
        }

        private void stdListDGV_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                UpdateDeleteStudentForm updateDeleteStdF = new UpdateDeleteStudentForm();
                //thu tu cua cac cot: id  - fname - lname - bd - gdr - phone - adrs - pic - email - faculty - major - pob - nationality - state
                updateDeleteStdF.idTb.Text = stdListDGV.CurrentRow.Cells[0].Value.ToString();
                updateDeleteStdF.firstnameTb.Text = stdListDGV.CurrentRow.Cells[1].Value.ToString();
                updateDeleteStdF.lastnameTb.Text = stdListDGV.CurrentRow.Cells[2].Value.ToString();
                updateDeleteStdF.dobDtp.Value = (DateTime)stdListDGV.CurrentRow.Cells[3].Value;

                //gender
                if (stdListDGV.CurrentRow.Cells[4].Value.ToString() == "Female")
                {
                    updateDeleteStdF.FemaleBtn.Checked = true;
                }

                updateDeleteStdF.phoneTB.Text = stdListDGV.CurrentRow.Cells[5].Value.ToString();
                updateDeleteStdF.addressTb.Text = stdListDGV.CurrentRow.Cells[6].Value.ToString();

                //code xu ly hinh anh up len
                if ((byte[])stdListDGV.CurrentRow.Cells[13].Value != null)
                {
                    byte[] pic;
                    pic = (byte[])stdListDGV.CurrentRow.Cells[13].Value;
                    MemoryStream picture = new MemoryStream(pic);
                    updateDeleteStdF.picturePb.Image = Image.FromStream(picture);
                }

                

                updateDeleteStdF.emailTb.Text = stdListDGV.CurrentRow.Cells[7].Value.ToString();
                updateDeleteStdF.facultyCb.Text = stdListDGV.CurrentRow.Cells[8].Value.ToString();
                updateDeleteStdF.majorCb.Text = stdListDGV.CurrentRow.Cells[9].Value.ToString();
                updateDeleteStdF.pobTb.Text = stdListDGV.CurrentRow.Cells[10].Value.ToString();
                updateDeleteStdF.nationalityTb.Text = stdListDGV.CurrentRow.Cells[11].Value.ToString();
                updateDeleteStdF.stateCb.Text = stdListDGV.CurrentRow.Cells[12].Value.ToString();

                updateDeleteStdF.Show();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM std WHERE CONCAT (fname, lname) LIKE '%" + findTb.Text + "%'", mydb.getConnection);
            mydb.openConnection();
            loadData(cmd);
            mydb.closeConnection();
        }

        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

        public void Export_Data_To_Word(DataGridView DGV, string filename)
        {
            if (DGV.Rows.Count != 0)
            {

                int RowCount = DGV.Rows.Count;
                int ColumnCount = DGV.Columns.Count;
                int WantedCol = 7; //id, fname, lname bdate, phone, major, pic
                                   //0, 1, 2, 3, 5, 9, 13
                //Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];
                Object[,] DataArray = new object[RowCount + 1, WantedCol + 1];

                //add rows
                int r = 0; int cArr = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    if (c == 0 || c == 1 || c == 2 || c == 3 || c == 5 || c == 9 || c == 13)
                    {
                        for (r = 0; r <= RowCount - 1; r++)
                        {
                            if (c != ColumnCount - 1)
                            {
                                if (c != 3)
                                {
                                    DataArray[r, cArr] = DGV.Rows[r].Cells[c].Value;
                                }
                                else
                                {
                                    DateTime datetime = (DateTime)DGV.Rows[r].Cells[c].Value;
                                    DataArray[r, cArr] = datetime.ToString("dd/MM/yyyy");
                                }
                            }
                        } //end row loop
                        cArr++;
                    }
                        
                    
                } //end column loop

                Word.Document oDoc = new Word.Document();
                oDoc.Application.Visible = true;

                //page orintation
                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                for (r = 0; r <= RowCount - 1; r++)
                {
                    for (int c = 0; c <= WantedCol - 1; c++)
                    {
                        oTemp = oTemp + DataArray[r, c] + "\t";

                    }
                }

                //table format
                oRange.Text = oTemp;

                object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                object ApplyBorders = true;
                object AutoFit = true;
                object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

                oRange.ConvertToTable(ref Separator, ref RowCount, ref WantedCol,//
                                      Type.Missing, Type.Missing, ref ApplyBorders,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

                oRange.Select();

                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();

                //add header row manually
                cArr = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    if (c == 4 || c == 6 || c == 7 || c == 8 || c == 10 || c == 11 || c == 12)
                        continue;
                    else
                    {
                        oDoc.Application.Selection.Tables[1].Cell(1, cArr + 1).Range.Text = DGV.Columns[c].HeaderText;
                        cArr++;
                    }
                }

                //header row style
                //oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 12;

                //table style 
                oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                //header text
                foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                    headerRange.Text = $"TRƯỜNG ĐẠI HỌC SPKT TP.HCM\t\t\tNgày in: {DateTime.Now.ToString("dd/MM/yyyy")}" +
                        "\n\nDANH SÁCH SINH VIÊN\nHỌC KỲ HK02 - NĂM HỌC 2022-2023";
                    headerRange.Font.Size = 14;
                    headerRange.Bold = 1;
                    headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        if (c == ColumnCount - 1)
                        {

                            Object oMissing = oDoc.Tables[1].Cell(r + 2, 7).Range; //the position where you want to put the images

                            Image sparePicture = ByteArrayToImage((byte[])DGV.Rows[r].Cells[c].Value);
                            Clipboard.SetImage(sparePicture);
                            Word.Paragraph oPara2 = oDoc.Content.Paragraphs.Add(ref oMissing);
                            oPara2.Range.Paste();
                            oPara2.Range.InsertParagraphAfter();
                        }
                    }
                }

                //save the file
                oDoc.SaveAs2(filename);

                //NASSIM LOUCHANI
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.docx)|*.docx";

            sfd.FileName = "export.docx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                Export_Data_To_Word(stdListDGV, sfd.FileName);
                MessageBox.Show("Data exported successfully.", "Export to Word", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
