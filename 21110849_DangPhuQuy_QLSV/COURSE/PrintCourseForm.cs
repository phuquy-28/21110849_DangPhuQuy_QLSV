using DGVPrinterHelper;
using Microsoft.Office.Interop.Word;
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
using DataTable = System.Data.DataTable;
using Word = Microsoft.Office.Interop.Word;

namespace _21110849_DangPhuQuy_QLSV
{
    public partial class PrintCourseForm : Form
    {
        public PrintCourseForm()
        {
            InitializeComponent();
            cbSem.SelectedIndex = 0;
        }
        MY_DB mydb = new MY_DB();
        private void PrintCourseForm_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from course where semester = @sem", mydb.getConnection);
            cmd.Parameters.Add("sem", SqlDbType.Int).Value = Convert.ToInt32(cbSem.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dgvListCourse.DataSource = table;

            dgvListCourse.Columns[0].HeaderText = "ID";
            dgvListCourse.Columns[1].HeaderText = "Label";
            dgvListCourse.Columns[2].HeaderText = "Period";
            dgvListCourse.Columns[3].HeaderText = "Description";
            dgvListCourse.Columns[4].Visible = false;
        }

        public void Export_Data_To_Word(DataGridView DGV, string filename)
        {
            if (DGV.Rows.Count != 0)
            {

                int RowCount = DGV.Rows.Count;
                int ColumnCount = DGV.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                //add rows
                int r = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                        //if (c != ColumnCount - 1)
                        //{
                        //    if (c != 3)
                        //        DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                        //    else
                        //    {
                        //        DateTime datetime = (DateTime)DGV.Rows[r].Cells[c].Value;
                        //        DataArray[r, c] = datetime.ToString("dd/MM/yyyy");
                        //    }
                        //}
                    } //end row loop
                } //end column loop

                Word.Document oDoc = new Word.Document();
                oDoc.Application.Visible = true;

                //page orintation
                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                for (r = 0; r <= RowCount - 1; r++)
                {
                    for (int c = 0; c <= ColumnCount - 1; c++)
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

                oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
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

                //header row style
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                //add header row manually
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
                }

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
                        "\n\nDANH SÁCH MÔN HỌC\nHỌC KỲ HK02 - NĂM HỌC 2022-2023";
                    headerRange.Font.Size = 16;
                    headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                //for images
                //for (int c = 0; c <= ColumnCount - 1; c++)
                //{
                //    for (r = 0; r <= RowCount - 1; r++)
                //    {
                //        if (c == ColumnCount - 1)
                //        {

                //            Object oMissing = oDoc.Tables[1].Cell(r + 2, 14).Range; //the position where you want to put the images

                //            Image sparePicture = ByteArrayToImage((byte[])DGV.Rows[r].Cells[c].Value);
                //            Clipboard.SetImage(sparePicture);
                //            Word.Paragraph oPara2 = oDoc.Content.Paragraphs.Add(ref oMissing);
                //            oPara2.Range.Paste();
                //            oPara2.Range.InsertParagraphAfter();
                //        }
                //    }
                //}

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

                Export_Data_To_Word(dgvListCourse, sfd.FileName);
                MessageBox.Show("Data exported successfully.", "Export to Word", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static Bitmap ResizeImage(Bitmap imgToResize, Size size)
        {
            Bitmap b = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage((Image)b))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(imgToResize, 0, 0, size.Width, size.Height);
            }
            return b;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();

            //Margin
            //printer.PrintMargins = new Margins(60, 60, 40, 100);

            //Title
            printer.Title = "TRƯỜNG ĐẠI HỌC SƯ PHẠM KỸ THUẬT" +
                             "\nTHÀNH PHỐ HỒ CHÍ MINH\n";
            printer.TitleSpacing = 10;

            //Subtitle
            //printer.SubTitle = String.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitle = "DANH SÁCH MÔN HỌC NĂM HỌC 2022 - 2023" +
                $"\nNgày in: {DateTime.Now.Date.ToString("dd/MM/yyyy")}";
            printer.SubTitleSpacing = 20;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;

            //PageNumber
            printer.PageNumbers = true;
            printer.PageNumberAlignment = StringAlignment.Near;
            printer.PageNumberInHeader = false;

            //Column
            printer.PorportionalColumns = true;

            //Header
            printer.HeaderCellAlignment = StringAlignment.Near;

            //Footer
            printer.Footer = $"TP.HCM, ngày    tháng    năm       " +
                             $"\nKý xác nhận";
            //printer.FooterSpacing = 15;
            printer.FooterAlignment = StringAlignment.Far;

            //Landscape
            printer.printDocument.DefaultPageSettings.Landscape = false;

            //set the rowheight equal to the cellheight in dgv
            printer.RowHeight = DGVPrinter.RowHeightSetting.CellHeight;


            DGVPrinter.ImbeddedImage ii1 = new DGVPrinter.ImbeddedImage();

            ii1.ImageAlignment = DGVPrinter.Alignment.NotSet;
            ii1.ImageLocation = DGVPrinter.Location.Absolute;
            ii1.ImageX = 60;
            ii1.ImageY = 40;

            Bitmap original = new Bitmap(Properties.Resources.fhq_logo);
            Bitmap dest = ResizeImage(original, new Size(110, 110));

            ii1.theImage = dest;
            printer.ImbeddedImageList.Add(ii1);


            printer.PrintPreviewDataGridView(dgvListCourse);
        }

        private void cbSem_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrintCourseForm_Load(null, null);
        }
    }
}
