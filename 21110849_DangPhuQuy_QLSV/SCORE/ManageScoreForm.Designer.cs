namespace _21110849_DangPhuQuy_QLSV
{
    partial class ManageScoreForm
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
            this.dgvStdAndScore = new System.Windows.Forms.DataGridView();
            this.cbSelectedCourse = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.rtbDes = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbScore = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShowStd = new System.Windows.Forms.Button();
            this.btnShowScore = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAvgScore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStdAndScore)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStdAndScore
            // 
            this.dgvStdAndScore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStdAndScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStdAndScore.Location = new System.Drawing.Point(410, 69);
            this.dgvStdAndScore.Name = "dgvStdAndScore";
            this.dgvStdAndScore.Size = new System.Drawing.Size(486, 293);
            this.dgvStdAndScore.TabIndex = 31;
            this.dgvStdAndScore.Click += new System.EventHandler(this.dgvStdAndScore_Click);
            // 
            // cbSelectedCourse
            // 
            this.cbSelectedCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelectedCourse.FormattingEnabled = true;
            this.cbSelectedCourse.Location = new System.Drawing.Point(167, 107);
            this.cbSelectedCourse.Name = "cbSelectedCourse";
            this.cbSelectedCourse.Size = new System.Drawing.Size(213, 24);
            this.cbSelectedCourse.TabIndex = 30;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(89, 298);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(101, 36);
            this.btnAdd.TabIndex = 29;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // rtbDes
            // 
            this.rtbDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDes.Location = new System.Drawing.Point(166, 187);
            this.rtbDes.Name = "rtbDes";
            this.rtbDes.Size = new System.Drawing.Size(214, 96);
            this.rtbDes.TabIndex = 28;
            this.rtbDes.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Description:";
            // 
            // tbScore
            // 
            this.tbScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbScore.Location = new System.Drawing.Point(166, 147);
            this.tbScore.Name = "tbScore";
            this.tbScore.Size = new System.Drawing.Size(156, 22);
            this.tbScore.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(85, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Score:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Selected Course:";
            // 
            // tbId
            // 
            this.tbId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbId.Location = new System.Drawing.Point(166, 69);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(156, 22);
            this.tbId.TabIndex = 23;
            this.tbId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isDigit_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Student ID:";
            // 
            // btnShowStd
            // 
            this.btnShowStd.Location = new System.Drawing.Point(410, 40);
            this.btnShowStd.Name = "btnShowStd";
            this.btnShowStd.Size = new System.Drawing.Size(206, 23);
            this.btnShowStd.TabIndex = 32;
            this.btnShowStd.Text = "Show Student";
            this.btnShowStd.UseVisualStyleBackColor = true;
            this.btnShowStd.Click += new System.EventHandler(this.btnShowStd_Click);
            // 
            // btnShowScore
            // 
            this.btnShowScore.Location = new System.Drawing.Point(690, 40);
            this.btnShowScore.Name = "btnShowScore";
            this.btnShowScore.Size = new System.Drawing.Size(206, 23);
            this.btnShowScore.TabIndex = 33;
            this.btnShowScore.Text = "Show Score";
            this.btnShowScore.UseVisualStyleBackColor = true;
            this.btnShowScore.Click += new System.EventHandler(this.btnShowScore_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Crimson;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(235, 298);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(101, 36);
            this.btnRemove.TabIndex = 34;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAvgScore
            // 
            this.btnAvgScore.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAvgScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAvgScore.Location = new System.Drawing.Point(89, 340);
            this.btnAvgScore.Name = "btnAvgScore";
            this.btnAvgScore.Size = new System.Drawing.Size(247, 36);
            this.btnAvgScore.TabIndex = 35;
            this.btnAvgScore.Text = "Average Score by Course";
            this.btnAvgScore.UseVisualStyleBackColor = false;
            this.btnAvgScore.Click += new System.EventHandler(this.btnAvgScore_Click);
            // 
            // ManageScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 450);
            this.Controls.Add(this.btnAvgScore);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnShowScore);
            this.Controls.Add(this.btnShowStd);
            this.Controls.Add(this.dgvStdAndScore);
            this.Controls.Add(this.cbSelectedCourse);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.rtbDes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbScore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.label1);
            this.Name = "ManageScoreForm";
            this.Text = "ManageScoreForm";
            this.Load += new System.EventHandler(this.ManageScoreForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStdAndScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStdAndScore;
        private System.Windows.Forms.ComboBox cbSelectedCourse;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.RichTextBox rtbDes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbScore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShowStd;
        private System.Windows.Forms.Button btnShowScore;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAvgScore;
    }
}