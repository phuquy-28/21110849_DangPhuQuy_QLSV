namespace _21110849_DangPhuQuy_QLSV
{
    partial class AverageScoreByCourse
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
            this.dgvAvgScore = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvgScore)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAvgScore
            // 
            this.dgvAvgScore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAvgScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvgScore.Location = new System.Drawing.Point(12, 51);
            this.dgvAvgScore.Name = "dgvAvgScore";
            this.dgvAvgScore.Size = new System.Drawing.Size(671, 305);
            this.dgvAvgScore.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(226, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Average Score By Course";
            // 
            // AverageScoreByCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 380);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAvgScore);
            this.Name = "AverageScoreByCourse";
            this.Text = "Average Score By Course";
            this.Load += new System.EventHandler(this.AverageScore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvgScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAvgScore;
        private System.Windows.Forms.Label label1;
    }
}