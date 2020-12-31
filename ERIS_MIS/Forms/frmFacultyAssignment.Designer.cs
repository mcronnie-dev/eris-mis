namespace ERIS_MIS.Forms
{
    partial class frmFacultyAssignment
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
            this.label8 = new System.Windows.Forms.Label();
            this.grLvlComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.assignToSubjectButton = new System.Windows.Forms.Button();
            this.grLvlAssignedLabel = new System.Windows.Forms.Label();
            this.assignToGradeLevelButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.subjectAssignedLabel = new System.Windows.Forms.Label();
            this.subjComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grLvlSummaryDgv = new System.Windows.Forms.DataGridView();
            this.summaryLabel = new System.Windows.Forms.Label();
            this.subjectAssignedDgv = new System.Windows.Forms.DataGridView();
            this.grLvlAssignedDgv = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.removeFromListButton = new System.Windows.Forms.Button();
            this.grLvlMaxAllowedTotalLabel = new System.Windows.Forms.Label();
            this.grLvlAssignedTotalLabel = new System.Windows.Forms.Label();
            this.unassignedDgv = new System.Windows.Forms.DataGridView();
            this.teachersTotalLabel = new System.Windows.Forms.Label();
            this.unassignedTotalLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.removeFromSubjAssignedListButton = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.coladd = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.addcol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grLvlSummaryDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectAssignedDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grLvlAssignedDgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unassignedDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoEllipsis = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(157)))));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(98)))));
            this.label8.Location = new System.Drawing.Point(14, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(264, 41);
            this.label8.TabIndex = 85;
            this.label8.Text = "Subject Assignment";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grLvlComboBox
            // 
            this.grLvlComboBox.FormattingEnabled = true;
            this.grLvlComboBox.Location = new System.Drawing.Point(236, 436);
            this.grLvlComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grLvlComboBox.Name = "grLvlComboBox";
            this.grLvlComboBox.Size = new System.Drawing.Size(235, 24);
            this.grLvlComboBox.TabIndex = 91;
            this.grLvlComboBox.SelectedIndexChanged += new System.EventHandler(this.grLvlComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(157)))));
            this.label1.Location = new System.Drawing.Point(239, 408);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 26);
            this.label1.TabIndex = 90;
            this.label1.Text = "ASSIGN TO GRADE LEVEL:";
            // 
            // assignToSubjectButton
            // 
            this.assignToSubjectButton.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.assignToSubjectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assignToSubjectButton.Location = new System.Drawing.Point(1108, 420);
            this.assignToSubjectButton.Margin = new System.Windows.Forms.Padding(4);
            this.assignToSubjectButton.Name = "assignToSubjectButton";
            this.assignToSubjectButton.Size = new System.Drawing.Size(117, 39);
            this.assignToSubjectButton.TabIndex = 241;
            this.assignToSubjectButton.Text = "Add";
            this.assignToSubjectButton.UseVisualStyleBackColor = true;
            this.assignToSubjectButton.Click += new System.EventHandler(this.addToDepartmentButton_Click);
            // 
            // grLvlAssignedLabel
            // 
            this.grLvlAssignedLabel.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grLvlAssignedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(157)))));
            this.grLvlAssignedLabel.Location = new System.Drawing.Point(648, 55);
            this.grLvlAssignedLabel.Name = "grLvlAssignedLabel";
            this.grLvlAssignedLabel.Size = new System.Drawing.Size(283, 33);
            this.grLvlAssignedLabel.TabIndex = 242;
            this.grLvlAssignedLabel.Text = "GRADE <SELECTED>:";
            // 
            // assignToGradeLevelButton
            // 
            this.assignToGradeLevelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assignToGradeLevelButton.Location = new System.Drawing.Point(478, 420);
            this.assignToGradeLevelButton.Margin = new System.Windows.Forms.Padding(4);
            this.assignToGradeLevelButton.Name = "assignToGradeLevelButton";
            this.assignToGradeLevelButton.Size = new System.Drawing.Size(117, 39);
            this.assignToGradeLevelButton.TabIndex = 241;
            this.assignToGradeLevelButton.Text = "Add";
            this.assignToGradeLevelButton.UseVisualStyleBackColor = true;
            this.assignToGradeLevelButton.Click += new System.EventHandler(this.addToGradeLevelButton_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(157)))));
            this.label2.Location = new System.Drawing.Point(10, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 33);
            this.label2.TabIndex = 90;
            this.label2.Text = "UNASSIGNED TEACHERS:";
            // 
            // subjectAssignedLabel
            // 
            this.subjectAssignedLabel.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectAssignedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(157)))));
            this.subjectAssignedLabel.Location = new System.Drawing.Point(18, 61);
            this.subjectAssignedLabel.Name = "subjectAssignedLabel";
            this.subjectAssignedLabel.Size = new System.Drawing.Size(428, 29);
            this.subjectAssignedLabel.TabIndex = 242;
            this.subjectAssignedLabel.Text = "GRADE <SELECTED> DEPARTMENT <SELECTED>:";
            // 
            // subjComboBox
            // 
            this.subjComboBox.FormattingEnabled = true;
            this.subjComboBox.Location = new System.Drawing.Point(857, 436);
            this.subjComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.subjComboBox.Name = "subjComboBox";
            this.subjComboBox.Size = new System.Drawing.Size(235, 24);
            this.subjComboBox.TabIndex = 91;
            this.subjComboBox.SelectedIndexChanged += new System.EventHandler(this.subjComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(157)))));
            this.label6.Location = new System.Drawing.Point(861, 408);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(232, 22);
            this.label6.TabIndex = 90;
            this.label6.Text = "ASSIGN TO DEPARTMENT:";
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(157)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(98)))));
            this.label3.Location = new System.Drawing.Point(14, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 41);
            this.label3.TabIndex = 85;
            this.label3.Text = "Grade Level Assignment";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.removeFromSubjAssignedListButton);
            this.groupBox2.Controls.Add(this.grLvlSummaryDgv);
            this.groupBox2.Controls.Add(this.summaryLabel);
            this.groupBox2.Controls.Add(this.subjectAssignedDgv);
            this.groupBox2.Controls.Add(this.subjectAssignedLabel);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(12, 443);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1254, 418);
            this.groupBox2.TabIndex = 247;
            this.groupBox2.TabStop = false;
            // 
            // grLvlSummaryDgv
            // 
            this.grLvlSummaryDgv.AllowUserToAddRows = false;
            this.grLvlSummaryDgv.AllowUserToResizeColumns = false;
            this.grLvlSummaryDgv.AllowUserToResizeRows = false;
            this.grLvlSummaryDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grLvlSummaryDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grLvlSummaryDgv.BackgroundColor = System.Drawing.Color.White;
            this.grLvlSummaryDgv.ColumnHeadersHeight = 40;
            this.grLvlSummaryDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grLvlSummaryDgv.EnableHeadersVisualStyles = false;
            this.grLvlSummaryDgv.Location = new System.Drawing.Point(652, 98);
            this.grLvlSummaryDgv.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.grLvlSummaryDgv.Name = "grLvlSummaryDgv";
            this.grLvlSummaryDgv.RowHeadersVisible = false;
            this.grLvlSummaryDgv.RowHeadersWidth = 62;
            this.grLvlSummaryDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grLvlSummaryDgv.Size = new System.Drawing.Size(573, 253);
            this.grLvlSummaryDgv.TabIndex = 243;
            // 
            // summaryLabel
            // 
            this.summaryLabel.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summaryLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(157)))));
            this.summaryLabel.Location = new System.Drawing.Point(648, 67);
            this.summaryLabel.Name = "summaryLabel";
            this.summaryLabel.Size = new System.Drawing.Size(283, 33);
            this.summaryLabel.TabIndex = 244;
            this.summaryLabel.Text = "GRADE <SELECTED> SUMMARY:";
            // 
            // subjectAssignedDgv
            // 
            this.subjectAssignedDgv.AllowUserToAddRows = false;
            this.subjectAssignedDgv.AllowUserToResizeColumns = false;
            this.subjectAssignedDgv.AllowUserToResizeRows = false;
            this.subjectAssignedDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subjectAssignedDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.subjectAssignedDgv.BackgroundColor = System.Drawing.Color.White;
            this.subjectAssignedDgv.ColumnHeadersHeight = 40;
            this.subjectAssignedDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.subjectAssignedDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.subjectAssignedDgv.EnableHeadersVisualStyles = false;
            this.subjectAssignedDgv.Location = new System.Drawing.Point(22, 98);
            this.subjectAssignedDgv.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.subjectAssignedDgv.Name = "subjectAssignedDgv";
            this.subjectAssignedDgv.RowHeadersVisible = false;
            this.subjectAssignedDgv.RowHeadersWidth = 62;
            this.subjectAssignedDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.subjectAssignedDgv.Size = new System.Drawing.Size(573, 253);
            this.subjectAssignedDgv.TabIndex = 159;
            // 
            // grLvlAssignedDgv
            // 
            this.grLvlAssignedDgv.AllowUserToAddRows = false;
            this.grLvlAssignedDgv.AllowUserToResizeColumns = false;
            this.grLvlAssignedDgv.AllowUserToResizeRows = false;
            this.grLvlAssignedDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grLvlAssignedDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grLvlAssignedDgv.BackgroundColor = System.Drawing.Color.White;
            this.grLvlAssignedDgv.ColumnHeadersHeight = 40;
            this.grLvlAssignedDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grLvlAssignedDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coladd});
            this.grLvlAssignedDgv.EnableHeadersVisualStyles = false;
            this.grLvlAssignedDgv.Location = new System.Drawing.Point(652, 87);
            this.grLvlAssignedDgv.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.grLvlAssignedDgv.Name = "grLvlAssignedDgv";
            this.grLvlAssignedDgv.RowHeadersVisible = false;
            this.grLvlAssignedDgv.RowHeadersWidth = 62;
            this.grLvlAssignedDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grLvlAssignedDgv.Size = new System.Drawing.Size(573, 305);
            this.grLvlAssignedDgv.TabIndex = 159;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.removeFromListButton);
            this.groupBox1.Controls.Add(this.grLvlAssignedDgv);
            this.groupBox1.Controls.Add(this.grLvlMaxAllowedTotalLabel);
            this.groupBox1.Controls.Add(this.grLvlAssignedTotalLabel);
            this.groupBox1.Controls.Add(this.unassignedDgv);
            this.groupBox1.Controls.Add(this.teachersTotalLabel);
            this.groupBox1.Controls.Add(this.unassignedTotalLabel);
            this.groupBox1.Controls.Add(this.grLvlAssignedLabel);
            this.groupBox1.Controls.Add(this.assignToSubjectButton);
            this.groupBox1.Controls.Add(this.grLvlComboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.assignToGradeLevelButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.subjComboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, -64);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1254, 478);
            this.groupBox1.TabIndex = 244;
            this.groupBox1.TabStop = false;
            // 
            // removeFromListButton
            // 
            this.removeFromListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeFromListButton.Location = new System.Drawing.Point(652, 420);
            this.removeFromListButton.Margin = new System.Windows.Forms.Padding(4);
            this.removeFromListButton.Name = "removeFromListButton";
            this.removeFromListButton.Size = new System.Drawing.Size(173, 39);
            this.removeFromListButton.TabIndex = 247;
            this.removeFromListButton.Text = "Remove from list";
            this.removeFromListButton.UseVisualStyleBackColor = true;
            this.removeFromListButton.Click += new System.EventHandler(this.removeFromListButton_Click);
            // 
            // grLvlMaxAllowedTotalLabel
            // 
            this.grLvlMaxAllowedTotalLabel.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grLvlMaxAllowedTotalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(157)))));
            this.grLvlMaxAllowedTotalLabel.Location = new System.Drawing.Point(1173, 55);
            this.grLvlMaxAllowedTotalLabel.Name = "grLvlMaxAllowedTotalLabel";
            this.grLvlMaxAllowedTotalLabel.Size = new System.Drawing.Size(52, 33);
            this.grLvlMaxAllowedTotalLabel.TabIndex = 246;
            this.grLvlMaxAllowedTotalLabel.Text = "/  5";
            // 
            // grLvlAssignedTotalLabel
            // 
            this.grLvlAssignedTotalLabel.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grLvlAssignedTotalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(157)))));
            this.grLvlAssignedTotalLabel.Location = new System.Drawing.Point(1115, 55);
            this.grLvlAssignedTotalLabel.Name = "grLvlAssignedTotalLabel";
            this.grLvlAssignedTotalLabel.Size = new System.Drawing.Size(52, 33);
            this.grLvlAssignedTotalLabel.TabIndex = 245;
            this.grLvlAssignedTotalLabel.Text = "3";
            this.grLvlAssignedTotalLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // unassignedDgv
            // 
            this.unassignedDgv.AllowUserToAddRows = false;
            this.unassignedDgv.AllowUserToResizeColumns = false;
            this.unassignedDgv.AllowUserToResizeRows = false;
            this.unassignedDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unassignedDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.unassignedDgv.BackgroundColor = System.Drawing.Color.White;
            this.unassignedDgv.ColumnHeadersHeight = 40;
            this.unassignedDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.unassignedDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.addcol});
            this.unassignedDgv.EnableHeadersVisualStyles = false;
            this.unassignedDgv.Location = new System.Drawing.Point(22, 87);
            this.unassignedDgv.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.unassignedDgv.Name = "unassignedDgv";
            this.unassignedDgv.RowHeadersVisible = false;
            this.unassignedDgv.RowHeadersWidth = 62;
            this.unassignedDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.unassignedDgv.Size = new System.Drawing.Size(573, 305);
            this.unassignedDgv.TabIndex = 159;
            // 
            // teachersTotalLabel
            // 
            this.teachersTotalLabel.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teachersTotalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(157)))));
            this.teachersTotalLabel.Location = new System.Drawing.Point(543, 55);
            this.teachersTotalLabel.Name = "teachersTotalLabel";
            this.teachersTotalLabel.Size = new System.Drawing.Size(52, 33);
            this.teachersTotalLabel.TabIndex = 244;
            this.teachersTotalLabel.Text = "/  20";
            // 
            // unassignedTotalLabel
            // 
            this.unassignedTotalLabel.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unassignedTotalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(157)))));
            this.unassignedTotalLabel.Location = new System.Drawing.Point(485, 55);
            this.unassignedTotalLabel.Name = "unassignedTotalLabel";
            this.unassignedTotalLabel.Size = new System.Drawing.Size(52, 33);
            this.unassignedTotalLabel.TabIndex = 243;
            this.unassignedTotalLabel.Text = "11";
            this.unassignedTotalLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(195, 930);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(814, 104);
            this.textBox1.TabIndex = 245;
            this.textBox1.Visible = false;
            // 
            // removeFromSubjAssignedListButton
            // 
            this.removeFromSubjAssignedListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeFromSubjAssignedListButton.Location = new System.Drawing.Point(22, 372);
            this.removeFromSubjAssignedListButton.Margin = new System.Windows.Forms.Padding(4);
            this.removeFromSubjAssignedListButton.Name = "removeFromSubjAssignedListButton";
            this.removeFromSubjAssignedListButton.Size = new System.Drawing.Size(173, 39);
            this.removeFromSubjAssignedListButton.TabIndex = 248;
            this.removeFromSubjAssignedListButton.Text = "Remove from list";
            this.removeFromSubjAssignedListButton.UseVisualStyleBackColor = true;
            this.removeFromSubjAssignedListButton.Click += new System.EventHandler(this.removeFromSubjAssignedListButton_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Select";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // coladd
            // 
            this.coladd.HeaderText = "Select";
            this.coladd.MinimumWidth = 6;
            this.coladd.Name = "coladd";
            // 
            // addcol
            // 
            this.addcol.HeaderText = "Select";
            this.addcol.MinimumWidth = 6;
            this.addcol.Name = "addcol";
            // 
            // frmFacultyAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1292, 832);
            this.ControlBox = false;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmFacultyAssignment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFacultyAssignment_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grLvlSummaryDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectAssignedDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grLvlAssignedDgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.unassignedDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox grLvlComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button assignToSubjectButton;
        private System.Windows.Forms.Label grLvlAssignedLabel;
        private System.Windows.Forms.Button assignToGradeLevelButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label subjectAssignedLabel;
        private System.Windows.Forms.ComboBox subjComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView subjectAssignedDgv;
        private System.Windows.Forms.DataGridView grLvlAssignedDgv;
        private System.Windows.Forms.DataGridView unassignedDgv;
        private System.Windows.Forms.DataGridView grLvlSummaryDgv;
        private System.Windows.Forms.Label summaryLabel;
        private System.Windows.Forms.Label grLvlMaxAllowedTotalLabel;
        private System.Windows.Forms.Label grLvlAssignedTotalLabel;
        private System.Windows.Forms.Label teachersTotalLabel;
        private System.Windows.Forms.Label unassignedTotalLabel;
        private System.Windows.Forms.Button removeFromListButton;
        private System.Windows.Forms.Button removeFromSubjAssignedListButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn coladd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn addcol;
    }
}