namespace SEM
{
    partial class RegBoard
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
            this.components = new System.ComponentModel.Container();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.regClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new SEM.DataSet1();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblstID = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblID = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbPrivate = new System.Windows.Forms.ComboBox();
            this.cbRegular = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtIdentification = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBoardName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCenter = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSeatNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGRno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chkPrivate = new System.Windows.Forms.CheckBox();
            this.chkRegular = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.regClassTableAdapter = new SEM.DataSet1TableAdapters.RegClassTableAdapter();
            this.label15 = new System.Windows.Forms.Label();
            this.txtObtainMarks = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtGrade = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbPassFail = new System.Windows.Forms.ComboBox();
            this.chkExam = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.regClassBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbClass
            // 
            this.cbClass.DataSource = this.regClassBindingSource;
            this.cbClass.DisplayMember = "stClass";
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Location = new System.Drawing.Point(108, 131);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(202, 21);
            this.cbClass.TabIndex = 3;
            this.cbClass.ValueMember = "classID";
            // 
            // regClassBindingSource
            // 
            this.regClassBindingSource.DataMember = "RegClass";
            this.regClassBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(767, 70);
            this.label1.TabIndex = 0;
            this.label1.Text = "Information";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnNew);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnUpdate);
            this.flowLayoutPanel1.Controls.Add(this.btnSearch);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 70);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(208, 504);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(3, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(85, 51);
            this.btnNew.TabIndex = 15;
            this.btnNew.Text = "New [^N]";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(94, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 51);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save [^S]";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(3, 60);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(85, 51);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Update [^U]";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(94, 60);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 51);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "Search [^R]";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(208, 70);
            this.panel5.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 70);
            this.label2.TabIndex = 1;
            this.label2.Text = "Action";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(0, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(979, 100);
            this.label20.TabIndex = 1;
            this.label20.Text = "STUDENT BOARD REGISTRATION";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(767, 70);
            this.panel2.TabIndex = 0;
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(108, 155);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(202, 20);
            this.txtFName.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(108, 108);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(202, 20);
            this.txtName.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chkExam);
            this.panel4.Controls.Add(this.cbPassFail);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.txtObtainMarks);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.txtGrade);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.lblstID);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Controls.Add(this.lblID);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.txtYear);
            this.panel4.Controls.Add(this.txtIdentification);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.txtBoardName);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.txtCenter);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.txtSeatNo);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.txtGRno);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.chkPrivate);
            this.panel4.Controls.Add(this.chkRegular);
            this.panel4.Controls.Add(this.cbClass);
            this.panel4.Controls.Add(this.txtFName);
            this.panel4.Controls.Add(this.txtName);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 70);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(767, 434);
            this.panel4.TabIndex = 2;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // lblstID
            // 
            this.lblstID.AutoSize = true;
            this.lblstID.Location = new System.Drawing.Point(105, 67);
            this.lblstID.Name = "lblstID";
            this.lblstID.Size = new System.Drawing.Size(26, 13);
            this.lblstID.TabIndex = 77;
            this.lblstID.Text = "stID";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(27, 67);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 13);
            this.label16.TabIndex = 76;
            this.label16.Text = "Student ID";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 263);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(581, 150);
            this.dataGridView1.TabIndex = 75;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(105, 50);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 74;
            this.lblID.Text = "ID";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(27, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(18, 13);
            this.label14.TabIndex = 73;
            this.label14.Text = "ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbPrivate);
            this.groupBox1.Controls.Add(this.cbRegular);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(331, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 93);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Group";
            // 
            // cbPrivate
            // 
            this.cbPrivate.Enabled = false;
            this.cbPrivate.FormattingEnabled = true;
            this.cbPrivate.Items.AddRange(new object[] {
            "Humanities"});
            this.cbPrivate.Location = new System.Drawing.Point(97, 54);
            this.cbPrivate.Name = "cbPrivate";
            this.cbPrivate.Size = new System.Drawing.Size(179, 21);
            this.cbPrivate.TabIndex = 11;
            // 
            // cbRegular
            // 
            this.cbRegular.Enabled = false;
            this.cbRegular.FormattingEnabled = true;
            this.cbRegular.Items.AddRange(new object[] {
            "Science",
            "Arts (General)",
            "Computer Science",
            "Pre-Medical",
            "Pre-Engineering",
            "Commerce",
            "Statistics"});
            this.cbRegular.Location = new System.Drawing.Point(97, 24);
            this.cbRegular.Name = "cbRegular";
            this.cbRegular.Size = new System.Drawing.Size(179, 21);
            this.cbRegular.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(40, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 74;
            this.label13.Text = "Private";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(40, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 73;
            this.label12.Text = "Regular";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(444, 18);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(167, 20);
            this.txtYear.TabIndex = 8;
            // 
            // txtIdentification
            // 
            this.txtIdentification.Location = new System.Drawing.Point(141, 225);
            this.txtIdentification.Name = "txtIdentification";
            this.txtIdentification.Size = new System.Drawing.Size(169, 20);
            this.txtIdentification.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 228);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 13);
            this.label11.TabIndex = 69;
            this.label11.Text = "Mark of Identification";
            // 
            // txtBoardName
            // 
            this.txtBoardName.Location = new System.Drawing.Point(108, 178);
            this.txtBoardName.Name = "txtBoardName";
            this.txtBoardName.Size = new System.Drawing.Size(202, 20);
            this.txtBoardName.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 181);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 67;
            this.label10.Text = "Board Name";
            // 
            // txtCenter
            // 
            this.txtCenter.Location = new System.Drawing.Point(444, 40);
            this.txtCenter.Name = "txtCenter";
            this.txtCenter.Size = new System.Drawing.Size(167, 20);
            this.txtCenter.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(328, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 13);
            this.label8.TabIndex = 65;
            this.label8.Text = "Center of Examination";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(330, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 63;
            this.label7.Text = "Year";
            // 
            // txtSeatNo
            // 
            this.txtSeatNo.Location = new System.Drawing.Point(141, 201);
            this.txtSeatNo.Name = "txtSeatNo";
            this.txtSeatNo.Size = new System.Drawing.Size(169, 20);
            this.txtSeatNo.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 61;
            this.label6.Text = "Seat No.";
            // 
            // txtGRno
            // 
            this.txtGRno.Location = new System.Drawing.Point(108, 85);
            this.txtGRno.Name = "txtGRno";
            this.txtGRno.Size = new System.Drawing.Size(202, 20);
            this.txtGRno.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Roll / G.R No.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 58;
            this.label9.Text = "Class";
            // 
            // chkPrivate
            // 
            this.chkPrivate.AutoSize = true;
            this.chkPrivate.Location = new System.Drawing.Point(116, 17);
            this.chkPrivate.Name = "chkPrivate";
            this.chkPrivate.Size = new System.Drawing.Size(59, 17);
            this.chkPrivate.TabIndex = 57;
            this.chkPrivate.Text = "Private";
            this.chkPrivate.UseVisualStyleBackColor = true;
            this.chkPrivate.CheckedChanged += new System.EventHandler(this.chkPrivate_CheckedChanged);
            // 
            // chkRegular
            // 
            this.chkRegular.AutoSize = true;
            this.chkRegular.Location = new System.Drawing.Point(30, 18);
            this.chkRegular.Name = "chkRegular";
            this.chkRegular.Size = new System.Drawing.Size(63, 17);
            this.chkRegular.TabIndex = 56;
            this.chkRegular.Text = "Regular";
            this.chkRegular.UseVisualStyleBackColor = true;
            this.chkRegular.CheckedChanged += new System.EventHandler(this.chkRegular_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Father\'s Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Name";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 100);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Panel2.Controls.Add(this.panel5);
            this.splitContainer1.Size = new System.Drawing.Size(979, 574);
            this.splitContainer1.SplitterDistance = 767;
            this.splitContainer1.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 504);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(767, 70);
            this.panel3.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label20);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(979, 100);
            this.panel1.TabIndex = 4;
            // 
            // regClassTableAdapter
            // 
            this.regClassTableAdapter.ClearBeforeFill = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(328, 239);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 83;
            this.label15.Text = "Status";
            // 
            // txtObtainMarks
            // 
            this.txtObtainMarks.Enabled = false;
            this.txtObtainMarks.Location = new System.Drawing.Point(429, 189);
            this.txtObtainMarks.Name = "txtObtainMarks";
            this.txtObtainMarks.Size = new System.Drawing.Size(167, 20);
            this.txtObtainMarks.TabIndex = 12;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(328, 192);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 13);
            this.label17.TabIndex = 82;
            this.label17.Text = "Obtain Marks";
            // 
            // txtGrade
            // 
            this.txtGrade.Enabled = false;
            this.txtGrade.Location = new System.Drawing.Point(429, 212);
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.Size = new System.Drawing.Size(167, 20);
            this.txtGrade.TabIndex = 13;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(328, 217);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(36, 13);
            this.label18.TabIndex = 81;
            this.label18.Text = "Grade";
            // 
            // cbPassFail
            // 
            this.cbPassFail.Enabled = false;
            this.cbPassFail.FormattingEnabled = true;
            this.cbPassFail.Items.AddRange(new object[] {
            "Pass",
            "Fail"});
            this.cbPassFail.Location = new System.Drawing.Point(429, 238);
            this.cbPassFail.Name = "cbPassFail";
            this.cbPassFail.Size = new System.Drawing.Size(167, 21);
            this.cbPassFail.TabIndex = 14;
            // 
            // chkExam
            // 
            this.chkExam.AutoSize = true;
            this.chkExam.Location = new System.Drawing.Point(331, 172);
            this.chkExam.Name = "chkExam";
            this.chkExam.Size = new System.Drawing.Size(76, 17);
            this.chkExam.TabIndex = 84;
            this.chkExam.Text = "Exam Info.";
            this.chkExam.UseVisualStyleBackColor = true;
            this.chkExam.CheckedChanged += new System.EventHandler(this.chkExam_CheckedChanged);
            // 
            // RegBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 674);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "RegBoard";
            this.Text = "RegBoard";
            this.Load += new System.EventHandler(this.RegBoard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.regClassBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkPrivate;
        private System.Windows.Forms.CheckBox chkRegular;
        private System.Windows.Forms.TextBox txtGRno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSeatNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdentification;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBoardName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCenter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbPrivate;
        private System.Windows.Forms.ComboBox cbRegular;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSearch;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource regClassBindingSource;
        private DataSet1TableAdapters.RegClassTableAdapter regClassTableAdapter;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblstID;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtObtainMarks;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtGrade;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbPassFail;
        private System.Windows.Forms.CheckBox chkExam;
    }
}