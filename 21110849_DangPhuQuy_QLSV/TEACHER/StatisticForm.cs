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
    public partial class StatisticForm : Form
    {
        public StatisticForm()
        {
            InitializeComponent();
        }

        Color panTotalColor;
        Color panFemaleColor;
        Color panMaleColor;

        private void StatisticForm_Load(object sender, EventArgs e)
        {
            //get panels color
            panTotalColor = panelTotal.BackColor;
            panFemaleColor = panelFemale.BackColor;
            panMaleColor = panelMale.BackColor;


            //display the values
            STUDENTs student = new STUDENTs();
            double total = Convert.ToDouble(student.totalStudent());
            double totalFemale = Convert.ToDouble(student.totalFamale());
            double totalMale = Convert.ToDouble(student.totalMale());

            //Tinh %
            double femalePercentage = totalFemale * 100 / total;
            double malePercentage = totalMale * 100 / total;

            lbTotal.Text = ("Total Students: " + total.ToString() + " - (100%)");
            lbFemale.Text = ("Female Students: " + totalFemale.ToString() + " - (" + femalePercentage.ToString("0.00") + "%)");
            lbMale.Text = ("Male Students: " + totalMale.ToString() + " - (" + malePercentage.ToString("0.00") + "%)");

            chartGender.Series["Students"].Points.AddXY("Female", Convert.ToInt32(student.totalFamale()));
            chartGender.Series["Students"].Points.AddXY("Male", Convert.ToInt32(student.totalMale()));
            
            chartGenderPie.Series["Students"].Points.AddXY("Female", Convert.ToInt32(student.totalFamale()));
            chartGenderPie.Series["Students"].Points.AddXY("Male", Convert.ToInt32(student.totalMale()));
        }

    }
}
