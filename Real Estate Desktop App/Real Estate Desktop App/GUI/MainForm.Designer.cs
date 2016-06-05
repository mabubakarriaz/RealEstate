using System.Reflection;
using System.Windows.Forms;

namespace Com.RealEstate.DesktopApp.GUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("Investment Groups");
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("Investments");
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("Investors", new System.Windows.Forms.TreeNode[] {
            treeNode41,
            treeNode42});
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("Agent Groups");
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("Agents", new System.Windows.Forms.TreeNode[] {
            treeNode44});
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("Contacts", new System.Windows.Forms.TreeNode[] {
            treeNode43,
            treeNode45});
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("Plots");
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("Products", new System.Windows.Forms.TreeNode[] {
            treeNode47});
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("Deals");
            System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("Financial Transactions");
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("Transactions", new System.Windows.Forms.TreeNode[] {
            treeNode49,
            treeNode50});
            System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("Investment Groups");
            System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("Agent Groups");
            System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode("Groups", new System.Windows.Forms.TreeNode[] {
            treeNode52,
            treeNode53});
            System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode("Ledger");
            System.Windows.Forms.TreeNode treeNode56 = new System.Windows.Forms.TreeNode("Reports", new System.Windows.Forms.TreeNode[] {
            treeNode55});
            System.Windows.Forms.TreeNode treeNode57 = new System.Windows.Forms.TreeNode("Investments");
            System.Windows.Forms.TreeNode treeNode58 = new System.Windows.Forms.TreeNode("Investment Groups");
            System.Windows.Forms.TreeNode treeNode59 = new System.Windows.Forms.TreeNode("Investments", new System.Windows.Forms.TreeNode[] {
            treeNode57,
            treeNode58});
            System.Windows.Forms.TreeNode treeNode60 = new System.Windows.Forms.TreeNode("Real Estate", new System.Windows.Forms.TreeNode[] {
            treeNode46,
            treeNode48,
            treeNode51,
            treeNode54,
            treeNode56,
            treeNode59});
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_Commissions = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.investorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agentGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.investmentGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.financialTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ledgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dealsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button10 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 386);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 70);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Person Management";
            // 
            // button2
            // 
            this.button2.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.Person;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(25, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 25);
            this.button2.TabIndex = 1;
            this.button2.Text = "Contacts";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_Commissions);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 163);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transactions Management";
            // 
            // button_Commissions
            // 
            this.button_Commissions.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.bill;
            this.button_Commissions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Commissions.Location = new System.Drawing.Point(25, 121);
            this.button_Commissions.Name = "button_Commissions";
            this.button_Commissions.Size = new System.Drawing.Size(170, 25);
            this.button_Commissions.TabIndex = 7;
            this.button_Commissions.Text = "Commissions";
            this.button_Commissions.UseVisualStyleBackColor = true;
            this.button_Commissions.Click += new System.EventHandler(this.button_Commissions_Click);
            // 
            // button1
            // 
            this.button1.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.location;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(25, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "Plots";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button6
            // 
            this.button6.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.bill;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(25, 92);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(170, 25);
            this.button6.TabIndex = 5;
            this.button6.Text = "Financial Transactions";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button8
            // 
            this.button8.Image = ((System.Drawing.Image)(resources.GetObject("button8.Image")));
            this.button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.Location = new System.Drawing.Point(25, 63);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(170, 25);
            this.button8.TabIndex = 6;
            this.button8.Text = "Deals";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button7);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 97);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(232, 126);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Investment Management";
            // 
            // button7
            // 
            this.button7.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.group;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(25, 86);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(170, 25);
            this.button7.TabIndex = 4;
            this.button7.Text = "Investment Groups";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button3
            // 
            this.button3.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.Person;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(25, 28);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(170, 25);
            this.button3.TabIndex = 2;
            this.button3.Text = "Investors";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.wallet;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(25, 57);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(170, 25);
            this.button4.TabIndex = 3;
            this.button4.Text = "Investments";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button9);
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(232, 94);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Agents Management";
            // 
            // button9
            // 
            this.button9.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.group;
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.Location = new System.Drawing.Point(25, 55);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(170, 25);
            this.button9.TabIndex = 0;
            this.button9.Text = "Agent Groups";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button5
            // 
            this.button5.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.Person;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(25, 26);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(170, 25);
            this.button5.TabIndex = 4;
            this.button5.Text = "Agents";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.personsToolStripMenuItem,
            this.groupsToolStripMenuItem,
            this.transactionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(953, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // bToolStripMenuItem
            // 
            this.bToolStripMenuItem.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.Exit;
            this.bToolStripMenuItem.Name = "bToolStripMenuItem";
            this.bToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.bToolStripMenuItem.Text = "Exit";
            this.bToolStripMenuItem.Click += new System.EventHandler(this.bToolStripMenuItem_Click);
            // 
            // personsToolStripMenuItem
            // 
            this.personsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contactsToolStripMenuItem,
            this.agentsToolStripMenuItem,
            this.investorsToolStripMenuItem});
            this.personsToolStripMenuItem.Name = "personsToolStripMenuItem";
            this.personsToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.personsToolStripMenuItem.Text = "Persons";
            // 
            // contactsToolStripMenuItem
            // 
            this.contactsToolStripMenuItem.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.Person;
            this.contactsToolStripMenuItem.Name = "contactsToolStripMenuItem";
            this.contactsToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.contactsToolStripMenuItem.Text = "Contacts";
            this.contactsToolStripMenuItem.Click += new System.EventHandler(this.contactsToolStripMenuItem_Click);
            // 
            // agentsToolStripMenuItem
            // 
            this.agentsToolStripMenuItem.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.Person;
            this.agentsToolStripMenuItem.Name = "agentsToolStripMenuItem";
            this.agentsToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.agentsToolStripMenuItem.Text = "Agents";
            this.agentsToolStripMenuItem.Click += new System.EventHandler(this.agentsToolStripMenuItem_Click);
            // 
            // investorsToolStripMenuItem
            // 
            this.investorsToolStripMenuItem.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.Person;
            this.investorsToolStripMenuItem.Name = "investorsToolStripMenuItem";
            this.investorsToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.investorsToolStripMenuItem.Text = "Investors";
            this.investorsToolStripMenuItem.Click += new System.EventHandler(this.investorsToolStripMenuItem_Click);
            // 
            // groupsToolStripMenuItem
            // 
            this.groupsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agentGroupsToolStripMenuItem,
            this.investmentGroupsToolStripMenuItem});
            this.groupsToolStripMenuItem.Name = "groupsToolStripMenuItem";
            this.groupsToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.groupsToolStripMenuItem.Text = "Groups";
            // 
            // agentGroupsToolStripMenuItem
            // 
            this.agentGroupsToolStripMenuItem.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.group;
            this.agentGroupsToolStripMenuItem.Name = "agentGroupsToolStripMenuItem";
            this.agentGroupsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.agentGroupsToolStripMenuItem.Text = "Agent Groups";
            this.agentGroupsToolStripMenuItem.Click += new System.EventHandler(this.agentGroupsToolStripMenuItem_Click);
            // 
            // investmentGroupsToolStripMenuItem
            // 
            this.investmentGroupsToolStripMenuItem.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.group;
            this.investmentGroupsToolStripMenuItem.Name = "investmentGroupsToolStripMenuItem";
            this.investmentGroupsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.investmentGroupsToolStripMenuItem.Text = "Investment Groups";
            this.investmentGroupsToolStripMenuItem.Click += new System.EventHandler(this.investmentGroupsToolStripMenuItem_Click);
            // 
            // transactionsToolStripMenuItem
            // 
            this.transactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.financialTransactionsToolStripMenuItem,
            this.ledgerToolStripMenuItem,
            this.dealsToolStripMenuItem});
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.transactionsToolStripMenuItem.Text = "Transactions";
            // 
            // financialTransactionsToolStripMenuItem
            // 
            this.financialTransactionsToolStripMenuItem.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.bill;
            this.financialTransactionsToolStripMenuItem.Name = "financialTransactionsToolStripMenuItem";
            this.financialTransactionsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.financialTransactionsToolStripMenuItem.Text = "Financial Transactions";
            this.financialTransactionsToolStripMenuItem.Click += new System.EventHandler(this.financialTransactionsToolStripMenuItem_Click);
            // 
            // ledgerToolStripMenuItem
            // 
            this.ledgerToolStripMenuItem.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.cash_register;
            this.ledgerToolStripMenuItem.Name = "ledgerToolStripMenuItem";
            this.ledgerToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.ledgerToolStripMenuItem.Text = "Ledger";
            this.ledgerToolStripMenuItem.Click += new System.EventHandler(this.ledgerToolStripMenuItem_Click);
            // 
            // dealsToolStripMenuItem
            // 
            this.dealsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dealsToolStripMenuItem.Image")));
            this.dealsToolStripMenuItem.Name = "dealsToolStripMenuItem";
            this.dealsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.dealsToolStripMenuItem.Text = "Deals";
            this.dealsToolStripMenuItem.Click += new System.EventHandler(this.dealsToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 635);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(953, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatusLabel1.Text = "Ready...";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.tabControl2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(953, 611);
            this.splitContainer1.SplitterDistance = 246;
            this.splitContainer1.TabIndex = 12;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(246, 611);
            this.tabControl2.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(238, 585);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Groups";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button10);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 456);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(232, 70);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Reports";
            // 
            // button10
            // 
            this.button10.Image = global::Com.RealEstate.DesktopApp.Properties.Resources.cash_register;
            this.button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.Location = new System.Drawing.Point(25, 34);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(170, 25);
            this.button10.TabIndex = 0;
            this.button10.Text = "Ledger";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.treeView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(238, 585);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tree";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            treeNode41.Name = "Node20";
            treeNode41.Text = "Investment Groups";
            treeNode42.Name = "Node19";
            treeNode42.Text = "Investments";
            treeNode43.Name = "Node2";
            treeNode43.Text = "Investors";
            treeNode44.Name = "Node21";
            treeNode44.Text = "Agent Groups";
            treeNode45.Name = "Node3";
            treeNode45.Text = "Agents";
            treeNode46.Name = "Node1";
            treeNode46.Text = "Contacts";
            treeNode47.Name = "Node8";
            treeNode47.Text = "Plots";
            treeNode48.Name = "Node7";
            treeNode48.Text = "Products";
            treeNode49.Name = "Node10";
            treeNode49.Text = "Deals";
            treeNode50.Name = "Node11";
            treeNode50.Text = "Financial Transactions";
            treeNode51.Name = "Node9";
            treeNode51.Text = "Transactions";
            treeNode52.Name = "Node14";
            treeNode52.Text = "Investment Groups";
            treeNode53.Name = "Node15";
            treeNode53.Text = "Agent Groups";
            treeNode54.Name = "Node13";
            treeNode54.Text = "Groups";
            treeNode55.Name = "Node26";
            treeNode55.Text = "Ledger";
            treeNode56.Name = "Node0";
            treeNode56.Text = "Reports";
            treeNode57.Name = "Node17";
            treeNode57.Text = "Investments";
            treeNode58.Name = "Node18";
            treeNode58.Text = "Investment Groups";
            treeNode59.Name = "Node16";
            treeNode59.Text = "Investments";
            treeNode60.Name = "Node0";
            treeNode60.Text = "Real Estate";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode60});
            this.treeView1.Size = new System.Drawing.Size(232, 579);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.MinimumSize = new System.Drawing.Size(2, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(12, 5);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(703, 611);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            this.tabControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 657);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Pak Zamin - Real Estate - v14.0.23107.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ToolStripMenuItem personsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem investorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agentGroupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem investmentGroupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem financialTransactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ledgerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dealsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Button button_Commissions;
    }
}