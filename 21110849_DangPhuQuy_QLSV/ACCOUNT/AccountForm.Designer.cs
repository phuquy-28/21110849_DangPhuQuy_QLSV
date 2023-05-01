namespace _21110849_DangPhuQuy_QLSV
{
    partial class AccountForm
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
            this.tabtablePending = new System.Windows.Forms.TabControl();
            this.tabStudent = new System.Windows.Forms.TabPage();
            this.tabHr = new System.Windows.Forms.TabPage();
            this.btnStdDel = new System.Windows.Forms.Button();
            this.btnStdAccAll = new System.Windows.Forms.Button();
            this.btnStdAccept = new System.Windows.Forms.Button();
            this.dgvStudent = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHrDelete = new System.Windows.Forms.Button();
            this.btnHrAccAll = new System.Windows.Forms.Button();
            this.btnHrAcpt = new System.Windows.Forms.Button();
            this.dgvHr = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.tabtablePending.SuspendLayout();
            this.tabStudent.SuspendLayout();
            this.tabHr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHr)).BeginInit();
            this.SuspendLayout();
            // 
            // tabtablePending
            // 
            this.tabtablePending.Controls.Add(this.tabStudent);
            this.tabtablePending.Controls.Add(this.tabHr);
            this.tabtablePending.Location = new System.Drawing.Point(1, 1);
            this.tabtablePending.Name = "tabtablePending";
            this.tabtablePending.SelectedIndex = 0;
            this.tabtablePending.Size = new System.Drawing.Size(797, 447);
            this.tabtablePending.TabIndex = 6;
            // 
            // tabStudent
            // 
            this.tabStudent.Controls.Add(this.btnStdDel);
            this.tabStudent.Controls.Add(this.btnStdAccAll);
            this.tabStudent.Controls.Add(this.btnStdAccept);
            this.tabStudent.Controls.Add(this.dgvStudent);
            this.tabStudent.Controls.Add(this.label1);
            this.tabStudent.Location = new System.Drawing.Point(4, 22);
            this.tabStudent.Name = "tabStudent";
            this.tabStudent.Padding = new System.Windows.Forms.Padding(3);
            this.tabStudent.Size = new System.Drawing.Size(789, 421);
            this.tabStudent.TabIndex = 0;
            this.tabStudent.Text = "Student";
            this.tabStudent.UseVisualStyleBackColor = true;
            // 
            // tabHr
            // 
            this.tabHr.Controls.Add(this.btnHrDelete);
            this.tabHr.Controls.Add(this.btnHrAccAll);
            this.tabHr.Controls.Add(this.btnHrAcpt);
            this.tabHr.Controls.Add(this.dgvHr);
            this.tabHr.Controls.Add(this.label2);
            this.tabHr.Location = new System.Drawing.Point(4, 22);
            this.tabHr.Name = "tabHr";
            this.tabHr.Padding = new System.Windows.Forms.Padding(3);
            this.tabHr.Size = new System.Drawing.Size(789, 421);
            this.tabHr.TabIndex = 1;
            this.tabHr.Text = "Human Resource";
            this.tabHr.UseVisualStyleBackColor = true;
            // 
            // btnStdDel
            // 
            this.btnStdDel.BackColor = System.Drawing.Color.Red;
            this.btnStdDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStdDel.Location = new System.Drawing.Point(112, 371);
            this.btnStdDel.Name = "btnStdDel";
            this.btnStdDel.Size = new System.Drawing.Size(84, 37);
            this.btnStdDel.TabIndex = 9;
            this.btnStdDel.Text = "Delete";
            this.btnStdDel.UseVisualStyleBackColor = false;
            // 
            // btnStdAccAll
            // 
            this.btnStdAccAll.BackColor = System.Drawing.Color.ForestGreen;
            this.btnStdAccAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStdAccAll.Location = new System.Drawing.Point(650, 371);
            this.btnStdAccAll.Name = "btnStdAccAll";
            this.btnStdAccAll.Size = new System.Drawing.Size(120, 37);
            this.btnStdAccAll.TabIndex = 8;
            this.btnStdAccAll.Text = "Accept All";
            this.btnStdAccAll.UseVisualStyleBackColor = false;
            // 
            // btnStdAccept
            // 
            this.btnStdAccept.BackColor = System.Drawing.Color.LimeGreen;
            this.btnStdAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStdAccept.Location = new System.Drawing.Point(22, 371);
            this.btnStdAccept.Name = "btnStdAccept";
            this.btnStdAccept.Size = new System.Drawing.Size(84, 37);
            this.btnStdAccept.TabIndex = 7;
            this.btnStdAccept.Text = "Accept";
            this.btnStdAccept.UseVisualStyleBackColor = false;
            // 
            // dgvStudent
            // 
            this.dgvStudent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudent.Location = new System.Drawing.Point(22, 47);
            this.dgvStudent.Name = "dgvStudent";
            this.dgvStudent.Size = new System.Drawing.Size(747, 308);
            this.dgvStudent.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(308, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pending Account";
            // 
            // btnHrDelete
            // 
            this.btnHrDelete.BackColor = System.Drawing.Color.Red;
            this.btnHrDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHrDelete.Location = new System.Drawing.Point(112, 367);
            this.btnHrDelete.Name = "btnHrDelete";
            this.btnHrDelete.Size = new System.Drawing.Size(84, 37);
            this.btnHrDelete.TabIndex = 14;
            this.btnHrDelete.Text = "Delete";
            this.btnHrDelete.UseVisualStyleBackColor = false;
            // 
            // btnHrAccAll
            // 
            this.btnHrAccAll.BackColor = System.Drawing.Color.ForestGreen;
            this.btnHrAccAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHrAccAll.Location = new System.Drawing.Point(650, 367);
            this.btnHrAccAll.Name = "btnHrAccAll";
            this.btnHrAccAll.Size = new System.Drawing.Size(120, 37);
            this.btnHrAccAll.TabIndex = 13;
            this.btnHrAccAll.Text = "Accept All";
            this.btnHrAccAll.UseVisualStyleBackColor = false;
            // 
            // btnHrAcpt
            // 
            this.btnHrAcpt.BackColor = System.Drawing.Color.LimeGreen;
            this.btnHrAcpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHrAcpt.Location = new System.Drawing.Point(22, 367);
            this.btnHrAcpt.Name = "btnHrAcpt";
            this.btnHrAcpt.Size = new System.Drawing.Size(84, 37);
            this.btnHrAcpt.TabIndex = 12;
            this.btnHrAcpt.Text = "Accept";
            this.btnHrAcpt.UseVisualStyleBackColor = false;
            // 
            // dgvHr
            // 
            this.dgvHr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHr.Location = new System.Drawing.Point(22, 43);
            this.dgvHr.Name = "dgvHr";
            this.dgvHr.Size = new System.Drawing.Size(747, 308);
            this.dgvHr.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(308, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Pending Account";
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabtablePending);
            this.Name = "AccountForm";
            this.Text = "AccountForm";
            this.Load += new System.EventHandler(this.AccountForm_Load);
            this.tabtablePending.ResumeLayout(false);
            this.tabStudent.ResumeLayout(false);
            this.tabStudent.PerformLayout();
            this.tabHr.ResumeLayout(false);
            this.tabHr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabtablePending;
        private System.Windows.Forms.TabPage tabStudent;
        private System.Windows.Forms.TabPage tabHr;
        private System.Windows.Forms.Button btnStdDel;
        private System.Windows.Forms.Button btnStdAccAll;
        private System.Windows.Forms.Button btnStdAccept;
        private System.Windows.Forms.DataGridView dgvStudent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHrDelete;
        private System.Windows.Forms.Button btnHrAccAll;
        private System.Windows.Forms.Button btnHrAcpt;
        private System.Windows.Forms.DataGridView dgvHr;
        private System.Windows.Forms.Label label2;
    }
}