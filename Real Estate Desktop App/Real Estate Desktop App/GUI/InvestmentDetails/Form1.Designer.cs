namespace Com.RealEstate.DesktopApp.GUI.InvestmentDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_InHand = new System.Windows.Forms.TextBox();
            this.label_Add = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_InvestorID = new System.Windows.Forms.ComboBox();
            this.label_InvestorID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_BackUp = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_TotalAmount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.dataGridView_ = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Change = new System.Windows.Forms.Button();
            this.button_Show = new System.Windows.Forms.Button();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Investor:";
            // 
            // textBox_InHand
            // 
            this.textBox_InHand.Location = new System.Drawing.Point(187, 98);
            this.textBox_InHand.Name = "textBox_InHand";
            this.textBox_InHand.Size = new System.Drawing.Size(150, 20);
            this.textBox_InHand.TabIndex = 2;
            this.textBox_InHand.Enter += new System.EventHandler(this.textBox1_Leave);
            this.textBox_InHand.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label_Add
            // 
            this.label_Add.Location = new System.Drawing.Point(99, 10);
            this.label_Add.Name = "label_Add";
            this.label_Add.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_Add.Size = new System.Drawing.Size(35, 13);
            this.label_Add.TabIndex = 4;
            this.label_Add.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "In Hand:";
            // 
            // comboBox_InvestorID
            // 
            this.comboBox_InvestorID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_InvestorID.FormattingEnabled = true;
            this.comboBox_InvestorID.Location = new System.Drawing.Point(15, 42);
            this.comboBox_InvestorID.Name = "comboBox_InvestorID";
            this.comboBox_InvestorID.Size = new System.Drawing.Size(150, 21);
            this.comboBox_InvestorID.TabIndex = 7;
            this.comboBox_InvestorID.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // label_InvestorID
            // 
            this.label_InvestorID.Location = new System.Drawing.Point(133, 26);
            this.label_InvestorID.Name = "label_InvestorID";
            this.label_InvestorID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_InvestorID.Size = new System.Drawing.Size(35, 13);
            this.label_InvestorID.TabIndex = 9;
            this.label_InvestorID.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(356, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Back Up:";
            // 
            // textBox_BackUp
            // 
            this.textBox_BackUp.Enabled = false;
            this.textBox_BackUp.Location = new System.Drawing.Point(359, 98);
            this.textBox_BackUp.Name = "textBox_BackUp";
            this.textBox_BackUp.Size = new System.Drawing.Size(150, 20);
            this.textBox_BackUp.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(528, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Total Amount:";
            // 
            // textBox_TotalAmount
            // 
            this.textBox_TotalAmount.Location = new System.Drawing.Point(531, 98);
            this.textBox_TotalAmount.Name = "textBox_TotalAmount";
            this.textBox_TotalAmount.Size = new System.Drawing.Size(150, 20);
            this.textBox_TotalAmount.TabIndex = 12;
            this.textBox_TotalAmount.Enter += new System.EventHandler(this.textBox1_Leave);
            this.textBox_TotalAmount.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Investment Name:";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(15, 98);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(150, 20);
            this.textBox_Name.TabIndex = 14;
            // 
            // dataGridView_
            // 
            this.dataGridView_.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_.Name = "dataGridView_";
            this.dataGridView_.Size = new System.Drawing.Size(861, 191);
            this.dataGridView_.TabIndex = 16;
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
            this.splitContainer1.Size = new System.Drawing.Size(861, 335);
            this.splitContainer1.SplitterDistance = 140;
            this.splitContainer1.TabIndex = 19;
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
            this.splitContainer2.Size = new System.Drawing.Size(861, 140);
            this.splitContainer2.SplitterDistance = 719;
            this.splitContainer2.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox_BackUp);
            this.groupBox1.Controls.Add(this.comboBox_InvestorID);
            this.groupBox1.Controls.Add(this.textBox_InHand);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_TotalAmount);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox_Name);
            this.groupBox1.Controls.Add(this.label_InvestorID);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(719, 140);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Investment Details";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_Add);
            this.groupBox2.Controls.Add(this.button_Change);
            this.groupBox2.Controls.Add(this.label_Add);
            this.groupBox2.Controls.Add(this.button_Show);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(138, 140);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Actions";
            // 
            // button_Add
            // 
            this.button_Add.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.add;
            this.button_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Add.Location = new System.Drawing.Point(6, 26);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(125, 25);
            this.button_Add.TabIndex = 0;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_Change
            // 
            this.button_Change.Enabled = false;
            this.button_Change.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.Edit;
            this.button_Change.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Change.Location = new System.Drawing.Point(6, 55);
            this.button_Change.Name = "button_Change";
            this.button_Change.Size = new System.Drawing.Size(125, 25);
            this.button_Change.TabIndex = 17;
            this.button_Change.Text = "Change";
            this.button_Change.UseVisualStyleBackColor = true;
            this.button_Change.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_Show
            // 
            this.button_Show.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.glasses;
            this.button_Show.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Show.Location = new System.Drawing.Point(6, 84);
            this.button_Show.Name = "button_Show";
            this.button_Show.Size = new System.Drawing.Size(125, 25);
            this.button_Show.TabIndex = 18;
            this.button_Show.Text = "Show";
            this.button_Show.UseVisualStyleBackColor = true;
            this.button_Show.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 335);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_InHand;
        private System.Windows.Forms.Label label_Add;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_InvestorID;
        private System.Windows.Forms.Label label_InvestorID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_BackUp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_TotalAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.DataGridView dataGridView_;
        private System.Windows.Forms.Button button_Change;
        private System.Windows.Forms.Button button_Show;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}