using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110849_DangPhuQuy_QLSV
{
    public partial class PrintScoreForm : Form
    {
        public PrintScoreForm()
        {
            InitializeComponent();
        }
        SCORE score = new SCORE();
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dgvStudentScore.Width, this.dgvStudentScore.Height);
            this.dgvStudentScore.DrawToBitmap(bm, new Rectangle(0, 0, this.dgvStudentScore.Width, this.dgvStudentScore.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();
            printDialog.Document = printDocument;
            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void PrintScoreForm_Load(object sender, EventArgs e)
        {
            dgvStudentScore.DataSource = score.getStudentScore();
        }
    }
}
