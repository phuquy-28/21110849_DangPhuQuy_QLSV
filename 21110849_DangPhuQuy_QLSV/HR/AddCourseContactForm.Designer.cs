namespace _21110849_DangPhuQuy_QLSV
{
    partial class AddCourseContactForm
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
            this.cbSemester = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbTotalCourse = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lisbSelected = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lisbAvail = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbContactId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbSemester
            // 
            this.cbSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSemester.FormattingEnabled = true;
            this.cbSemester.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbSemester.Location = new System.Drawing.Point(435, 32);
            this.cbSemester.Name = "cbSemester";
            this.cbSemester.Size = new System.Drawing.Size(121, 28);
            this.cbSemester.TabIndex = 22;
            this.cbSemester.SelectedIndexChanged += new System.EventHandler(this.cbSemester_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(328, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 24);
            this.label4.TabIndex = 21;
            this.label4.Text = "Semester:";
            // 
            // lbTotalCourse
            // 
            this.lbTotalCourse.AutoSize = true;
            this.lbTotalCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalCourse.Location = new System.Drawing.Point(41, 282);
            this.lbTotalCourse.Name = "lbTotalCourse";
            this.lbTotalCourse.Size = new System.Drawing.Size(57, 20);
            this.lbTotalCourse.TabIndex = 20;
            this.lbTotalCourse.Text = "label4";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(250, 157);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 36);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(250, 115);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(77, 36);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lisbSelected
            // 
            this.lisbSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisbSelected.FormattingEnabled = true;
            this.lisbSelected.ItemHeight = 16;
            this.lisbSelected.Location = new System.Drawing.Point(358, 115);
            this.lisbSelected.Name = "lisbSelected";
            this.lisbSelected.Size = new System.Drawing.Size(179, 148);
            this.lisbSelected.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(354, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 24);
            this.label3.TabIndex = 16;
            this.label3.Text = "Selected Course";
            // 
            // lisbAvail
            // 
            this.lisbAvail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisbAvail.FormattingEnabled = true;
            this.lisbAvail.ItemHeight = 16;
            this.lisbAvail.Location = new System.Drawing.Point(41, 115);
            this.lisbAvail.Name = "lisbAvail";
            this.lisbAvail.Size = new System.Drawing.Size(179, 148);
            this.lisbAvail.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "Available Course";
            // 
            // tbContactId
            // 
            this.tbContactId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbContactId.Location = new System.Drawing.Point(153, 34);
            this.tbContactId.Name = "tbContactId";
            this.tbContactId.Size = new System.Drawing.Size(122, 26);
            this.tbContactId.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "Contact ID:";
            // 
            // AddCourseContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 324);
            this.Controls.Add(this.cbSemester);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbTotalCourse);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lisbSelected);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lisbAvail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbContactId);
            this.Controls.Add(this.label1);
            this.Name = "AddCourseContactForm";
            this.Text = "AddCourseContactForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSemester;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbTotalCourse;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lisbSelected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lisbAvail;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox tbContactId;
        private System.Windows.Forms.Label label1;
    }
}