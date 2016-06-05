using Com.RealEstate.Component.Entity;
using Com.RealEstate.Component.Exceptions;
using Com.RealEstate.Component.Handler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Com.RealEstate.DesktopApp.GUI.InvestmentDetails
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            defaultValues();
        }

        Investment anInvestment = new Investment();
        Investment anInvestmentDiff = new Investment();

        InvestmentHandler InvestmentH = new InvestmentHandler();
        InvestmentGroup anInvestmentGroup = new InvestmentGroup();
        InvestmentGroupHandler investmentGroupH = new InvestmentGroupHandler();

        InvestmentGroupDetail anInvestmentGroupDetail = new InvestmentGroupDetail();
        InvestmentGroupDetailHandler InvestmentGroupDetailH = new InvestmentGroupDetailHandler();


        void defaultValues()
        {

            textBox_Name.Text = "0";
            label4.Text = "0";
            label9.Text = "0";
            label11.Text = "0";

            textBox_InHand_Member.Text = "0";
            textBox_BackUp_Member.Text = "0";
            textBox_TotalAmount_Member.Text = "0";

            loadLists();

        }

        void loadLists() {

            var bindingSource = investmentGroupH.GetList();

            comboBox_InvestmentGroupID.DataSource = bindingSource;
            comboBox_InvestmentGroupID.DisplayMember = "Value";
            comboBox_InvestmentGroupID.ValueMember = "Key";
            comboBox_InvestmentGroupID.SelectedValue = -1;

            var bindingSource2 = InvestmentH.GetList();

            comboBox_InvestmentID.DataSource = bindingSource2;
            comboBox_InvestmentID.DisplayMember = "Value";
            comboBox_InvestmentID.ValueMember = "Key";
            comboBox_InvestmentID.SelectedValue = -1;

        }
        void pointReferences()
        {
            anInvestmentGroup.Name = textBox_Name.Text;
            anInvestmentGroup.ID = Convert.ToInt32(label9.Text);

            investmentGroupH.DataInserted += Event_DataInserted;
            InvestmentGroupDetailH.DataInserted += Event_DataInserted;


            anInvestment.Inhand_Remaining = Convert.ToDouble(textBox_InHand_Member.Text);
            anInvestment.BackUp_Remaining = Convert.ToDouble(textBox_BackUp_Member.Text);
            anInvestment.TotalAmount_Remaining = Convert.ToDouble(textBox_TotalAmount_Member.Text);

            anInvestmentGroupDetail.InvestmentGroupID = anInvestmentGroup.ID;
            anInvestmentGroupDetail.InvestmentID = anInvestment.ID;
            anInvestmentGroupDetail.InHand = anInvestment.Inhand_Remaining;
            anInvestmentGroupDetail.BackUp = anInvestment.BackUp_Remaining;
            anInvestmentGroupDetail.TotalAmount = anInvestment.TotalAmount_Remaining;


        }


        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            try
            {
                pointReferences();
                anInvestmentGroup.ID = investmentGroupH.Add(anInvestmentGroup);
                label4.Text = Convert.ToString(anInvestmentGroup.ID);

                MessageBox.Show("Added", "Investment Group Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Entry Error - Unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Event_DataInserted(object sender, EventArgs e)
        {
            //MessageBox.Show("Added","Data Entry Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //e.Handled = true;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label9.Text=comboBox_InvestmentGroupID.SelectedValue.ToString();

            if (Convert.ToInt32(label9.Text)>0)
            {
                anInvestmentGroup.ID = Convert.ToInt32(label9.Text);
                anInvestmentGroup = investmentGroupH.Show(anInvestmentGroup.ID);

                textBox_InHand_Group.Text = Convert.ToString(anInvestmentGroup.InHand);
                textBox_BackUp_Group.Text = Convert.ToString(anInvestmentGroup.BackUp);
                textBox_TotalAmount_Group.Text = Convert.ToString(anInvestmentGroup.TotalAmount);
            }

        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label11.Text = comboBox_InvestmentID.SelectedValue.ToString();

            if (Convert.ToInt32(label11.Text)>0)
            {
                anInvestment.ID = Convert.ToInt32(label11.Text);
                anInvestment = InvestmentH.Show(anInvestment.ID);

                textBox_InHand_Member.Text = Convert.ToString(anInvestment.Inhand_Remaining);
                textBox_BackUp_Member.Text = Convert.ToString(anInvestment.BackUp_Remaining);
                textBox_TotalAmount_Member.Text = Convert.ToString(anInvestment.TotalAmount_Remaining);

                anInvestmentDiff.Inhand_Remaining = anInvestment.Inhand_Remaining;
                anInvestmentDiff.TotalAmount_Remaining = anInvestment.TotalAmount_Remaining;

            }

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            pointReferences();
            textBox_BackUp_Member.Text = Convert.ToString(anInvestment.GetBackupAmount_Remaining());
            InvestmentDiffCalculate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pointReferences();

            try
            {
                InvestmentGroupDetailH.Add(anInvestmentGroupDetail);
                MessageBox.Show("Added", "Data Entry Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Investment addition error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Investment addition error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                InvestmentGroupDetailH.Accumulate(anInvestmentGroup.ID);
                anInvestmentGroup = investmentGroupH.Show(anInvestmentGroup.ID);

                textBox_InHand_Group.Text = Convert.ToString(anInvestmentGroup.InHand);
                textBox_BackUp_Group.Text = Convert.ToString(anInvestmentGroup.BackUp);
                textBox_TotalAmount_Group.Text = Convert.ToString(anInvestmentGroup.TotalAmount);

                MessageBox.Show("Accumulation Done!", "Investment Group Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Entry Error - Unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void InvestmentDiffCalculate() {

            label_InHand_Member.Text = Convert.ToString(anInvestmentDiff.Inhand_Remaining - Convert.ToDouble(textBox_InHand_Member.Text));
            
            label_TotalAmount_Member.Text = Convert.ToString(anInvestmentDiff.TotalAmount_Remaining - Convert.ToDouble(textBox_TotalAmount_Member.Text));

            if (Convert.ToInt32(label_InHand_Member.Text) < 0)
            {
                label_InHand_Member.ForeColor = Color.Red;
            }
            else {
                label_InHand_Member.ForeColor = Color.Green;
            }


            if (Convert.ToInt32(label_TotalAmount_Member.Text) < 0)
            {
                label_TotalAmount_Member.ForeColor = Color.Red;
            }
            else
            {
                label_TotalAmount_Member.ForeColor = Color.Green;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            

            try
            {
                InvestmentGroupDetailH.DeductFinancialTransaction(anInvestmentGroup.ID);

                MessageBox.Show("Deduction Done", "Data Entry Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Entry Error - Unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                var bindingList = investmentGroupH.Show(anInvestmentGroup);
                var source = new BindingSource(bindingList, null);
                dataGridView_Group.DataSource = source;
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

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                pointReferences();

                if (Convert.ToInt32(label9.Text) > 0)
                {
                    InvestmentGroup aInvestmentGroup = new InvestmentGroup();
                    aInvestmentGroup.ID = anInvestmentGroupDetail.InvestmentGroupID;
                    var bindingList = InvestmentGroupDetailH.Show(aInvestmentGroup);
                    var source = new BindingSource(bindingList, null);
                    dataGridView_Member.DataSource = source;
                }
                else
                {
                    MessageBox.Show("Please Select an Investment Group to show investment details against it.", "Investment Group Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                pointReferences();
                DialogResult ButtonPressed = MessageBox.Show("Are you sure you want to delete the selected record?", "Data Entry Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);

                if (ButtonPressed == DialogResult.Yes)
                {
                    anInvestment.ID = Convert.ToInt32(label10.Text);

                    investmentGroupH.Remove(anInvestment.ID);

                    MessageBox.Show("Removed", "Data Entry Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //refresh
                    button5_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Entry Error - Unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label10.Text = dataGridView_Group.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
                //do nothing
            }
        }

        void resetControls() {

            textBox_Name.Clear();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            resetControls();
        }
    }
}
