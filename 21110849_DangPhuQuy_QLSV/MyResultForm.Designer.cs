namespace _21110849_DangPhuQuy_QLSV
{
    partial class MyResultForm
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
            this.cbSem = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvMyResult = new System.Windows.Forms.DataGridView();
            this.labelName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyResult)).BeginInit();
            this.SuspendLayout();
            // 
            // cbSem
            // 
            this.cbSem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSem.FormattingEnabled = true;
            this.cbSem.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbSem.Location = new System.Drawing.Point(525, 49);
            this.cbSem.Name = "cbSem";
            this.cbSem.Size = new System.Drawing.Size(121, 21);
            this.cbSem.TabIndex = 25;
            this.cbSem.SelectedIndexChanged += new System.EventHandler(this.cbSem_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(431, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Semester:";
            // 
            // dgvMyResult
            // 
            this.dgvMyResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMyResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyResult.Location = new System.Drawing.Point(12, 94);
            this.dgvMyResult.Name = "dgvMyResult";
            this.dgvMyResult.Size = new System.Drawing.Size(634, 240);
            this.dgvMyResult.TabIndex = 23;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(88, 70);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(27, 20);
            this.labelName.TabIndex = 22;
            this.labelName.Text = "Id:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Name:";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelId.Location = new System.Drawing.Point(88, 50);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(27, 20);
            this.labelId.TabIndex = 20;
            this.labelId.Text = "Id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Id:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(223, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 31);
            this.label1.TabIndex = 18;
            this.label1.Text = "My Result";
            // 
            // MyResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 349);
            this.Controls.Add(this.cbSem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvMyResult);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MyResultForm";
            this.Text = "My Result Form";
            this.Load += new System.EventHandler(this.MyResultForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvMyResult;
        internal System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}