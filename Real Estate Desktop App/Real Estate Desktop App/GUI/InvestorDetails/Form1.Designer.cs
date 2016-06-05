namespace Com.RealEstate.DesktopApp.GUI.InvestorDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.comboBox_ContactID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label_ContactID = new System.Windows.Forms.Label();
            this.dataGridView_ = new System.Windows.Forms.DataGridView();
            this.label_Add = new System.Windows.Forms.Label();
            this.button_Show = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_Remove = new System.Windows.Forms.Button();
            this.label_Remove = new System.Windows.Forms.Label();
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
            this.button_Add.Location = new System.Drawing.Point(14, 32);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(125, 25);
            this.button_Add.TabIndex = 0;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Contact:";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(188, 49);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(150, 20);
            this.textBox_Name.TabIndex = 2;
            // 
            // comboBox_ContactID
            // 
            this.comboBox_ContactID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ContactID.FormattingEnabled = true;
            this.comboBox_ContactID.Location = new System.Drawing.Point(21, 48);
            this.comboBox_ContactID.Name = "comboBox_ContactID";
            this.comboBox_ContactID.Size = new System.Drawing.Size(150, 21);
            this.comboBox_ContactID.TabIndex = 3;
            this.comboBox_ContactID.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Investor Name:";
            // 
            // label_ContactID
            // 
            this.label_ContactID.Location = new System.Drawing.Point(136, 32);
            this.label_ContactID.Name = "label_ContactID";
            this.label_ContactID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_ContactID.Size = new System.Drawing.Size(35, 13);
            this.label_ContactID.TabIndex = 6;
            this.label_ContactID.Text = "0";
            // 
            // dataGridView_
            // 
            this.dataGridView_.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_.Name = "dataGridView_";
            this.dataGridView_.Size = new System.Drawing.Size(853, 247);
            this.dataGridView_.TabIndex = 7;
            this.dataGridView_.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label_Add
            // 
            this.label_Add.Location = new System.Drawing.Point(107, 16);
            this.label_Add.Name = "label_Add";
            this.label_Add.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_Add.Size = new System.Drawing.Size(35, 13);
            this.label_Add.TabIndex = 8;
            this.label_Add.Text = "0";
            // 
            // button_Show
            // 
            this.button_Show.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.glasses;
            this.button_Show.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Show.Location = new System.Drawing.Point(14, 106);
            this.button_Show.Name = "button_Show";
            this.button_Show.Size = new System.Drawing.Size(125, 25);
            this.button_Show.TabIndex = 9;
            this.button_Show.Text = "Show";
            this.button_Show.UseVisualStyleBackColor = true;
            this.button_Show.Click += new System.EventHandler(this.button2_Click);
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
            this.splitContainer1.Size = new System.Drawing.Size(853, 401);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 10;
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
            this.splitContainer2.Size = new System.Drawing.Size(853, 150);
            this.splitContainer2.SplitterDistance = 698;
            this.splitContainer2.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label_ContactID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_Name);
            this.groupBox1.Controls.Add(this.comboBox_ContactID);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(698, 150);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Investor Details";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_Remove);
            this.groupBox2.Controls.Add(this.label_Remove);
            this.groupBox2.Controls.Add(this.button_Add);
            this.groupBox2.Controls.Add(this.button_Show);
            this.groupBox2.Controls.Add(this.label_Add);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(151, 150);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Actions";
            // 
            // button_Remove
            // 
            this.button_Remove.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.remove;
            this.button_Remove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Remove.Location = new System.Drawing.Point(14, 75);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(125, 25);
            this.button_Remove.TabIndex = 10;
            this.button_Remove.Text = "Remove";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.button3_Click);
            // 
            // label_Remove
            // 
            this.label_Remove.Location = new System.Drawing.Point(107, 59);
            this.label_Remove.Name = "label_Remove";
            this.label_Remove.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_Remove.Size = new System.Drawing.Size(35, 13);
            this.label_Remove.TabIndex = 11;
            this.label_Remove.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 401);
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
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.ComboBox comboBox_ContactID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_ContactID;
        private System.Windows.Forms.DataGridView dataGridView_;
        private System.Windows.Forms.Label label_Add;
        private System.Windows.Forms.Button button_Show;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Label label_Remove;
    }
}