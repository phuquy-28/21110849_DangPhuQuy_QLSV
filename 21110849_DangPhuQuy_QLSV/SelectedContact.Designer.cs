namespace _21110849_DangPhuQuy_QLSV
{
    partial class SelectedContact
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
            this.dgvSelectedContact = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedContact)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSelectedContact
            // 
            this.dgvSelectedContact.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSelectedContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedContact.Location = new System.Drawing.Point(13, 13);
            this.dgvSelectedContact.Name = "dgvSelectedContact";
            this.dgvSelectedContact.Size = new System.Drawing.Size(454, 505);
            this.dgvSelectedContact.TabIndex = 0;
            this.dgvSelectedContact.DoubleClick += new System.EventHandler(this.dgvSelectedContact_DoubleClick);
            // 
            // SelectedContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 530);
            this.Controls.Add(this.dgvSelectedContact);
            this.Name = "SelectedContact";
            this.Text = "SelectedContact";
            this.Load += new System.EventHandler(this.SelectedContact_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedContact)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgvSelectedContact;
    }
}