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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _21110849_DangPhuQuy_QLSV
{
    public partial class ResultForm : Form
    {
        public ResultForm()
        {
            InitializeComponent();
            dgvResult.AllowUserToAddRows = false;
            cbSem.SelectedIndex = 0;
        }
        SCORE score = new SCORE();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            dgvResult.DataSource = score.getResultStudent(Convert.ToInt32(cbSem.Text.ToString()));
            dgvResult.Columns["fname"].HeaderText = "First name";
            dgvResult.Columns["lname"].HeaderText = "Last name";
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
            printer.SubTitle = "BẢNG ĐIỂM NĂM HỌC 2022 - 2023" +
                $"\nHọc kỳ: {cbSem.Text} " +
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


            printer.PrintPreviewDataGridView(dgvResult);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int studentId = -1; string firstName = "";
            if (int.TryParse(tbSearch.Text, out studentId))
            {
                dgvResult.DataSource = score.getResultStudent(Convert.ToInt32(cbSem.Text.ToString()), studentId);
                dgvResult.Columns["fname"].HeaderText = "First name";
                dgvResult.Columns["lname"].HeaderText = "Last name";
            }
            else
            {
                firstName = tbSearch.Text.ToString();
                dgvResult.DataSource = score.getResultStudent(Convert.ToInt32(cbSem.Text.ToString()), fname: firstName);
                dgvResult.Columns["fname"].HeaderText = "First name";
                dgvResult.Columns["lname"].HeaderText = "Last name";
            }
        }

        private void dgvResult_DoubleClick(object sender, EventArgs e)
        {
            StudentResultForm studentResultForm = new StudentResultForm();
            studentResultForm.labelId.Text = dgvResult.CurrentRow.Cells["Id"].Value.ToString();
            studentResultForm.labelName.Text = dgvResult.CurrentRow.Cells["fname"].Value.ToString() + " " + dgvResult.CurrentRow.Cells["lname"].Value.ToString();
            studentResultForm.lbSem.Text = cbSem.Text.ToString();
            studentResultForm.Show(this);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ResultForm_Load(null, null);
        }

        private void cbSem_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResultForm_Load(null, null);
        }
    }
}
