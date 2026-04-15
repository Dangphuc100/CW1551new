namespace CW1551
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAdd = new Button();
            lbName = new Label();
            lbPhone = new Label();
            lbEmail = new Label();
            txtName = new TextBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            lbRole = new Label();
            cbRole = new ComboBox();
            btnView = new Button();
            btnFilter = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            dataGridView1 = new DataGridView();
            lbExtra1 = new Label();
            txtExtra1 = new TextBox();
            lbExtra2 = new Label();
            txtExtra2 = new TextBox();
            cbExtra2 = new ComboBox();
            lbExtra3 = new Label();
            txtExtra3 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(20, 320);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 35);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Location = new Point(20, 30);
            lbName.Name = "lbName";
            lbName.Size = new Size(49, 20);
            lbName.TabIndex = 2;
            lbName.Text = "Name";
            lbName.Click += label1_Click;
            // 
            // lbPhone
            // 
            lbPhone.AutoSize = true;
            lbPhone.Location = new Point(20, 70);
            lbPhone.Name = "lbPhone";
            lbPhone.Size = new Size(50, 20);
            lbPhone.TabIndex = 3;
            lbPhone.Text = "Phone";
            lbPhone.Click += lbPhone_Click;
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Location = new Point(20, 110);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(46, 20);
            lbEmail.TabIndex = 4;
            lbEmail.Text = "Email";
            // 
            // txtName
            // 
            txtName.Location = new Point(120, 27);
            txtName.Name = "txtName";
            txtName.Size = new Size(220, 27);
            txtName.TabIndex = 5;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(120, 67);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(220, 27);
            txtPhone.TabIndex = 6;
            txtPhone.TextChanged += txtPhone_TextChanged;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(120, 107);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(220, 27);
            txtEmail.TabIndex = 7;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // lbRole
            // 
            lbRole.AutoSize = true;
            lbRole.Location = new Point(20, 150);
            lbRole.Name = "lbRole";
            lbRole.Size = new Size(39, 20);
            lbRole.TabIndex = 8;
            lbRole.Text = "Role";
            // 
            // cbRole
            // 
            cbRole.FormattingEnabled = true;
            cbRole.Location = new Point(120, 147);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(220, 28);
            cbRole.TabIndex = 9;
            cbRole.SelectedIndexChanged += cbRole_SelectedIndexChanged;
            // 
            // btnView
            // 
            btnView.Location = new Point(20, 370);
            btnView.Name = "btnView";
            btnView.Size = new Size(100, 35);
            btnView.TabIndex = 10;
            btnView.Text = "View";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(130, 370);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(100, 35);
            btnFilter.TabIndex = 11;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(130, 320);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 35);
            btnEdit.TabIndex = 12;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(240, 320);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 35);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(360, 27);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(510, 560);
            dataGridView1.TabIndex = 14;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // lbExtra1
            // 
            lbExtra1.AutoSize = true;
            lbExtra1.Location = new Point(20, 190);
            lbExtra1.Name = "lbExtra1";
            lbExtra1.Size = new Size(50, 20);
            lbExtra1.TabIndex = 15;
            lbExtra1.Text = "Extra1";
            lbExtra1.Visible = false;
            // 
            // txtExtra1
            // 
            txtExtra1.Location = new Point(120, 187);
            txtExtra1.Name = "txtExtra1";
            txtExtra1.Size = new Size(220, 27);
            txtExtra1.TabIndex = 16;
            txtExtra1.Visible = false;
            // 
            // lbExtra2
            // 
            lbExtra2.AutoSize = true;
            lbExtra2.Location = new Point(20, 230);
            lbExtra2.Name = "lbExtra2";
            lbExtra2.Size = new Size(50, 20);
            lbExtra2.TabIndex = 17;
            lbExtra2.Text = "Extra2";
            lbExtra2.Visible = false;
            // 
            // txtExtra2
            // 
            txtExtra2.Location = new Point(120, 227);
            txtExtra2.Name = "txtExtra2";
            txtExtra2.Size = new Size(220, 27);
            txtExtra2.TabIndex = 18;
            txtExtra2.Visible = false;
            // 
            // cbExtra2
            // 
            cbExtra2.FormattingEnabled = true;
            cbExtra2.Location = new Point(120, 227);
            cbExtra2.Name = "cbExtra2";
            cbExtra2.Size = new Size(220, 28);
            cbExtra2.TabIndex = 21;
            cbExtra2.Visible = false;
            // 
            // lbExtra3
            // 
            lbExtra3.AutoSize = true;
            lbExtra3.Location = new Point(20, 270);
            lbExtra3.Name = "lbExtra3";
            lbExtra3.Size = new Size(50, 20);
            lbExtra3.TabIndex = 19;
            lbExtra3.Text = "Extra3";
            lbExtra3.Visible = false;
            // 
            // txtExtra3
            // 
            txtExtra3.Location = new Point(120, 267);
            txtExtra3.Name = "txtExtra3";
            txtExtra3.Size = new Size(220, 27);
            txtExtra3.TabIndex = 20;
            txtExtra3.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 620);
            Controls.Add(txtExtra3);
            Controls.Add(lbExtra3);
            Controls.Add(cbExtra2);
            Controls.Add(txtExtra2);
            Controls.Add(lbExtra2);
            Controls.Add(txtExtra1);
            Controls.Add(lbExtra1);
            Controls.Add(dataGridView1);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnFilter);
            Controls.Add(btnView);
            Controls.Add(cbRole);
            Controls.Add(lbRole);
            Controls.Add(txtEmail);
            Controls.Add(txtPhone);
            Controls.Add(txtName);
            Controls.Add(lbEmail);
            Controls.Add(lbPhone);
            Controls.Add(lbName);
            Controls.Add(btnAdd);
            Name = "Form1";
            Text = "Greenwich Education Management System";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private Label lbName;
        private Label lbPhone;
        private Label lbEmail;
        private TextBox txtName;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private Label lbRole;
        private ComboBox cbRole;
        private Button btnView;
        private Button btnFilter;
        private Button btnEdit;
        private Button btnDelete;
        private DataGridView dataGridView1;
        private Label lbExtra1;
        private TextBox txtExtra1;
        private Label lbExtra2;
        private TextBox txtExtra2;
        private ComboBox cbExtra2;
        private Label lbExtra3;
        private TextBox txtExtra3;
    }
}
