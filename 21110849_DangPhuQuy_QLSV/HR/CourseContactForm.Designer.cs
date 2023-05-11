namespace _21110849_DangPhuQuy_QLSV
{
    partial class CourseContactForm
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
            this.tbContactId = new System.Windows.Forms.TextBox();
            this.lbNameTitle = new System.Windows.Forms.Label();
            this.cbSem = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvCourseContact = new System.Windows.Forms.DataGridView();
            this.lbName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourseContact)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contact ID:";
            // 
            // tbContactId
            // 
            this.tbContactId.Location = new System.Drawing.Point(124, 26);
            this.tbContactId.Name = "tbContactId";
            this.tbContactId.Size = new System.Drawing.Size(100, 20);
            this.tbContactId.TabIndex = 1;
            // 
            // lbNameTitle
            // 
            this.lbNameTitle.AutoSize = true;
            this.lbNameTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameTitle.Location = new System.Drawing.Point(25, 55);
            this.lbNameTitle.Name = "lbNameTitle";
            this.lbNameTitle.Size = new System.Drawing.Size(57, 18);
            this.lbNameTitle.TabIndex = 2;
            this.lbNameTitle.Text = "Name:";
            // 
            // cbSem
            // 
            this.cbSem.FormattingEnabled = true;
            this.cbSem.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbSem.Location = new System.Drawing.Point(539, 23);
            this.cbSem.Name = "cbSem";
            this.cbSem.Size = new System.Drawing.Size(121, 21);
            this.cbSem.TabIndex = 4;
            this.cbSem.SelectedIndexChanged += new System.EventHandler(this.cbSem_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(440, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Semester:";
            // 
            // dgvCourseContact
            // 
            this.dgvCourseContact.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCourseContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourseContact.Location = new System.Drawing.Point(13, 86);
            this.dgvCourseContact.Name = "dgvCourseContact";
            this.dgvCourseContact.Size = new System.Drawing.Size(669, 352);
            this.dgvCourseContact.TabIndex = 6;
            this.dgvCourseContact.DoubleClick += new System.EventHandler(this.dgvCourseContact_DoubleClick);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(88, 55);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(45, 18);
            this.lbName.TabIndex = 7;
            this.lbName.Text = "name";
            // 
            // CourseContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 450);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.dgvCourseContact);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbSem);
            this.Controls.Add(this.lbNameTitle);
            this.Controls.Add(this.tbContactId);
            this.Controls.Add(this.label1);
            this.Name = "CourseContactForm";
            this.Text = "Course Contact Form";
            this.Load += new System.EventHandler(this.CourseContactForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourseContact)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvCourseContact;
        internal System.Windows.Forms.TextBox tbContactId;
        internal System.Windows.Forms.Label lbNameTitle;
        internal System.Windows.Forms.Label lbName;
    }
}