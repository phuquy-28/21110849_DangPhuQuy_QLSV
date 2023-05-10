namespace _21110849_DangPhuQuy_QLSV
{
    partial class StudentListForm
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
            this.stdListDGV = new System.Windows.Forms.DataGridView();
            this.findTb = new System.Windows.Forms.TextBox();
            this.findBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stdListDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // stdListDGV
            // 
            this.stdListDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.stdListDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stdListDGV.Location = new System.Drawing.Point(12, 12);
            this.stdListDGV.Name = "stdListDGV";
            this.stdListDGV.Size = new System.Drawing.Size(959, 488);
            this.stdListDGV.TabIndex = 0;
            this.stdListDGV.DoubleClick += new System.EventHandler(this.stdListDGV_DoubleClick);
            // 
            // findTb
            // 
            this.findTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findTb.Location = new System.Drawing.Point(13, 509);
            this.findTb.Name = "findTb";
            this.findTb.Size = new System.Drawing.Size(298, 22);
            this.findTb.TabIndex = 1;
            // 
            // findBtn
            // 
            this.findBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.findBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findBtn.Location = new System.Drawing.Point(317, 506);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(85, 29);
            this.findBtn.TabIndex = 2;
            this.findBtn.Text = "Find";
            this.findBtn.UseVisualStyleBackColor = false;
            this.findBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.refreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.Location = new System.Drawing.Point(408, 506);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(85, 29);
            this.refreshBtn.TabIndex = 3;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = false;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(886, 506);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(85, 29);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // StudentListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 547);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.findBtn);
            this.Controls.Add(this.findTb);
            this.Controls.Add(this.stdListDGV);
            this.Name = "StudentListForm";
            this.Text = "StudentListForm";
            this.Load += new System.EventHandler(this.StudentListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stdListDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView stdListDGV;
        private System.Windows.Forms.Button btnExport;
        internal System.Windows.Forms.TextBox findTb;
        internal System.Windows.Forms.Button findBtn;
        internal System.Windows.Forms.Button refreshBtn;
    }
}