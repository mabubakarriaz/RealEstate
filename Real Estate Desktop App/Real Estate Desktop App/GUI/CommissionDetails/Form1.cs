using Com.RealEstate.Component.DataHelper;
using Com.RealEstate.Component.Entity;
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

namespace Com.RealEstate.DesktopApp.GUI.CommissionDetails
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            defaultValues();
        }

        Deal aDeal = new Deal();
        DealHandler aDealH = new DealHandler();
        ProductTransactionHandler aProductTransactionH = new ProductTransactionHandler();
        AgentGroupDetailHandler aAgentGroupDetailH = new AgentGroupDetailHandler();
        InvestmentGroupDetailHandler aInvestmentGroupDetailH = new InvestmentGroupDetailHandler();


        void defaultValues()
        {
            loadLists();
        }

        void loadLists() {

            var bindingSource2 = aDealH.GetList();

            comboBox_DealID.DataSource = bindingSource2;
            comboBox_DealID.DisplayMember = "Value";
            comboBox_DealID.ValueMember = "Key";
            comboBox_DealID.SelectedValue = -1;


            var bindingSource3 = aProductTransactionH.GetList();

            comboBox_TransactionID.DataSource = bindingSource3;
            comboBox_TransactionID.DisplayMember = "Value";
            comboBox_TransactionID.ValueMember = "Key";
            comboBox_TransactionID.SelectedValue = -1;

            comboBox_DeductionAmountType.DataSource = UtilityExtension.EnumArray<DeductionType>();
            comboBox_DeductionAmountType.SelectedIndex = 2;

            comboBox_CommissionRatioType.DataSource = UtilityExtension.EnumArray<RatioType>();
            comboBox_CommissionRatioType.SelectedIndex = 1;

            comboBox_GroupCheck.DataSource = UtilityExtension.EnumArray<GroupType>();
            comboBox_GroupCheck.SelectedIndex = 1;

        }

        void pointReferences() {
            label_DealID.Text = comboBox_DealID.SelectedValue.ToString();
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_DealID_SelectionChangeCommitted(object sender, EventArgs e)
        {

            
            aDeal.ID =Convert.ToInt32(comboBox_DealID.SelectedValue.ToString());
            
            label_DealID.Text =Convert.ToString(aDeal.ID);

            if (aDeal.ID>0)
            {
                aDeal=aDealH.GetItem(aDeal.ID);

                var bindingSource_ProductTransaction = aProductTransactionH.GetList(aDeal);
                comboBox_TransactionID.DataSource = bindingSource_ProductTransaction;
                comboBox_TransactionID.DisplayMember = "Value";
                comboBox_TransactionID.ValueMember = "Key";
                comboBox_TransactionID.SelectedValue = -1;
            }

        }

        private void comboBox_GroupCheck_SelectionChangeCommitted(object sender, EventArgs e)
        {

            if (comboBox_GroupCheck.SelectedIndex.ParseEnum<GroupType>() == GroupType.Agents)
            {
                if (aDeal.AgentGroupID > 0)
                {
                    listView_.Items.Clear();
                    listView_.Columns.Clear();

                    listView_.Columns.Add("Name", 100, HorizontalAlignment.Left);
                    listView_.Columns.Add("Amount", 100, HorizontalAlignment.Left);
                    listView_.Columns.Add("Percentage", 100, HorizontalAlignment.Left);
                    listView_.Columns.Add("Ratio Type", 100, HorizontalAlignment.Left);

                    List<ListViewItem> aListViewitems = aAgentGroupDetailH.GetListView(aDeal);
                    foreach (var item in aListViewitems)
                    {
                        listView_.Items.Add(item);
                    }
                }
            }
            else if (comboBox_GroupCheck.SelectedIndex.ParseEnum<GroupType>() == GroupType.Deals)
            {
                if (aDeal.ID>0)
                {
                    listView_.Items.Clear();
                    listView_.Columns.Clear();

                    listView_.Columns.Add("Transaction", 100, HorizontalAlignment.Left);
                    listView_.Columns.Add("Type", 100, HorizontalAlignment.Left);
                    listView_.Columns.Add("Transaction Amount", 100, HorizontalAlignment.Left);
                    listView_.Columns.Add("Deal Amount", 100, HorizontalAlignment.Left);

                    List<ListViewItem> aListViewitems = aProductTransactionH.GetListView(aDeal);
                    foreach (var item in aListViewitems)
                    {
                        listView_.Items.Add(item);
                    }
                }
            }
            else if (comboBox_GroupCheck.SelectedIndex.ParseEnum<GroupType>() == GroupType.Investments)
            {
                if (aDeal.InvestmentGroupID > 0)
                {
                    listView_.Items.Clear();
                    listView_.Columns.Clear();

                    listView_.Columns.Add("Name", 100, HorizontalAlignment.Left);
                    listView_.Columns.Add("InHand", 100, HorizontalAlignment.Left);
                    listView_.Columns.Add("BackUp", 100, HorizontalAlignment.Left);
                    listView_.Columns.Add("Total Amount", 100, HorizontalAlignment.Left);
                    listView_.Columns.Add("Contribution Percentage", 100, HorizontalAlignment.Left);
                    
                    List<ListViewItem> aListViewitems = aInvestmentGroupDetailH.GetListView(aDeal);
                    foreach (var item in aListViewitems)
                    {
                        listView_.Items.Add(item);
                    }
                }
            }


        }
    }
}
