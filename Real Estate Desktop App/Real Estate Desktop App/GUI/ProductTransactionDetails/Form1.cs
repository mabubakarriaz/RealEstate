using Com.RealEstate.Component.DataHelper;
using Com.RealEstate.Component.Entity;
using Com.RealEstate.Component.Exceptions;
using Com.RealEstate.Component.ExtensionMethods;
using Com.RealEstate.Component.Handler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Com.RealEstate.DesktopApp.GUI.ProductTransactionDetails
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            defaultValues();
        }

        InvestmentGroup anInvestmentGroup = new InvestmentGroup();
        InvestmentGroupHandler aInvestmentGroupH = new InvestmentGroupHandler();
        ProductHandler aProductH = new ProductHandler();
        AgentGroupHandler aAgentGroupH = new AgentGroupHandler();
        ContactHandler aContactH = new ContactHandler();
        DealHandler aDealH = new DealHandler();
        Deal aDeal = new Deal();

        ProductTransaction aProductTransaction = new ProductTransaction();
        ProductTransactionHandler aProductTransactionH = new ProductTransactionHandler();

        void defaultValues()
        {
            loadLists();
        }

        void loadLists() {

            comboBox_TransactionType.DataSource = UtilityExtension.EnumArray<ProductTransactionType>();
            comboBox_TransactionType.SelectedIndex = 0;

            comboBox_AmountType.DataSource = UtilityExtension.EnumArray<AmountType>();
            comboBox_AmountType.SelectedIndex = 0;
            
            comboBox_NextAmountType.DataSource = UtilityExtension.EnumArray<AmountType>();
            comboBox_NextAmountType.SelectedIndex = 1;

            var bindingSource2 = aProductH.GetList();

            comboBox_ProductID.DataSource = bindingSource2;
            comboBox_ProductID.DisplayMember = "Value";
            comboBox_ProductID.ValueMember = "Key";
            comboBox_ProductID.SelectedValue = -1;

            var bindingSource = aInvestmentGroupH.GetList();

            comboBox_InvestmentGroupID.DataSource = bindingSource;
            comboBox_InvestmentGroupID.DisplayMember = "Value";
            comboBox_InvestmentGroupID.ValueMember = "Key";
            comboBox_InvestmentGroupID.SelectedValue = -1;

            var bindingSource3 = aAgentGroupH.GetList();

            comboBox_AgentGroupID.DataSource = bindingSource3;
            comboBox_AgentGroupID.DisplayMember = "Value";
            comboBox_AgentGroupID.ValueMember = "Key";
            comboBox_AgentGroupID.SelectedValue = -1;

            var bindingSource5 = aDealH.GetList();

            comboBox_DealID.DataSource = bindingSource5;
            comboBox_DealID.DisplayMember = "Value";
            comboBox_DealID.ValueMember = "Key";
            comboBox_DealID.SelectedValue = -1;

            var bindingSource4 = aContactH.GetList();

            comboBox_PartyBID.DataSource = bindingSource4;
            comboBox_PartyBID.DisplayMember = "Value";
            comboBox_PartyBID.ValueMember = "Key";
            comboBox_PartyBID.SelectedValue = -1;
        }

        void pointReferences_Deal()
        {

            aDeal.Name = comboBox_AgentGroupID.Text + "-" + comboBox_ProductID.Text + "-" + "Deal";
            aDeal.ProductID = Convert.ToInt32(label_ProductID.Text);
            aDeal.InvestmentGroupID = Convert.ToInt32(label_InvestmentGroupID.Text);
            aDeal.AgentGroupID = Convert.ToInt32(label_AgentGroupID.Text);
            aDeal.PurchaseAmount =Convert.ToDouble(numericUpDown_PurchaseAmount.Value);
            aDeal.SaleAmount = Convert.ToDouble(numericUpDown_SaleAmount.Value);
        }
        void pointReferences_Transaction()
        {

            aProductTransaction.DealID = Convert.ToInt32(label_DealID.Text);
            aProductTransaction.TransactionType = comboBox_TransactionType.SelectedIndex.ParseEnum<ProductTransactionType>();
            aProductTransaction.TransactionDate = dateTimePicker_TransactionDate.Value;
            aProductTransaction.DealAmount = Convert.ToDouble(numericUpDown_PurchaseAmount.Value);
            aProductTransaction.PartyBID = Convert.ToInt32(label_PartyBID.Text);

            aProductTransaction.TransactionAmountType = comboBox_AmountType.SelectedIndex.ParseEnum<AmountType>();
            aProductTransaction.TransactionAmount = Convert.ToDouble(numericUpDown_Amount.Value);
            aProductTransaction.Conditional = radioButton_Conditional.Checked;
            aProductTransaction.BalanceAmount = Convert.ToDouble(numericUpDown_BalanceAmount.Value);
            aProductTransaction.DocumentReference = Convert.ToInt32(textBox_DocumentReference.Text);

            aProductTransaction.HasNextTransaction = checkBox_HasNextTransaction.Checked;
            aProductTransaction.NextTransactionAmountType = comboBox_NextAmountType.SelectedIndex.ParseEnum<AmountType>();
            aProductTransaction.NextTransactionAmount = Convert.ToDouble(numericUpDown_NextAmount.Value);
            aProductTransaction.NextTransactionDueDate = dateTimePicker_NextDueDate.Value;

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label_ProductID.Text = comboBox_ProductID.SelectedValue.ToString();
        }
        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label_InvestmentGroupID.Text = comboBox_InvestmentGroupID.SelectedValue.ToString();
            if (Convert.ToInt32(label_InvestmentGroupID.Text) > 0)
            {
                anInvestmentGroup.ID = Convert.ToInt32(label_InvestmentGroupID.Text);
                anInvestmentGroup = aInvestmentGroupH.GetItem(anInvestmentGroup.ID);

                //label16.Text = Convert.ToString(anInvestmentGroup.TotalAmount);
                label_Amount.Text = Convert.ToString(anInvestmentGroup.InHand);
            }
            else
            {
                //label16.Text = "0";
                label_Amount.Text = "0";
            }
        }
        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label_AgentGroupID.Text = comboBox_AgentGroupID.SelectedValue.ToString();
        }
        private void comboBox_DealID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label_DealID.Text = comboBox_DealID.SelectedValue.ToString();
            aDeal.ID = Convert.ToInt32(label_DealID.Text);

            if (aDeal.ID>0)
            {
                aDeal = aDealH.GetItem(aDeal.ID);

                if (comboBox_TransactionType.SelectedIndex.ParseEnum<ProductTransactionType>() == ProductTransactionType.Purchase)
                {
                    numericUpDown_FullAmount.Value = Convert.ToDecimal(aDeal.PurchaseAmount);
                    numericUpDown_BalanceAmount.Value = Convert.ToDecimal(aDeal.PurchaseAmount_Remaining);
                    label_Amount.Text= Convert.ToString(aDeal.PurchaseAmount_Remaining);
                }
                else if (comboBox_TransactionType.SelectedIndex.ParseEnum<ProductTransactionType>() == ProductTransactionType.Sale)
                {
                    numericUpDown_FullAmount.Value = Convert.ToDecimal(aDeal.SaleAmount);
                    numericUpDown_BalanceAmount.Value = Convert.ToDecimal(aDeal.SaleAmount_Remaining);
                    label_Amount.Text = Convert.ToString(aDeal.SaleAmount_Remaining);
                }
            }
            
        }
        private void comboBox_PartyBID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label_PartyBID.Text = comboBox_PartyBID.SelectedValue.ToString();
        }
        private void comboBox8_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label4.Text = comboBox_AmountType.Text + " Amount:";
            //Token
            if (comboBox_AmountType.SelectedIndex == 0)
            {
                comboBox_NextAmountType.SelectedIndex = 1;
                radioButton_Conditional.Checked = true;
                checkBox_HasNextTransaction.Checked = true;
            }
            //Biyana
            else if (comboBox_AmountType.SelectedIndex == 1)
            {
                comboBox_NextAmountType.SelectedIndex = 2;
                radioButton_Confirm.Checked = true;
                checkBox_HasNextTransaction.Checked = true;
            }
            // Transfer
            else if (comboBox_AmountType.SelectedIndex == 2)
            {
                radioButton_Confirm.Checked = true;
                checkBox_HasNextTransaction.Checked = false;
            }

        }
        private void comboBox9_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label16.Text = comboBox_NextAmountType.Text + " Amount:";
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                pointReferences_Transaction();

                    aProductTransaction.ID = aProductTransactionH.Add(aProductTransaction);
                    label_Add_Deal.Text = Convert.ToString(aProductTransaction.ID);
                    MessageBox.Show("Added", "Product Transaction Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Product Transaction Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                pointReferences_Deal();

                    aDeal.ID = aDealH.Add(aDeal);
                    label_Add_Deal.Text = Convert.ToString(aDeal.ID);
                    MessageBox.Show("Added", "Deal Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Product Transaction Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var bindingList = aDealH.Show(aDeal);
                var source = new BindingSource(bindingList, null);
                dataGridView_Deal.DataSource = source;
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
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var bindingList = aProductTransactionH.Show(aProductTransaction);
                var source = new BindingSource(bindingList, null);
                dataGridView_Transaction.DataSource = source;
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
        private void button7_Click(object sender, EventArgs e)
        {
            loadLists();
        }

        private void numericUpDown_Amount_ValueChanged(object sender, EventArgs e)
        {
            if (comboBox_TransactionType.SelectedIndex.ParseEnum<ProductTransactionType>() == ProductTransactionType.Sale)
            {
                label_Amount.Text = Convert.ToString(aDeal.SaleAmount_Remaining - Convert.ToDouble(numericUpDown_Amount.Value));
            }
            else if (comboBox_TransactionType.SelectedIndex.ParseEnum<ProductTransactionType>() == ProductTransactionType.Purchase)
            {
                label_Amount.Text = Convert.ToString(aDeal.PurchaseAmount_Remaining - Convert.ToDouble(numericUpDown_Amount.Value));
            }


            numericUpDown_NextAmount_ValueChanged(sender, e);
            numericUpDown_BalanceAmount.Value = Convert.ToDecimal(label_Amount.Text);

            if (Convert.ToDouble(label_Amount.Text)>0)
            {
                label_Amount.ForeColor = Color.Green;
            }
            else if (Convert.ToDouble(label_Amount.Text) < 0)
            {
                label_Amount.ForeColor = Color.Red;
            }


        }

        private void numericUpDown_NextAmount_ValueChanged(object sender, EventArgs e)
        {
            label_NextAmount.Text = Convert.ToString(Convert.ToDouble(label_Amount.Text) - Convert.ToDouble(numericUpDown_NextAmount.Value));

            if (Convert.ToDouble(label_NextAmount.Text) > 0)
            {
                label_NextAmount.ForeColor = Color.Green;
            }
            else if (Convert.ToDouble(label_NextAmount.Text) < 0)
            {
                label_NextAmount.ForeColor = Color.Red;
            }
        }
    }
}
