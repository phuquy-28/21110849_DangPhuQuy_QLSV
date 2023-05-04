namespace _21110849_DangPhuQuy_QLSV
{
    partial class AccountListForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageStd = new System.Windows.Forms.TabPage();
            this.tabPageHr = new System.Windows.Forms.TabPage();
            this.dgvAccList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvHr = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageStd.SuspendLayout();
            this.tabPageHr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHr)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageStd);
            this.tabControl1.Controls.Add(this.tabPageHr);
            this.tabControl1.Location = new System.Drawing.Point(0, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(836, 383);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageStd
            // 
            this.tabPageStd.Controls.Add(this.dgvAccList);
            this.tabPageStd.Controls.Add(this.label1);
            this.tabPageStd.Location = new System.Drawing.Point(4, 22);
            this.tabPageStd.Name = "tabPageStd";
            this.tabPageStd.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStd.Size = new System.Drawing.Size(828, 357);
            this.tabPageStd.TabIndex = 0;
            this.tabPageStd.Text = "Student";
            this.tabPageStd.UseVisualStyleBackColor = true;
            // 
            // tabPageHr
            // 
            this.tabPageHr.Controls.Add(this.dgvHr);
            this.tabPageHr.Controls.Add(this.label2);
            this.tabPageHr.Location = new System.Drawing.Point(4, 22);
            this.tabPageHr.Name = "tabPageHr";
            this.tabPageHr.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHr.Size = new System.Drawing.Size(828, 357);
            this.tabPageHr.TabIndex = 1;
            this.tabPageHr.Text = "HR";
            this.tabPageHr.UseVisualStyleBackColor = true;
            // 
            // dgvAccList
            // 
            this.dgvAccList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAccList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccList.Location = new System.Drawing.Point(8, 36);
            this.dgvAccList.Name = "dgvAccList";
            this.dgvAccList.Size = new System.Drawing.Size(813, 311);
            this.dgvAccList.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(329, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Account List";
            // 
            // dgvHr
            // 
            this.dgvHr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHr.Location = new System.Drawing.Point(8, 41);
            this.dgvHr.Name = "dgvHr";
            this.dgvHr.Size = new System.Drawing.Size(813, 311);
            this.dgvHr.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(329, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Account List";
            // 
            // AccountListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 388);
            this.Controls.Add(this.tabControl1);
            this.Name = "AccountListForm";
            this.Text = "AccountListForm";
            this.Load += new System.EventHandler(this.AccountListForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageStd.ResumeLayout(false);
            this.tabPageStd.PerformLayout();
            this.tabPageHr.ResumeLayout(false);
            this.tabPageHr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageStd;
        private System.Windows.Forms.DataGridView dgvAccList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPageHr;
        private System.Windows.Forms.DataGridView dgvHr;
        private System.Windows.Forms.Label label2;
    }
}