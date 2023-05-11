namespace _21110849_DangPhuQuy_QLSV
{
    partial class ManageStudentForm
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
            this.label15 = new System.Windows.Forms.Label();
            this.nationalityTb = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.stdPicPB = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.stateCb = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pobTb = new System.Windows.Forms.TextBox();
            this.majorCb = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.facultyCb = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.addressTB = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.emailTb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.phoneTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maleRBtn = new System.Windows.Forms.RadioButton();
            this.femaleRBtn = new System.Windows.Forms.RadioButton();
            this.dobDTP = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lNameTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fNameTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.idTB = new System.Windows.Forms.TextBox();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.btnDowload = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.findTb = new System.Windows.Forms.TextBox();
            this.findBtn = new System.Windows.Forms.Button();
            this.stdListDgv = new System.Windows.Forms.DataGridView();
            this.lbTotalStd = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.stdPicPB)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stdListDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(250, 79);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(85, 16);
            this.label15.TabIndex = 97;
            this.label15.Text = "Nationality:";
            // 
            // nationalityTb
            // 
            this.nationalityTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nationalityTb.Location = new System.Drawing.Point(352, 76);
            this.nationalityTb.Name = "nationalityTb";
            this.nationalityTb.Size = new System.Drawing.Size(119, 22);
            this.nationalityTb.TabIndex = 96;
            this.nationalityTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nationalityTb_KeyPress);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(53, 438);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 32);
            this.btnAdd.TabIndex = 95;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // stdPicPB
            // 
            this.stdPicPB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.stdPicPB.Location = new System.Drawing.Point(315, 136);
            this.stdPicPB.Name = "stdPicPB";
            this.stdPicPB.Size = new System.Drawing.Size(156, 134);
            this.stdPicPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.stdPicPB.TabIndex = 93;
            this.stdPicPB.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(250, 136);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 16);
            this.label14.TabIndex = 92;
            this.label14.Text = "Picture:";
            // 
            // stateCb
            // 
            this.stateCb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.stateCb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.stateCb.FormattingEnabled = true;
            this.stateCb.Items.AddRange(new object[] {
            "Còn học",
            "Đã tốt nghiệp",
            "Bảo lưu",
            "Trễ hạn"});
            this.stateCb.Location = new System.Drawing.Point(352, 104);
            this.stateCb.Name = "stateCb";
            this.stateCb.Size = new System.Drawing.Size(119, 21);
            this.stateCb.TabIndex = 91;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(250, 105);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 16);
            this.label13.TabIndex = 90;
            this.label13.Text = "State:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(250, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 16);
            this.label12.TabIndex = 89;
            this.label12.Text = "Place of birth:";
            // 
            // pobTb
            // 
            this.pobTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pobTb.Location = new System.Drawing.Point(352, 47);
            this.pobTb.Name = "pobTb";
            this.pobTb.Size = new System.Drawing.Size(119, 22);
            this.pobTb.TabIndex = 88;
            this.pobTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pobTb_KeyPress);
            // 
            // majorCb
            // 
            this.majorCb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.majorCb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.majorCb.FormattingEnabled = true;
            this.majorCb.Items.AddRange(new object[] {
            "Công nghệ Kỹ thuật điện, điện tử (AUN-QA)",
            "Công nghệ chế tạo máy",
            "Công nghệ Kỹ thuật cơ điện tử (AUN-QA)",
            "Công nghệ Kỹ thuật công trình Xây dựng (AUN-QA)",
            "Công nghệ Kỹ thuật ô tô (AUN-QA)",
            "Công nghệ Kỹ thuật cơ khí (AUN-QA)",
            "Công nghệ Kỹ thuật nhiệt (AUN-QA)",
            "Quản lý công nghiệp (AUN-QA)",
            "Công nghệ Kỹ thuật Điều khiển và Tự động hóa (AUN-QA)",
            "Công nghệ May (AUN-QA)",
            "Công nghệ Kỹ thuật Điện tử, Truyền thông",
            "Kỹ thuật Xây dựng công trình Giao thông",
            "Công nghệ Kỹ thuật Máy tính",
            "Công nghệ Thông tin",
            "Công nghệ In",
            "Kế toán",
            "Thương mại điện tử",
            "Kỹ thuật Công nghiệp",
            "Kỹ thuật Y sinh (Điện tử Y sinh)",
            "Công nghệ vật liệu",
            "Logistics và quản lý chuỗi cung ứng",
            "Công nghệ Kỹ thuật môi trường",
            "Công nghệ thực phẩm",
            "Công nghệ Kỹ thuật Hóa học",
            "Kinh tế gia đình",
            "Sư phạm tiếng Anh",
            "Ngôn ngữ Anh",
            "Kinh doanh quốc tế",
            "Quản lý xây dựng",
            "Năng lượng tái tạo",
            "Chế biên lâm sản",
            "Kỹ thuật dữ liệu",
            "Robot và trí tuệ nhân tạo"});
            this.majorCb.Location = new System.Drawing.Point(125, 386);
            this.majorCb.Name = "majorCb";
            this.majorCb.Size = new System.Drawing.Size(247, 21);
            this.majorCb.TabIndex = 87;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(23, 386);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 16);
            this.label11.TabIndex = 86;
            this.label11.Text = "Major:";
            // 
            // facultyCb
            // 
            this.facultyCb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.facultyCb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.facultyCb.FormattingEnabled = true;
            this.facultyCb.Items.AddRange(new object[] {
            "Khoa Lý luận Chính trị",
            "Khoa Khoa học ứng dụng",
            "Khoa Cơ khí Chế tạo máy",
            "Khoa Điện - Điện tử",
            "Khoa Cơ khí Động Lực",
            "Khoa Kinh tế",
            "Khoa Công nghệ thông tin",
            "Khoa In và Truyền thông",
            "Khoa Công nghệ May và Thời Trang",
            "Khoa Công nghệ Hóa học và Thực phẩm",
            "Khoa Xây dựng",
            "Khoa Ngoại ngữ",
            "Khoa Đào tạo Chất lượng cao"});
            this.facultyCb.Location = new System.Drawing.Point(125, 356);
            this.facultyCb.Name = "facultyCb";
            this.facultyCb.Size = new System.Drawing.Size(247, 21);
            this.facultyCb.TabIndex = 85;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(23, 357);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 16);
            this.label10.TabIndex = 84;
            this.label10.Text = "Faculty:";
            // 
            // addressTB
            // 
            this.addressTB.Location = new System.Drawing.Point(125, 254);
            this.addressTB.Name = "addressTB";
            this.addressTB.Size = new System.Drawing.Size(174, 96);
            this.addressTB.TabIndex = 83;
            this.addressTB.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 254);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 16);
            this.label9.TabIndex = 82;
            this.label9.Text = "Address:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 81;
            this.label8.Text = "Email:";
            // 
            // emailTb
            // 
            this.emailTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTb.Location = new System.Drawing.Point(125, 223);
            this.emailTb.Name = "emailTb";
            this.emailTb.Size = new System.Drawing.Size(174, 22);
            this.emailTb.TabIndex = 80;
            this.emailTb.Validating += new System.ComponentModel.CancelEventHandler(this.emailTb_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 16);
            this.label7.TabIndex = 79;
            this.label7.Text = "Phone:";
            // 
            // phoneTB
            // 
            this.phoneTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneTB.Location = new System.Drawing.Point(125, 195);
            this.phoneTB.Name = "phoneTB";
            this.phoneTB.Size = new System.Drawing.Size(174, 22);
            this.phoneTB.TabIndex = 78;
            this.phoneTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phoneTB_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 77;
            this.label6.Text = "Gender:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maleRBtn);
            this.groupBox1.Controls.Add(this.femaleRBtn);
            this.groupBox1.Location = new System.Drawing.Point(125, 157);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 32);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            // 
            // maleRBtn
            // 
            this.maleRBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.maleRBtn.AutoSize = true;
            this.maleRBtn.Checked = true;
            this.maleRBtn.Location = new System.Drawing.Point(67, 10);
            this.maleRBtn.Name = "maleRBtn";
            this.maleRBtn.Size = new System.Drawing.Size(48, 17);
            this.maleRBtn.TabIndex = 1;
            this.maleRBtn.TabStop = true;
            this.maleRBtn.Text = "Male";
            this.maleRBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.maleRBtn.UseVisualStyleBackColor = true;
            // 
            // femaleRBtn
            // 
            this.femaleRBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.femaleRBtn.AutoSize = true;
            this.femaleRBtn.Location = new System.Drawing.Point(2, 10);
            this.femaleRBtn.Name = "femaleRBtn";
            this.femaleRBtn.Size = new System.Drawing.Size(59, 17);
            this.femaleRBtn.TabIndex = 0;
            this.femaleRBtn.Text = "Female";
            this.femaleRBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.femaleRBtn.UseVisualStyleBackColor = true;
            // 
            // dobDTP
            // 
            this.dobDTP.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dobDTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dobDTP.Location = new System.Drawing.Point(125, 131);
            this.dobDTP.Name = "dobDTP";
            this.dobDTP.Size = new System.Drawing.Size(111, 20);
            this.dobDTP.TabIndex = 75;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 74;
            this.label5.Text = "BirthDate:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 73;
            this.label4.Text = "Last name:";
            // 
            // lNameTB
            // 
            this.lNameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNameTB.Location = new System.Drawing.Point(125, 103);
            this.lNameTB.Name = "lNameTB";
            this.lNameTB.Size = new System.Drawing.Size(111, 22);
            this.lNameTB.TabIndex = 72;
            this.lNameTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lNameTB_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 71;
            this.label3.Text = "First name:";
            // 
            // fNameTB
            // 
            this.fNameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fNameTB.Location = new System.Drawing.Point(125, 75);
            this.fNameTB.Name = "fNameTB";
            this.fNameTB.Size = new System.Drawing.Size(111, 22);
            this.fNameTB.TabIndex = 70;
            this.fNameTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fNameTB_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 69;
            this.label1.Text = "Student ID:";
            // 
            // idTB
            // 
            this.idTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idTB.Location = new System.Drawing.Point(125, 47);
            this.idTB.Name = "idTB";
            this.idTB.Size = new System.Drawing.Size(111, 22);
            this.idTB.TabIndex = 68;
            this.idTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.idTB_KeyPress);
            // 
            // uploadBtn
            // 
            this.uploadBtn.Location = new System.Drawing.Point(315, 277);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(75, 23);
            this.uploadBtn.TabIndex = 98;
            this.uploadBtn.Text = "Upload";
            this.uploadBtn.UseVisualStyleBackColor = true;
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            // 
            // btnDowload
            // 
            this.btnDowload.Location = new System.Drawing.Point(396, 277);
            this.btnDowload.Name = "btnDowload";
            this.btnDowload.Size = new System.Drawing.Size(75, 23);
            this.btnDowload.TabIndex = 99;
            this.btnDowload.Text = "Dowload";
            this.btnDowload.UseVisualStyleBackColor = true;
            this.btnDowload.Click += new System.EventHandler(this.btnDowload_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(154, 438);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(93, 32);
            this.btnEdit.TabIndex = 100;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Crimson;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(253, 438);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(99, 32);
            this.btnRemove.TabIndex = 101;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.SkyBlue;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(358, 438);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(93, 32);
            this.btnReset.TabIndex = 102;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(817, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 16);
            this.label2.TabIndex = 103;
            this.label2.Text = "Search for firstname and lastname:";
            // 
            // findTb
            // 
            this.findTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findTb.Location = new System.Drawing.Point(1069, 15);
            this.findTb.Name = "findTb";
            this.findTb.Size = new System.Drawing.Size(135, 22);
            this.findTb.TabIndex = 104;
            // 
            // findBtn
            // 
            this.findBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.findBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findBtn.Location = new System.Drawing.Point(1210, 15);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(79, 26);
            this.findBtn.TabIndex = 105;
            this.findBtn.Text = "Find";
            this.findBtn.UseVisualStyleBackColor = false;
            this.findBtn.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // stdListDgv
            // 
            this.stdListDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stdListDgv.Location = new System.Drawing.Point(477, 47);
            this.stdListDgv.Name = "stdListDgv";
            this.stdListDgv.Size = new System.Drawing.Size(812, 423);
            this.stdListDgv.TabIndex = 106;
            this.stdListDgv.DoubleClick += new System.EventHandler(this.stdListDgv_DoubleClick);
            // 
            // lbTotalStd
            // 
            this.lbTotalStd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbTotalStd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalStd.ForeColor = System.Drawing.Color.Goldenrod;
            this.lbTotalStd.Location = new System.Drawing.Point(1126, 484);
            this.lbTotalStd.Name = "lbTotalStd";
            this.lbTotalStd.Size = new System.Drawing.Size(163, 31);
            this.lbTotalStd.TabIndex = 107;
            this.lbTotalStd.Text = "label16";
            this.lbTotalStd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ManageStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 524);
            this.Controls.Add(this.lbTotalStd);
            this.Controls.Add(this.stdListDgv);
            this.Controls.Add(this.findBtn);
            this.Controls.Add(this.findTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDowload);
            this.Controls.Add(this.uploadBtn);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.nationalityTb);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.stdPicPB);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.stateCb);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.pobTb);
            this.Controls.Add(this.majorCb);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.facultyCb);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.addressTB);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.emailTb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.phoneTB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dobDTP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lNameTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fNameTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.idTB);
            this.Name = "ManageStudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Student Form";
            this.Load += new System.EventHandler(this.ManageStudentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stdPicPB)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stdListDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.TextBox nationalityTb;
        private System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.PictureBox stdPicPB;
        private System.Windows.Forms.Label label14;
        internal System.Windows.Forms.ComboBox stateCb;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.TextBox pobTb;
        internal System.Windows.Forms.ComboBox majorCb;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.ComboBox facultyCb;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.RichTextBox addressTB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox emailTb;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox phoneTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.RadioButton maleRBtn;
        internal System.Windows.Forms.RadioButton femaleRBtn;
        internal System.Windows.Forms.DateTimePicker dobDTP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox lNameTB;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox fNameTB;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox idTB;
        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.Button btnDowload;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox findTb;
        private System.Windows.Forms.Button findBtn;
        private System.Windows.Forms.DataGridView stdListDgv;
        private System.Windows.Forms.Label lbTotalStd;
    }
}