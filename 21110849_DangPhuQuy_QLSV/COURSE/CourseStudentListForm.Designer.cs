namespace _21110849_DangPhuQuy_QLSV
{
    partial class CourseStudentListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCourseStudent = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.labelCourseName = new System.Windows.Forms.Label();
            this.labelCourseId = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelSemester = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourseStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Course Name:";
            // 
            // dgvCourseStudent
            // 
            this.dgvCourseStudent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCourseStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourseStudent.Location = new System.Drawing.Point(13, 70);
            this.dgvCourseStudent.Name = "dgvCourseStudent";
            this.dgvCourseStudent.Size = new System.Drawing.Size(657, 315);
            this.dgvCourseStudent.TabIndex = 2;
            this.dgvCourseStudent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCourseStudent_CellContentClick);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(286, 391);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(99, 40);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // labelCourseName
            // 
            this.labelCourseName.AutoSize = true;
            this.labelCourseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCourseName.Location = new System.Drawing.Point(162, 13);
            this.labelCourseName.Name = "labelCourseName";
            this.labelCourseName.Size = new System.Drawing.Size(51, 20);
            this.labelCourseName.TabIndex = 4;
            this.labelCourseName.Text = "label2";
            // 
            // labelCourseId
            // 
            this.labelCourseId.AutoSize = true;
            this.labelCourseId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCourseId.Location = new System.Drawing.Point(124, 36);
            this.labelCourseId.Name = "labelCourseId";
            this.labelCourseId.Size = new System.Drawing.Size(51, 20);
            this.labelCourseId.TabIndex = 6;
            this.labelCourseId.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Course Id:";
            // 
            // labelSemester
            // 
            this.labelSemester.AutoSize = true;
            this.labelSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSemester.Location = new System.Drawing.Point(617, 35);
            this.labelSemester.Name = "labelSemester";
            this.labelSemester.Size = new System.Drawing.Size(51, 20);
            this.labelSemester.TabIndex = 8;
            this.labelSemester.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(505, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Semester:";
            // 
            // CourseStudentListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 439);
            this.Controls.Add(this.labelSemester);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelCourseId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelCourseName);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgvCourseStudent);
            this.Controls.Add(this.label1);
            this.Name = "CourseStudentListForm";
            this.Text = "CourseListForm";
            this.Load += new System.EventHandler(this.CourseListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourseStudent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCourseStudent;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label labelCourseName;
        internal System.Windows.Forms.Label labelCourseId;
        internal System.Windows.Forms.Label labelSemester;
    }
}