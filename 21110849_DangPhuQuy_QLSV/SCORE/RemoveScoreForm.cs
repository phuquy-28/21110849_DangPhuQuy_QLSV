﻿using System;
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
    public partial class RemoveScoreForm : Form
    {
        SCORE score = new SCORE();
        public RemoveScoreForm()
        {
            InitializeComponent();
        }

        private void RemoveScoreForm_Load(object sender, EventArgs e)
        {
            dgvStudentScore.DataSource = score.getStudentScore();

            //đổi tên
            dgvStudentScore.Columns["id"].HeaderText = "ID";
            dgvStudentScore.Columns["fname"].HeaderText = "First name";
            dgvStudentScore.Columns["lname"].HeaderText = "Last name";
            dgvStudentScore.Columns["course_id"].HeaderText = "Course ID";
            dgvStudentScore.Columns["label"].HeaderText = "Course name";
            dgvStudentScore.Columns["student_score"].HeaderText = "Student score";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvStudentScore.CurrentRow;

            int studentId = Convert.ToInt32(selectedRow.Cells[0].Value);
            int courseId = Convert.ToInt32(selectedRow.Cells[3].Value);

            if (score.deleteScore(studentId, courseId))
            {
                dgvStudentScore.DataSource = score.getStudentScore();
                MessageBox.Show("Student Score Deleted", "Remove score", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Student Score not Deleted", "Remove score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvStudentScore_Click(object sender, EventArgs e)
        {

        }
    }
}
