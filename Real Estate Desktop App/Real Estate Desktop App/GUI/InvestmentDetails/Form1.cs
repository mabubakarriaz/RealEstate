using Com.RealEstate.Component.Entity;
using Com.RealEstate.Component.DataHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Com.RealEstate.Component.Handler;
using Com.RealEstate.Component.Exceptions;

namespace Com.RealEstate.DesktopApp.GUI.InvestmentDetails
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            defaultValues();
        }

        Investor anInvestor = new Investor();
        InvestorHandler InvestorH = new InvestorHandler();
        Investment anInvestment = new Investment();
        InvestmentHandler InvestmentH = new InvestmentHandler();

        void defaultValues() {

            var bindingSource = InvestorH.GetList();

            comboBox_InvestorID.DataSource = bindingSource;
            comboBox_InvestorID.DisplayMember = "Value";
            comboBox_InvestorID.ValueMember = "Key";
            comboBox_InvestorID.SelectedValue = -1;

            label_Add.Text = "0";
            label_InvestorID.Text = "0";

            textBox_Name.Text = "";
            textBox_InHand.Text = "0";
            textBox_BackUp.Text = "0";
            textBox_TotalAmount.Text = "0";
        }

        void pointReferences() {

            anInvestment.ID = Convert.ToInt32(label_Add.Text);
            anInvestor.ID = Convert.ToInt32(label_InvestorID.Text);
            anInvestment.InvestorDetails = anInvestor;
            anInvestment.Name = textBox_Name.Text;
            anInvestment.InHand = Convert.ToDouble(textBox_InHand.Text);
            anInvestment.BackUp = Convert.ToDouble(textBox_BackUp.Text);
            anInvestment.TotalAmount = Convert.ToDouble(textBox_TotalAmount.Text);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                pointReferences();
                anInvestment.ID = InvestmentH.Add(anInvestment);

                label_Add.Text = Convert.ToString(anInvestment.ID);


                MessageBox.Show("Added", "Investment Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Entry Error - Unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void textBox1_Leave(object sender, EventArgs e)
        {
            pointReferences();
            textBox_BackUp.Text = Convert.ToString(anInvestment.GetBackupAmount());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var bindingList = InvestmentH.Show(anInvestment);
                var source = new BindingSource(bindingList, null);
                dataGridView_.DataSource = source;
            }
            catch (DataExistence ex)
            {
                MessageBox.Show(ex.Message, "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Entry Error - Unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label_InvestorID.Text = comboBox_InvestorID.SelectedValue.ToString();
            textBox_Name.Text = comboBox_InvestorID.Text.ToString();
        }
    }
}
