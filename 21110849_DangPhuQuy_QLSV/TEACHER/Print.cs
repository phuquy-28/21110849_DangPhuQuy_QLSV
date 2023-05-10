using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using DGVPrinterHelper;

namespace _21110849_DangPhuQuy_QLSV
{
    public partial class Print : Form
    {
        MY_DB mydb = new MY_DB();
        STUDENTs student = new STUDENTs();
        public Print()
        {
            InitializeComponent();
        }

        public void fillGrid(SqlCommand command)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                System.Data.DataTable table = new System.Data.DataTable();
                table.Clear();
                adapter.Fill(table);
                for (int i = 7; i < table.Columns.Count - 1; i++)
                {
                    table.Columns[i].SetOrdinal(i + 1);
                }
                stdListDgv.DataSource = table;

                //Đổi tên các cột trong studentList DataGridView;
                stdListDgv.Columns[0].HeaderText = "ID";
                stdListDgv.Columns[1].HeaderText = "First Name";
                stdListDgv.Columns[2].HeaderText = "Last Name";
                stdListDgv.Columns[3].HeaderText = "Birthdate";
                stdListDgv.Columns[4].HeaderText = "Gender";
                stdListDgv.Columns[5].HeaderText = "Phone Number";
                stdListDgv.Columns[6].HeaderText = "Address";
                stdListDgv.Columns[7].HeaderText = "Email";
                stdListDgv.Columns[8].HeaderText = "Faculty";
                stdListDgv.Columns[9].HeaderText = "Major";
                stdListDgv.Columns[10].HeaderText = "Place of birth";
                stdListDgv.Columns[11].HeaderText = "Nationality";
                stdListDgv.Columns[12].HeaderText = "State";
                stdListDgv.Columns[13].HeaderText = "Picture";

                //Xu ly hinh anh
                DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                stdListDgv.RowTemplate.Height = 80;
                stdListDgv.DataSource = student.getStudents(command);
                picCol = (DataGridViewImageColumn)stdListDgv.Columns[13];
                picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                stdListDgv.AllowUserToAddRows = false; ;

                //Đổi thử tự hiển thị các cột 
                //stdListDgv.Columns[7].DisplayIndex = 13;
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

        private void Print_Load(object sender, EventArgs e)
        {
            fillGrid(new SqlCommand("select * from std", mydb.getConnection));
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (rbtnNo.Checked)
            {
                if (rbtnAll.Checked)
                {
                    fillGrid(new SqlCommand("select * from std", mydb.getConnection));
                }
                else if (rbtnFemale.Checked)
                {
                    fillGrid(new SqlCommand("select * from std where gender = 'female'", mydb.getConnection));
                }
                else
                {
                    fillGrid(new SqlCommand("select * from std where gender = 'male'", mydb.getConnection));
                }
            }
            else
            {
                if (rbtnAll.Checked)
                {
                    SqlCommand command = new SqlCommand("select * from std where bdate between @startDate and @endDate", mydb.getConnection);
                    command.Parameters.Add("@startDate", SqlDbType.Date).Value = dtpStart.Value;
                    command.Parameters.Add("@endDate", SqlDbType.Date).Value = dtpEnd.Value;
                    fillGrid(command);

                }
                else if (rbtnFemale.Checked)
                {
                    SqlCommand command = new SqlCommand("select * from std where gender = @gender and bdate between @startDate and @endDate", mydb.getConnection);
                    command.Parameters.Add("@gender", SqlDbType.NVarChar).Value = "female";
                    command.Parameters.Add("@startDate", SqlDbType.Date).Value = dtpStart.Value;
                    command.Parameters.Add("@endDate", SqlDbType.Date).Value = dtpEnd.Value;
                    fillGrid(command);
                }
                else
                {
                    SqlCommand command = new SqlCommand("select * from std where gender = @gender and bdate between @startDate and @endDate", mydb.getConnection);
                    command.Parameters.Add("@gender", SqlDbType.NVarChar).Value = "male";
                    command.Parameters.Add("@startDate", SqlDbType.Date).Value = dtpStart.Value;
                    command.Parameters.Add("@endDate", SqlDbType.Date).Value = dtpEnd.Value;
                    fillGrid(command);
                }
            }
        }

        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

        //public void Export_Data_To_Word(DataGridView DGV, string filename)
        //{
        //    if (DGV.Rows.Count != 0)
        //    {

        //        int RowCount = DGV.Rows.Count;
        //        int ColumnCount = DGV.Columns.Count;
        //        Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

