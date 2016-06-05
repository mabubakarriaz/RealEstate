using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Com.RealEstate.DesktopApp.GUI;


namespace Com.RealEstate.DesktopApp.GUI
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                GUI.ProductDetails.Add_Product form = new ProductDetails.Add_Product();

                TabPage myTabPage = new TabPage();

                form.TopLevel = false;
                tabControl1.Controls.Add(myTabPage);
                myTabPage.Controls.Add(form);

                tabControl1.SelectedTab = myTabPage;

                myTabPage.Text = "Product Management";
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Product Management",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { 
            GUI.ContactDetails.Form1 form = new ContactDetails.Form1();

            TabPage myTabPage = new TabPage();

            form.TopLevel = false;
            tabControl1.Controls.Add(myTabPage);
            myTabPage.Controls.Add(form);

            tabControl1.SelectedTab = myTabPage;

            myTabPage.Text = "Contact Managment";
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Contact Managment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                GUI.InvestorDetails.Form1 form = new InvestorDetails.Form1();

                TabPage myTabPage = new TabPage();

                form.TopLevel = false;
                tabControl1.Controls.Add(myTabPage);
                myTabPage.Controls.Add(form);

                tabControl1.SelectedTab = myTabPage;

                myTabPage.Text = "Investor Management";
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Investor Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                GUI.InvestmentDetails.Form1 form = new InvestmentDetails.Form1();

                TabPage myTabPage = new TabPage();

                form.TopLevel = false;
                tabControl1.Controls.Add(myTabPage);
                myTabPage.Controls.Add(form);

                tabControl1.SelectedTab = myTabPage;

                myTabPage.Text = "Investment Management";
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Investment Managment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                GUI.AgentDetails.Form1 form = new AgentDetails.Form1();

                TabPage myTabPage = new TabPage();

                form.TopLevel = false;
                tabControl1.Controls.Add(myTabPage);
                myTabPage.Controls.Add(form);

                tabControl1.SelectedTab = myTabPage;

                myTabPage.Text = "Agent Management";
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Agent Managment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                GUI.FinancialTransactionDetails.Form1 form = new FinancialTransactionDetails.Form1();

                TabPage myTabPage = new TabPage();

                form.TopLevel = false;
                tabControl1.Controls.Add(myTabPage);
                myTabPage.Controls.Add(form);

                tabControl1.SelectedTab = myTabPage;

                myTabPage.Text = "Financial Transaction Management";
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Financial Transaction Managment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                GUI.InvestmentDetails.Form2 form = new InvestmentDetails.Form2();

                TabPage myTabPage = new TabPage();

                form.TopLevel = false;
                tabControl1.Controls.Add(myTabPage);
                myTabPage.Controls.Add(form);

                tabControl1.SelectedTab = myTabPage;

                myTabPage.Text = "Investment Group Managment";
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Investment Group Managment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                GUI.ProductTransactionDetails.Form1 form = new ProductTransactionDetails.Form1();

                TabPage myTabPage = new TabPage();

                form.TopLevel = false;
                tabControl1.Controls.Add(myTabPage);
                myTabPage.Controls.Add(form);

                tabControl1.SelectedTab = myTabPage;

                myTabPage.Text = "Product Transaction Management";
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Product Transaction Managment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                GUI.AgentDetails.Form2 form = new AgentDetails.Form2();

                TabPage myTabPage = new TabPage();

                form.TopLevel = false;
                tabControl1.Controls.Add(myTabPage);
                myTabPage.Controls.Add(form);

                tabControl1.SelectedTab = myTabPage;

                myTabPage.Text = "Agent Group Management";
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.Show();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Agent Group Managment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                GUI.Reports.Form1 form = new Reports.Form1();

                TabPage myTabPage = new TabPage();

                form.TopLevel = false;
                tabControl1.Controls.Add(myTabPage);
                myTabPage.Controls.Add(form);

                tabControl1.SelectedTab = myTabPage;

                myTabPage.Text = "Ledger Report";
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.Show();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ledger Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region TabCloseButton
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Rectangle r = e.Bounds;
            r = tabControl1.GetTabRect(e.Index);
            r.Offset(2, 2);
            r.Width = 5;
            r.Height = 5;
            Brush b = new SolidBrush(Color.Black);
            Pen p = new Pen(b);
            e.Graphics.DrawLine(p, r.X, r.Y, r.X + r.Width, r.Y + r.Height);
            e.Graphics.DrawLine(p, r.X + r.Width, r.Y, r.X, r.Y + r.Height);

            string title = tabControl1.TabPages[e.Index].Text;
            Font f = this.Font;
            e.Graphics.DrawString(title, f, b, new PointF(e.Bounds.Left +8, r.Y+3));
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            for (int i = 0; i < tabControl1.TabCount; i++)
            {
                Rectangle r = tabControl1.GetTabRect(i);
                r.Offset(2, 2);
                r.Width = 5;
                r.Height = 5;
                if (r.Contains(p))
                {
                    tabControl1.TabPages.Remove(tabControl1.TabPages[i]);
                }
            }
        }





        #endregion TabCloseButton

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name=="Node1")
            {
                //Contacts
                button2_Click(sender, e);
            }
            else if (e.Node.Name == "Node2")
            {
                //Investors
                button3_Click(sender, e);
            }
            else if (e.Node.Name == "Node20")
            {
                //Investment Group
                button7_Click(sender, e);
            }
            else if (e.Node.Name == "Node19")
            {
                //Investment
                button4_Click(sender, e);
            }
            else if (e.Node.Name == "Node3")
            {
                //Agents
                button5_Click(sender, e);
            }
            else if (e.Node.Name == "Node21")
            {
                //Agent Group
                button9_Click(sender, e);
            }
            else if (e.Node.Name == "Node7")
            {
                //Products
                button1_Click(sender, e);
            }
            else if (e.Node.Name == "Node8")
            {
                //Products
                button1_Click(sender, e);
            }
            else if (e.Node.Name == "Node9")
            {
                //Products Transactions
                button8_Click(sender, e);
            }
            else if (e.Node.Name == "Node10")
            {
                //Products Transactions
                button8_Click(sender, e);
            }
            else if (e.Node.Name == "Node11")
            {
                //Financial Transactions
                button6_Click(sender, e);
            }
            else if (e.Node.Name == "Node14")
            {
                //Investment Group
                button7_Click(sender, e);
            }
            else if (e.Node.Name == "Node15")
            {
                //Agent Group
                button9_Click(sender, e);
            }
            else if (e.Node.Name == "Node17")
            {
                //Investments
                button4_Click(sender, e);
            }
            else if (e.Node.Name == "Node18")
            {
                //Investments Groups
                button7_Click(sender, e);
            }
            else if (e.Node.Name == "Node26")
            {
                //Ledger Reports
                button10_Click(sender, e);
            }

        }

      

        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {

           DialogResult buttonPressed= MessageBox.Show("Are you sure you want to close this application?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (buttonPressed==DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void contactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void agentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button5_Click(sender, e);
        }

        private void investorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void agentGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button9_Click(sender, e);
        }

        private void investmentGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button7_Click(sender, e);
        }

        private void financialTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button6_Click(sender, e);
        }

        private void ledgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button10_Click(sender, e);
        }

        private void dealsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button8_Click(sender, e);
        }

        private void button_Commissions_Click(object sender, EventArgs e)
        {
            try
            {
                GUI.CommissionDetails.Form1 form = new CommissionDetails.Form1();

                TabPage myTabPage = new TabPage();

                form.TopLevel = false;
                tabControl1.Controls.Add(myTabPage);
                myTabPage.Controls.Add(form);

                tabControl1.SelectedTab = myTabPage;

                myTabPage.Text = "Commission Management";
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Commission Management - Unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
