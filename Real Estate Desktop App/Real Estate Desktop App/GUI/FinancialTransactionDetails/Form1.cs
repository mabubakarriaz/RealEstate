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

namespace Com.RealEstate.DesktopApp.GUI.FinancialTransactionDetails
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            defaultValues();
            LoadLists();
            
        }

        ContactHandler ContactH = new ContactHandler();
        InvestmentHandler InvestmentH = new InvestmentHandler();
        FinancialTransaction aFinancialTransaction = new FinancialTransaction();
        FinancialTransactionHandler FinancialTransactionH = new FinancialTransactionHandler();
        InvestmentGroupDetailHandler InvestmentGroupDetailH = new InvestmentGroupDetailHandler();

        public void LoadLists()
        {
            var bindingSource = ContactH.GetList();

            comboBox_ContactID.DataSource = bindingSource;
            comboBox_ContactID.DisplayMember = "Value";
            comboBox_ContactID.ValueMember = "Key";
            comboBox_ContactID.SelectedValue = -1;

            var bindingSource2 = InvestmentH.GetList();

            comboBox_WalletReference.DataSource = bindingSource2;
            comboBox_WalletReference.DisplayMember = "Value";
            comboBox_WalletReference.ValueMember = "Key";
            comboBox_WalletReference.SelectedValue = -1;


        }
        void defaultValues() {

           
            textBox_Amount.Text = "0";

            comboBox_TransactionType.DataSource = UtilityExtension.EnumArray<TransactionType>();
            comboBox_TransactionType.SelectedIndex = 0;

            comboBox_WalletType.DataSource = UtilityExtension.EnumArray<WalletType>();
            comboBox_WalletType.SelectedIndex = 0;

            comboBox_FlowType.DataSource = UtilityExtension.EnumArray<FlowType>();
            comboBox_FlowType.SelectedIndex = 0;

            //comboBox5.SelectedIndex = 0;

            checkBox_CascadeChanges.Checked = true;
           
        }

        void pointReferences() {

            aFinancialTransaction.Amount = Convert.ToInt32(textBox_Amount.Text);
            aFinancialTransaction.TransactionType= comboBox_TransactionType.SelectedIndex.ParseEnum<TransactionType>();
            aFinancialTransaction.TransactionReference = textBox_TransactionReference.Text;
            aFinancialTransaction.TransactionDate = dateTimePicker_TransactionDate.Value;
            aFinancialTransaction.ContactID=Convert.ToInt32(comboBox_ContactID.SelectedValue.ToString());
            aFinancialTransaction.WalletType = comboBox_WalletType.SelectedIndex.ParseEnum<WalletType>();
            aFinancialTransaction.WalletReference= Convert.ToInt32(comboBox_WalletReference.SelectedValue.ToString());
            aFinancialTransaction.FlowType = comboBox_FlowType.SelectedIndex.ParseEnum<FlowType>();
            aFinancialTransaction.CascadeChanges = checkBox_CascadeChanges.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                pointReferences();
                aFinancialTransaction.ID = new FinancialTransactionHandler().Add(aFinancialTransaction);

                label_Add.Text = Convert.ToString(aFinancialTransaction.ID);

                MessageBox.Show("Added", "Financial Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Entry Error - Unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            pointReferences();
            BindingSource bindingSource;
            Investor anInvestor = new Investor();
            anInvestor.ID = aFinancialTransaction.ContactID;


            if (aFinancialTransaction.WalletType == WalletType.Investment)
            {
                    
                try
                {

                    bindingSource = InvestmentH.GetList(anInvestor);
                    comboBox_WalletReference.DataSource = bindingSource;
                    comboBox_WalletReference.DisplayMember = "Value";
                    comboBox_WalletReference.ValueMember = "Key";
                    comboBox_WalletReference.SelectedValue = -1;
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("No Investment found");
                    comboBox_WalletReference.SelectedValue = -1;
                }

            }
            else if (aFinancialTransaction.WalletType == WalletType.InvestmentGroup)
            {
                comboBox_TransactionType.SelectedIndex = 4;
                try
                {

                    bindingSource = InvestmentGroupDetailH.GetList(anInvestor);
                    comboBox_WalletReference.DataSource = bindingSource;
                    comboBox_WalletReference.DisplayMember = "Value";
                    comboBox_WalletReference.ValueMember = "Key";
                    comboBox_WalletReference.SelectedValue = -1;
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("No Investment Group found");
                    comboBox_WalletReference.SelectedValue = -1;
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var bindingList = FinancialTransactionH.Show(aFinancialTransaction);
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

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label12.Text = comboBox_ContactID.SelectedValue.ToString();
        }

        private void comboBox5_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label14.Text = comboBox_WalletReference.SelectedValue.ToString();
        }

        
    }
}
