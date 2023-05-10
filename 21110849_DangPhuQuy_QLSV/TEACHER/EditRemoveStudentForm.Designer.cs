namespace _21110849_DangPhuQuy_QLSV
{
    partial class EditRemoveStudentForm
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
            this.refreshBtn = new System.Windows.Forms.Button();
            this.findBtn = new System.Windows.Forms.Button();
            this.findTb = new System.Windows.Forms.TextBox();
            this.stdListDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.stdListDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // refreshBtn
            // 
            this.refreshBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.refreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.Location = new System.Drawing.Point(407, 503);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(85, 29);
            this.refreshBtn.TabIndex = 7;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = false;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // findBtn
            // 
            this.findBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.findBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findBtn.Location = new System.Drawing.Point(316, 503);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(85, 29);
            this.findBtn.TabIndex = 6;
            this.findBtn.Text = "Find";
            this.findBtn.UseVisualStyleBackColor = false;
            this.findBtn.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // findTb
            // 
            this.findTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findTb.Location = new System.Drawing.Point(12, 506);
            this.findTb.Name = "findTb";
            this.findTb.Size = new System.Drawing.Size(298, 22);
            this.findTb.TabIndex = 5;
            // 
            // stdListDGV
            // 
            this.stdListDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.stdListDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stdListDGV.Location = new System.Drawing.Point(12, 12);
            this.stdListDGV.Name = "stdListDGV";
            this.stdListDGV.Size = new System.Drawing.Size(959, 488);
            this.stdListDGV.TabIndex = 4;
            this.stdListDGV.DoubleClick += new System.EventHandler(this.stdListDGV_DoubleClick);
            // 
            // EditRemoveStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 543);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.findBtn);
            this.Controls.Add(this.findTb);
            this.Controls.Add(this.stdListDGV);
            this.Name = "EditRemoveStudentForm";
            this.Text = "EditRemoveStudentForm";
            this.Load += new System.EventHandler(this.EditRemoveStudentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stdListDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button findBtn;
        private System.Windows.Forms.TextBox findTb;
        private System.Windows.Forms.DataGridView stdListDGV;
    }
}