        //        //add rows
        //        int r = 0;
        //        for (int c = 0; c <= ColumnCount - 1; c++)
        //        {
        //            for (r = 0; r <= RowCount - 1; r++)
        //            {
        //                //if (c != ColumnCount - 1)
        //                //{
        //                //        DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
        //                //}
        //                if (c != ColumnCount - 1)
        //                {
        //                    if (c != 3)
        //                        DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
        //                    else
        //                    {
        //                        DateTime datetime = (DateTime)DGV.Rows[r].Cells[c].Value;
        //                        DataArray[r, c] = datetime.ToString("dd/MM/yyyy");
        //                    }
        //                }
        //            } //end row loop
        //        } //end column loop

        //        Word.Document oDoc = new Word.Document();
        //        oDoc.Application.Visible = true;

        //        //page orintation
        //        oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

        //        dynamic oRange = oDoc.Content.Application.Selection.Range;
        //        string oTemp = "";
        //        for (r = 0; r <= RowCount - 1; r++)
        //        {
        //            for (int c = 0; c <= ColumnCount - 1; c++)
        //            {
        //                oTemp = oTemp + DataArray[r, c] + "\t";

        //            }
        //        }

        //        //table format
        //        oRange.Text = oTemp;

        //        object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
        //        object ApplyBorders = true;
        //        object AutoFit = true;
        //        object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

        //        oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
        //                              Type.Missing, Type.Missing, ref ApplyBorders,
        //                              Type.Missing, Type.Missing, Type.Missing,
        //                              Type.Missing, Type.Missing, Type.Missing,
        //                              Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

        //        oRange.Select();

        //        oDoc.Application.Selection.Tables[1].Select();
        //        oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
        //        oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
        //        oDoc.Application.Selection.Tables[1].Rows[1].Select();
        //        oDoc.Application.Selection.InsertRowsAbove(1);
        //        oDoc.Application.Selection.Tables[1].Rows[1].Select();

        //        //header row style
        //        oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
        //        oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
        //        oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

        //        //add header row manually
        //        for (int c = 0; c <= ColumnCount - 1; c++)
        //        {
        //            oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
        //        }

        //        //table style 
        //        oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
        //        oDoc.Application.Selection.Tables[1].Rows[1].Select();
        //        oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

        //        //header text
        //        foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
        //        {
        //            Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
        //            headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
        //            headerRange.Text = "STUDENTS LIST";
        //            headerRange.Font.Size = 16;
        //            headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //        }

        //        for (int c = 0; c <= ColumnCount - 1; c++)
        //        {
        //            for (r = 0; r <= RowCount - 1; r++)
        //            {
        //                if (c == ColumnCount - 1)
        //                {

        //                    Object oMissing = oDoc.Tables[1].Cell(r + 2, 14).Range; //the position where you want to put the images

        //                    Image sparePicture = ByteArrayToImage((byte[])DGV.Rows[r].Cells[c].Value);
        //                    Clipboard.SetImage(sparePicture);
        //                    Word.Paragraph oPara2 = oDoc.Content.Paragraphs.Add(ref oMissing);
        //                    oPara2.Range.Paste();
        //                    oPara2.Range.InsertParagraphAfter();
        //                }
        //            }
        //        }

        //        //save the file
        //        oDoc.SaveAs2(filename);

        //        //NASSIM LOUCHANI
        //    }
        //}

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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print document";
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;
            printDoc.DefaultPageSettings.Landscape = true;
            printDoc.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            if (printDlg.ShowDialog() == DialogResult.OK)
                printDoc.Print();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bitmap = new Bitmap(stdListDgv.Width, stdListDgv.Height);
            stdListDgv.DrawToBitmap(bitmap, new Rectangle(0, 0, stdListDgv.Width, stdListDgv.Height));
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.docx)|*.docx";

            sfd.FileName = "export.docx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                Export_Data_To_Word(stdListDgv, sfd.FileName);
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

        private void btnPrint_Click_1(object sender, EventArgs e)
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
            printer.SubTitle = "DANH SÁCH SINH VIÊN NĂM HỌC 2022 - 2023" +
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
            printer.printDocument.DefaultPageSettings.Landscape = true;

            //set the rowheight equal to the cellheight in dgv
            printer.RowHeight = DGVPrinter.RowHeightSetting.CellHeight;


            DGVPrinter.ImbeddedImage ii1 = new DGVPrinter.ImbeddedImage();

            ii1.ImageAlignment = DGVPrinter.Alignment.NotSet;
            ii1.ImageLocation = DGVPrinter.Location.Absolute;
            ii1.ImageX = 120;
            ii1.ImageY = 40;

            Bitmap original = new Bitmap(Properties.Resources.fhq_logo);
            Bitmap dest = ResizeImage(original, new Size(110, 110));

            ii1.theImage = dest;
            printer.ImbeddedImageList.Add(ii1);


            printer.PrintPreviewDataGridView(stdListDgv);
        }
    }
}
