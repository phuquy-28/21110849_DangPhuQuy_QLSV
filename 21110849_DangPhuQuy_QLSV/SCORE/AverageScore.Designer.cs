namespace _21110849_DangPhuQuy_QLSV
{
    partial class AverageScore
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvgScore)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAvgScore
            // 
            this.dgvAvgScore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAvgScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvgScore.Location = new System.Drawing.Point(13, 13);
            this.dgvAvgScore.Name = "dgvAvgScore";
            this.dgvAvgScore.Size = new System.Drawing.Size(335, 305);
            this.dgvAvgScore.TabIndex = 0;
            // 
            // AverageScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 330);
            this.Controls.Add(this.dgvAvgScore);
            this.Name = "AverageScore";
            this.Text = "AverageScore";
            this.Load += new System.EventHandler(this.AverageScore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvgScore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAvgScore;
    }
}