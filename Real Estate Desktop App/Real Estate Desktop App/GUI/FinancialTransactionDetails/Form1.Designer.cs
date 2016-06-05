namespace Com.RealEstate.DesktopApp.GUI.FinancialTransactionDetails
{
    partial class Form1
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
            this.button_Add = new System.Windows.Forms.Button();
            this.textBox_Amount = new System.Windows.Forms.TextBox();
            this.comboBox_TransactionType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_TransactionReference = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker_TransactionDate = new System.Windows.Forms.DateTimePicker();
            this.comboBox_ContactID = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox_WalletType = new System.Windows.Forms.ComboBox();
            this.comboBox_FlowType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox_CascadeChanges = new System.Windows.Forms.CheckBox();
            this.comboBox_WalletReference = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView_ = new System.Windows.Forms.DataGridView();
            this.button_Show = new System.Windows.Forms.Button();
            this.label_Add = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Add
            // 
            this.button_Add.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.add;
            this.button_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Add.Location = new System.Drawing.Point(9, 29);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(125, 25);
            this.button_Add.TabIndex = 0;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_Amount
            // 
            this.textBox_Amount.Location = new System.Drawing.Point(15, 153);
            this.textBox_Amount.Name = "textBox_Amount";
            this.textBox_Amount.Size = new System.Drawing.Size(150, 20);
            this.textBox_Amount.TabIndex = 2;
            // 
            // comboBox_TransactionType
            // 
            this.comboBox_TransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TransactionType.FormattingEnabled = true;
            this.comboBox_TransactionType.Location = new System.Drawing.Point(331, 153);
            this.comboBox_TransactionType.Name = "comboBox_TransactionType";
            this.comboBox_TransactionType.Size = new System.Drawing.Size(150, 21);
            this.comboBox_TransactionType.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(328, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Transaction Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(488, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Transaction Reference";
            // 
            // textBox_TransactionReference
            // 
            this.textBox_TransactionReference.Location = new System.Drawing.Point(489, 100);
            this.textBox_TransactionReference.Multiline = true;
            this.textBox_TransactionReference.Name = "textBox_TransactionReference";
            this.textBox_TransactionReference.Size = new System.Drawing.Size(170, 74);
            this.textBox_TransactionReference.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Transaction Date";
            // 
            // dateTimePicker_TransactionDate
            // 
            this.dateTimePicker_TransactionDate.Location = new System.Drawing.Point(15, 48);
            this.dateTimePicker_TransactionDate.Name = "dateTimePicker_TransactionDate";
            this.dateTimePicker_TransactionDate.Size = new System.Drawing.Size(150, 20);
            this.dateTimePicker_TransactionDate.TabIndex = 11;
            // 
            // comboBox_ContactID
            // 
            this.comboBox_ContactID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ContactID.FormattingEnabled = true;
            this.comboBox_ContactID.Location = new System.Drawing.Point(15, 100);
            this.comboBox_ContactID.Name = "comboBox_ContactID";
            this.comboBox_ContactID.Size = new System.Drawing.Size(150, 21);
            this.comboBox_ContactID.TabIndex = 12;
            this.comboBox_ContactID.SelectionChangeCommitted += new System.EventHandler(this.comboBox2_SelectionChangeCommitted);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(170, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Wallet Type";
            // 
            // comboBox_WalletType
            // 
            this.comboBox_WalletType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_WalletType.FormattingEnabled = true;
            this.comboBox_WalletType.Location = new System.Drawing.Point(173, 100);
            this.comboBox_WalletType.Name = "comboBox_WalletType";
            this.comboBox_WalletType.Size = new System.Drawing.Size(150, 21);
            this.comboBox_WalletType.TabIndex = 15;
            this.comboBox_WalletType.SelectionChangeCommitted += new System.EventHandler(this.comboBox3_SelectionChangeCommitted);
            // 
            // comboBox_FlowType
            // 
            this.comboBox_FlowType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FlowType.FormattingEnabled = true;
            this.comboBox_FlowType.Location = new System.Drawing.Point(173, 152);
            this.comboBox_FlowType.Name = "comboBox_FlowType";
            this.comboBox_FlowType.Size = new System.Drawing.Size(150, 21);
            this.comboBox_FlowType.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(170, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Flow Type";
            // 
            // checkBox_CascadeChanges
            // 
            this.checkBox_CascadeChanges.AutoSize = true;
            this.checkBox_CascadeChanges.Location = new System.Drawing.Point(491, 48);
            this.checkBox_CascadeChanges.Name = "checkBox_CascadeChanges";
            this.checkBox_CascadeChanges.Size = new System.Drawing.Size(113, 17);
            this.checkBox_CascadeChanges.TabIndex = 18;
            this.checkBox_CascadeChanges.Text = "Cascade Changes";
            this.checkBox_CascadeChanges.UseVisualStyleBackColor = true;
            // 
            // comboBox_WalletReference
            // 
            this.comboBox_WalletReference.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_WalletReference.FormattingEnabled = true;
            this.comboBox_WalletReference.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.comboBox_WalletReference.Location = new System.Drawing.Point(331, 100);
            this.comboBox_WalletReference.Name = "comboBox_WalletReference";
            this.comboBox_WalletReference.Size = new System.Drawing.Size(150, 21);
            this.comboBox_WalletReference.TabIndex = 20;
            this.comboBox_WalletReference.SelectionChangeCommitted += new System.EventHandler(this.comboBox5_SelectionChangeCommitted);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(328, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Wallet Reference";
            // 
            // dataGridView_
            // 
            this.dataGridView_.AllowUserToOrderColumns = true;
            this.dataGridView_.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_.Name = "dataGridView_";
            this.dataGridView_.Size = new System.Drawing.Size(844, 130);
            this.dataGridView_.TabIndex = 21;
            // 
            // button_Show
            // 
            this.button_Show.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.glasses;
            this.button_Show.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Show.Location = new System.Drawing.Point(9, 60);
            this.button_Show.Name = "button_Show";
            this.button_Show.Size = new System.Drawing.Size(125, 25);
            this.button_Show.TabIndex = 22;
            this.button_Show.Text = "Show";
            this.button_Show.UseVisualStyleBackColor = true;
            this.button_Show.Click += new System.EventHandler(this.button2_Click);
            // 
            // label_Add
            // 
            this.label_Add.Location = new System.Drawing.Point(99, 13);
            this.label_Add.Name = "label_Add";
            this.label_Add.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_Add.Size = new System.Drawing.Size(35, 13);
            this.label_Add.TabIndex = 24;
            this.label_Add.Text = "0";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(124, 84);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "0";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(441, 84);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label14.Size = new System.Drawing.Size(41, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "0";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView_);
            this.splitContainer1.Size = new System.Drawing.Size(844, 326);
            this.splitContainer1.SplitterDistance = 192;
            this.splitContainer1.TabIndex = 29;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(844, 192);
            this.splitContainer2.SplitterDistance = 694;
            this.splitContainer2.TabIndex = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_TransactionReference);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox_WalletType);
            this.groupBox1.Controls.Add(this.checkBox_CascadeChanges);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.comboBox_WalletReference);
            this.groupBox1.Controls.Add(this.comboBox_ContactID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.comboBox_FlowType);
            this.groupBox1.Controls.Add(this.textBox_Amount);
            this.groupBox1.Controls.Add(this.comboBox_TransactionType);
            this.groupBox1.Controls.Add(this.dateTimePicker_TransactionDate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(694, 192);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transaction Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Contact Account";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_Add);
            this.groupBox2.Controls.Add(this.label_Add);
            this.groupBox2.Controls.Add(this.button_Show);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(146, 192);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Actions";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 326);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.TextBox textBox_Amount;
        private System.Windows.Forms.ComboBox comboBox_TransactionType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_TransactionReference;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker_TransactionDate;
        private System.Windows.Forms.ComboBox comboBox_ContactID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox_WalletType;
        private System.Windows.Forms.ComboBox comboBox_FlowType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox_CascadeChanges;
        private System.Windows.Forms.ComboBox comboBox_WalletReference;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridView_;
        private System.Windows.Forms.Button button_Show;
        private System.Windows.Forms.Label label_Add;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}