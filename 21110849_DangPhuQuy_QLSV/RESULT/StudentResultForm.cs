using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110849_DangPhuQuy_QLSV
{
    public partial class StudentResultForm : Form
    {
        public StudentResultForm()
        {
            InitializeComponent();
        }
        SCORE score = new SCORE();

        private void StudentResultForm_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(labelId.Text.ToString());
            dgvStudentResult.DataSource = score.getStudentResultDetail(id);
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
            printer.SubTitle = "BẢNG ĐIỂM NĂM HỌC 2022 - 2023" +
                $"\nMSSV: {labelId.Text}" +
                $"\nHọ Tên: {labelName.Text}" +
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
            ii1.ImageX = 60;    //landscape 120
            ii1.ImageY = 40;

            Bitmap original = new Bitmap(Properties.Resources.fhq_logo);
            Bitmap dest = ResizeImage(original, new Size(110, 110));

            ii1.theImage = dest;
            printer.ImbeddedImageList.Add(ii1);


            printer.PrintPreviewDataGridView(dgvStudentResult);
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
    }
}
