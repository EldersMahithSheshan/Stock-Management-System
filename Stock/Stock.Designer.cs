namespace Stock
{
    partial class Stock
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            comboBox1 = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            dataGridView1 = new DataGridView();
            dgSno = new DataGridViewTextBoxColumn();
            dgProCode = new DataGridViewTextBoxColumn();
            dgProName = new DataGridViewTextBoxColumn();
            dgQuantity = new DataGridViewTextBoxColumn();
            dgDate = new DataGridViewTextBoxColumn();
            dgStatus = new DataGridViewTextBoxColumn();
            button1 = new Button();
            button2 = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(373, 24);
            label1.Name = "label1";
            label1.Size = new Size(290, 50);
            label1.TabIndex = 0;
            label1.Text = "MSE WAREHOUSE";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(28, 104);
            label2.Name = "label2";
            label2.Size = new Size(46, 23);
            label2.TabIndex = 1;
            label2.Text = "Date";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(204, 104);
            label3.Name = "label3";
            label3.Size = new Size(115, 23);
            label3.TabIndex = 2;
            label3.Text = "Product Code";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(426, 104);
            label4.Name = "label4";
            label4.Size = new Size(121, 23);
            label4.TabIndex = 3;
            label4.Text = "Product Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(651, 104);
            label5.Name = "label5";
            label5.Size = new Size(76, 23);
            label5.TabIndex = 4;
            label5.Text = "Quantity";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(873, 104);
            label6.Name = "label6";
            label6.Size = new Size(56, 23);
            label6.TabIndex = 5;
            label6.Text = "Status";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(207, 141);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(206, 27);
            textBox1.TabIndex = 6;
            textBox1.KeyDown += textBox1_KeyDown;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(427, 141);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(206, 27);
            textBox2.TabIndex = 7;
            textBox2.KeyDown += textBox2_KeyDown;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(651, 141);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(206, 27);
            textBox3.TabIndex = 8;
            textBox3.KeyDown += textBox3_KeyDown;
            textBox3.KeyPress += textBox3_KeyPress;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Active", "Deactive" });
            comboBox1.Location = new Point(873, 140);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(108, 28);
            comboBox1.TabIndex = 9;
            comboBox1.KeyDown += comboBox1_KeyDown;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(28, 141);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(169, 27);
            dateTimePicker1.TabIndex = 10;
            dateTimePicker1.Value = new DateTime(2023, 9, 27, 18, 15, 17, 0);
            dateTimePicker1.KeyDown += dateTimePicker1_KeyDown;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { dgSno, dgProCode, dgProName, dgQuantity, dgDate, dgStatus });
            dataGridView1.Location = new Point(28, 269);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(953, 269);
            dataGridView1.TabIndex = 11;
            dataGridView1.MouseDoubleClick += dataGridView1_MouseDoubleClick;
            // 
            // dgSno
            // 
            dgSno.HeaderText = "S.No";
            dgSno.MinimumWidth = 6;
            dgSno.Name = "dgSno";
            dgSno.Width = 125;
            // 
            // dgProCode
            // 
            dgProCode.HeaderText = "Product Code";
            dgProCode.MinimumWidth = 6;
            dgProCode.Name = "dgProCode";
            dgProCode.Width = 125;
            // 
            // dgProName
            // 
            dgProName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgProName.HeaderText = "Product Name";
            dgProName.MinimumWidth = 6;
            dgProName.Name = "dgProName";
            // 
            // dgQuantity
            // 
            dgQuantity.HeaderText = "Quantity";
            dgQuantity.MinimumWidth = 6;
            dgQuantity.Name = "dgQuantity";
            dgQuantity.Width = 125;
            // 
            // dgDate
            // 
            dgDate.HeaderText = "Date";
            dgDate.MinimumWidth = 6;
            dgDate.Name = "dgDate";
            dgDate.Width = 165;
            // 
            // dgStatus
            // 
            dgStatus.HeaderText = "Status";
            dgStatus.MinimumWidth = 6;
            dgStatus.Name = "dgStatus";
            dgStatus.Width = 125;
            // 
            // button1
            // 
            button1.Location = new Point(395, 196);
            button1.Name = "button1";
            button1.Size = new Size(94, 49);
            button1.TabIndex = 12;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(535, 196);
            button2.Name = "button2";
            button2.Size = new Size(94, 49);
            button2.TabIndex = 13;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Stock
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 561);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(dateTimePicker1);
            Controls.Add(comboBox1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Stock";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stock";
            Load += Stock_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private ComboBox comboBox1;
        private DateTimePicker dateTimePicker1;
        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private ErrorProvider errorProvider1;
        private DataGridViewTextBoxColumn dgSno;
        private DataGridViewTextBoxColumn dgProCode;
        private DataGridViewTextBoxColumn dgProName;
        private DataGridViewTextBoxColumn dgQuantity;
        private DataGridViewTextBoxColumn dgDate;
        private DataGridViewTextBoxColumn dgStatus;
    }
}