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

namespace Com.RealEstate.DesktopApp.GUI.AgentDetails
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            defaultValues();
        }

        ContactHandler ContactH = new ContactHandler();
        Agent anAgent = new Agent();
        AgentHandler AgentH = new AgentHandler();

        void defaultValues()
        {

            loadLists();
            label_ContactID.Text = "0";
            textBox_Name.Text = "";

            comboBox_ContributionRatioType.SelectedIndex = (int)anAgent.ContributionRatioType;
            comboBox_CommissionRatioType.SelectedIndex = (int)anAgent.CommissionRatioType;
            comboBox_SalaryRatioType.SelectedIndex = (int)anAgent.SalaryRatioType;
            comboBox_AgentType.SelectedIndex = (int)anAgent.AgentType;


            checkBox_IsContributer.Checked = anAgent.IsContributer;
            checkBox_IsOnCommission.Checked = anAgent.IsOnCommission;
            checkBox_IsOnSalary.Checked = anAgent.IsOnSalary;

            numericUpDown_ContributionPercentage.Value = anAgent.ContributionPercentage;
            numericUpDown_CommissionPercentage.Value = anAgent.CommissionPercentage;
            numericUpDown_SalaryPercentage.Value = anAgent.SalaryPercentage;

            numericUpDown_ContributionAmount.Value = Convert.ToDecimal(anAgent.ContributionAmount);
            numericUpDown_ContributionAmount.Maximum = decimal.MaxValue;

            numericUpDown_CommissionAmount.Value = Convert.ToDecimal(anAgent.CommissionAmount);
            numericUpDown_CommissionAmount.Maximum = decimal.MaxValue;

            numericUpDown_SalaryAmount.Value = Convert.ToDecimal(anAgent.SalaryAmount);
            numericUpDown_SalaryAmount.Maximum = decimal.MaxValue;

        }
        void loadLists() {

            var bindingSource = ContactH.GetList();
            comboBox_ContactID.DataSource = bindingSource;
            comboBox_ContactID.DisplayMember = "Value";
            comboBox_ContactID.ValueMember = "Key";
            comboBox_ContactID.SelectedValue = -1;
            

            comboBox_ContributionRatioType.DataSource = UtilityExtension.EnumArray<RatioType>();
            comboBox_CommissionRatioType.DataSource = UtilityExtension.EnumArray<RatioType>();
            comboBox_SalaryRatioType.DataSource = UtilityExtension.EnumArray<RatioType>();
            comboBox_AgentType.DataSource = UtilityExtension.EnumArray<AgentType>();

        }


        void pointReferences()
        {

            anAgent.ID = Convert.ToInt32(label_ContactID.Text);
            anAgent.Name = textBox_Name.Text;

            anAgent.AgentType = comboBox_AgentType.SelectedIndex.ParseEnum<AgentType>();

            anAgent.IsContributer = checkBox_IsContributer.Checked;
            anAgent.ContributionAmount = Convert.ToDouble(numericUpDown_ContributionAmount.Value);
            anAgent.ContributionPercentage = numericUpDown_ContributionPercentage.Value;
            anAgent.ContributionRatioType = comboBox_ContributionRatioType.SelectedIndex.ParseEnum<RatioType>();

            anAgent.IsOnCommission = checkBox_IsOnCommission.Checked;
            anAgent.CommissionAmount = Convert.ToDouble(numericUpDown_CommissionAmount.Value);
            anAgent.CommissionPercentage =  numericUpDown_CommissionPercentage.Value;
            anAgent.CommissionRatioType= comboBox_CommissionRatioType.SelectedIndex.ParseEnum<RatioType>();

            anAgent.IsOnSalary = checkBox_IsOnSalary.Checked;
            anAgent.SalaryAmount = Convert.ToDouble(numericUpDown_SalaryAmount.Value);
            anAgent.SalaryPercentage =  numericUpDown_SalaryPercentage.Value;
            anAgent.SalaryRatioType= comboBox_SalaryRatioType.SelectedIndex.ParseEnum<RatioType>();

        }


        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                pointReferences();
                anAgent.ID = AgentH.Add(anAgent);

                label_Add.Text = Convert.ToString(anAgent.ID);
                
                MessageBox.Show("Added", "Agent Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Entry Error - Unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var bindingList = AgentH.Show(anAgent);
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IsContributer.Checked)
            {
                radioButton_ContributionAmount.Enabled = true;
                radioButton_ContributionPercentage.Enabled = true;

                comboBox_ContributionRatioType.Enabled = true;
                comboBox_ContributionRatioType.SelectedIndex = 0;
            }
            else 
            {
                radioButton_ContributionAmount.Checked = true;
                radioButton_ContributionAmount.Checked = false;
                radioButton_ContributionPercentage.Checked = true;
                radioButton_ContributionPercentage.Checked = false;

                radioButton_ContributionAmount.Enabled = false;
                radioButton_ContributionPercentage.Enabled = false;

                numericUpDown_ContributionAmount.Value = 0;
                numericUpDown_ContributionPercentage.Value = 0;
                comboBox_ContributionRatioType.Enabled = false;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IsOnCommission.Checked)
            {
                radioButton_CommissionAmount.Enabled = true;
                radioButton_CommissionPercentage.Enabled = true;

                comboBox_CommissionRatioType.Enabled = true;
                comboBox_CommissionRatioType.SelectedIndex = 0;
            }
            else
            {
                radioButton_CommissionAmount.Checked = true;
                radioButton_CommissionAmount.Checked = false;
                radioButton_CommissionPercentage.Checked = true;
                radioButton_CommissionPercentage.Checked = false;
                

                radioButton_CommissionAmount.Enabled = false;
                radioButton_CommissionPercentage.Enabled = false;

                numericUpDown_CommissionAmount.Value = 0;
                numericUpDown_CommissionPercentage.Value = 0;
                comboBox_CommissionRatioType.Enabled = false;
            }

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IsOnSalary.Checked)
            {
                radioButton_SalaryAmount.Enabled = true;
                radioButton_SalaryPercentage.Enabled = true;

                comboBox_SalaryRatioType.Enabled = true;
                comboBox_SalaryRatioType.SelectedIndex = 0;
            }
            else
            {
                radioButton_SalaryAmount.Checked = true;
                radioButton_SalaryAmount.Checked = false;
                radioButton_SalaryPercentage.Checked = true;
                radioButton_SalaryPercentage.Checked = false;

                radioButton_SalaryAmount.Enabled = false;
                radioButton_SalaryPercentage.Enabled = false;

                numericUpDown_SalaryAmount.Value = 0;
                numericUpDown_SalaryPercentage.Value = 0;
                comboBox_SalaryRatioType.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_ContributionAmount.Checked)
            {
                numericUpDown_ContributionAmount.Enabled = true;
                numericUpDown_ContributionPercentage.Enabled = false;
                numericUpDown_ContributionPercentage.Value = 0;
                comboBox_ContributionRatioType.SelectedIndex = 0;
            }
            else
            {
                numericUpDown_ContributionAmount.Enabled = false;
                numericUpDown_ContributionPercentage.Enabled = false;
                
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_ContributionPercentage.Checked)
            {
                numericUpDown_ContributionPercentage.Enabled = true;
                numericUpDown_ContributionAmount.Enabled = false;
                numericUpDown_ContributionAmount.Value = 0;
                comboBox_ContributionRatioType.SelectedIndex = 1;
            }
            else
            {
                numericUpDown_ContributionPercentage.Enabled = false;
                numericUpDown_ContributionAmount.Enabled = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_CommissionPercentage.Checked)
            {
                numericUpDown_CommissionPercentage.Enabled = true;
                numericUpDown_CommissionAmount.Enabled = false;
                numericUpDown_CommissionAmount.Value = 0;
                comboBox_CommissionRatioType.SelectedIndex = 1;
            }
            else
            {
                numericUpDown_CommissionPercentage.Enabled = false;
                numericUpDown_CommissionAmount.Enabled = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_CommissionAmount.Checked)
            {
                numericUpDown_CommissionAmount.Enabled = true;
                numericUpDown_CommissionPercentage.Enabled = false;
                numericUpDown_CommissionPercentage.Value = 0;
                comboBox_CommissionRatioType.SelectedIndex = 0;
            }
            else
            {
                numericUpDown_CommissionAmount.Enabled = false;
                numericUpDown_CommissionPercentage.Enabled = false;

            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_SalaryAmount.Checked)
            {
                numericUpDown_SalaryAmount.Enabled = true;
                numericUpDown_SalaryPercentage.Enabled = false;
                numericUpDown_SalaryPercentage.Value = 0;
                comboBox_SalaryRatioType.SelectedIndex = 0;
            }
            else
            {
                numericUpDown_SalaryAmount.Enabled = false;
                numericUpDown_SalaryPercentage.Enabled = false;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_SalaryPercentage.Checked)
            {
                numericUpDown_SalaryPercentage.Enabled = true;
                numericUpDown_SalaryAmount.Enabled = false;
                numericUpDown_SalaryAmount.Value = 0;
                comboBox_SalaryRatioType.SelectedIndex = 1;
            }
            else
            {
                numericUpDown_SalaryAmount.Enabled = false;
                numericUpDown_SalaryPercentage.Enabled = false;
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label_ContactID.Text = comboBox_ContactID.SelectedValue.ToString();
            textBox_Name.Text = comboBox_ContactID.Text.ToString();
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_ContributionRatioType.SelectedIndex.ParseEnum<RatioType>() == RatioType.Solid)
            {
                radioButton_ContributionAmount.Checked = true;
            }
            else if (comboBox_ContributionRatioType.SelectedIndex.ParseEnum<RatioType>() == RatioType.Fixed)
            {
                radioButton_ContributionPercentage.Checked = true;
            }
            else if (comboBox_ContributionRatioType.SelectedIndex.ParseEnum<RatioType>() == RatioType.Relative)
            {
                radioButton_ContributionAmount.Checked = false;
                radioButton_ContributionPercentage.Checked = false;
            }
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_CommissionRatioType.SelectedIndex.ParseEnum<RatioType>() == RatioType.Solid)
            {
                radioButton_CommissionAmount.Checked = true;
            }
            else if (comboBox_CommissionRatioType.SelectedIndex.ParseEnum<RatioType>() == RatioType.Fixed)
            {
                radioButton_CommissionPercentage.Checked = true;
            }
            else if (comboBox_CommissionRatioType.SelectedIndex.ParseEnum<RatioType>() == RatioType.Relative)
            {
                radioButton_CommissionAmount.Checked = false;
                radioButton_CommissionPercentage.Checked = false;
            }
        }

        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_SalaryRatioType.SelectedIndex.ParseEnum<RatioType>() == RatioType.Solid)
            {
                radioButton_SalaryAmount.Checked = true;
            }
            else if (comboBox_SalaryRatioType.SelectedIndex.ParseEnum<RatioType>() == RatioType.Fixed)
            {
                radioButton_SalaryPercentage.Checked = true;
            }
            else if (comboBox_SalaryRatioType.SelectedIndex.ParseEnum<RatioType>() == RatioType.Relative)
            {
                radioButton_SalaryAmount.Checked = false;
                radioButton_SalaryPercentage.Checked = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                pointReferences();
                DialogResult ButtonPressed = MessageBox.Show("Are you sure you want to delete the selected record?", "Data Entry Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);

                if (ButtonPressed == DialogResult.Yes)
                {
                    anAgent.ID = Convert.ToInt32(label_Remove.Text);

                    AgentH.Remove(anAgent.ID);

                    MessageBox.Show("Removed", "Data Entry Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    //refresh
                    button2_Click(sender, e);
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
                label_Remove.Text = dataGridView_.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
                //do nothing
                
            }
            
        }
    }
}
