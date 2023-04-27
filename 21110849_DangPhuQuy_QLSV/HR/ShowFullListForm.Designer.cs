namespace _21110849_DangPhuQuy_QLSV
{
    partial class ShowFullListForm
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
            this.dgvContactList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lisboxGroup = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbShowAll = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvContactList
            // 
            this.dgvContactList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContactList.Location = new System.Drawing.Point(215, 74);
            this.dgvContactList.Name = "dgvContactList";
            this.dgvContactList.Size = new System.Drawing.Size(739, 424);
            this.dgvContactList.TabIndex = 0;
            this.dgvContactList.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvContactList_ColumnHeaderMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Goudy Stout", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(304, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Contact List";
            // 
            // lisboxGroup
            // 
            this.lisboxGroup.FormattingEnabled = true;
            this.lisboxGroup.Location = new System.Drawing.Point(12, 74);
            this.lisboxGroup.Name = "lisboxGroup";
            this.lisboxGroup.Size = new System.Drawing.Size(193, 290);
            this.lisboxGroup.TabIndex = 2;
            this.lisboxGroup.Click += new System.EventHandler(this.lisboxGroup_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Group";
            // 
            // lbShowAll
            // 
            this.lbShowAll.AutoSize = true;
            this.lbShowAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbShowAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbShowAll.Location = new System.Drawing.Point(212, 53);
            this.lbShowAll.Name = "lbShowAll";
            this.lbShowAll.Size = new System.Drawing.Size(72, 18);
            this.lbShowAll.TabIndex = 4;
            this.lbShowAll.Text = "Show all";
            this.lbShowAll.Click += new System.EventHandler(this.lbShowAll_Click);
            // 
            // ShowFullListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 510);
            this.Controls.Add(this.lbShowAll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lisboxGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvContactList);
            this.Name = "ShowFullListForm";
            this.Text = "SelectContactForm";
            this.Load += new System.EventHandler(this.ShowFullListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvContactList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lisboxGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbShowAll;
    }
}