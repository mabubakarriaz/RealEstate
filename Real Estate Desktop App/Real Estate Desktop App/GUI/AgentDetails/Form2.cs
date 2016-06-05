using Com.RealEstate.Component.Entity;
using Com.RealEstate.Component.Exceptions;
using Com.RealEstate.Component.ExtensionMethods;
using Com.RealEstate.Component.Handler;
using System;
using System.Collections;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            defaultValues();
        }

        Agent anAgent = new Agent();
        AgentHandler agentH = new AgentHandler();

        AgentGroup anAgentGroup = new AgentGroup();
        AgentGroupHandler agentGroupH = new AgentGroupHandler();
        
        AgentGroupDetail anAgentGroupDetail = new AgentGroupDetail();
        AgentGroupDetailHandler agentGroupDetailH = new AgentGroupDetailHandler();

        void defaultValues() {

            loadLists();
            textBox1.Text = anAgentGroup.Name;

            radioButton_Amount.Checked = true;
        }

        void pointReferences_Group() {
            anAgentGroup.Name = textBox1.Text;
        }

        void pointReferences_Member()
        {
            
            anAgentGroupDetail.AgentGroupID = Convert.ToInt32(label_AgentGroupID.Text);
            anAgentGroupDetail.AgentID= Convert.ToInt32(label_AgentID.Text);
            anAgentGroupDetail.Percentage = numericUpDown_Percentage.Value;
            anAgentGroupDetail.Amount =Convert.ToDouble(numericUpDown_Amount.Value);
            anAgentGroupDetail.RatioType = comboBox_RatioType.SelectedIndex.ParseEnum<RatioType>();
        }

        void loadLists() {
           
            comboBox_RatioType.DataSource = UtilityExtension.EnumArray<RatioType>();
            
            var bindingSource = agentGroupH.GetList();

            comboBox_AgentGroupID.DataSource = bindingSource;
            comboBox_AgentGroupID.DisplayMember = "Value";
            comboBox_AgentGroupID.ValueMember = "Key";
            comboBox_AgentGroupID.SelectedValue = -1;

            var bindingSource2 = agentH.GetList();

            comboBox_AgentID.DataSource = bindingSource2;
            comboBox_AgentID.DisplayMember = "Value";
            comboBox_AgentID.ValueMember = "Key";
            comboBox_AgentID.SelectedValue = -1;


            var bindingSource3 = agentH.GetList(AgentType.Chief);

            comboBox_AgentID_Chief.DataSource = bindingSource3;
            comboBox_AgentID_Chief.DisplayMember = "Value";
            comboBox_AgentID_Chief.ValueMember = "Key";
            comboBox_AgentID_Chief.SelectedValue = -1;

            var bindingSource4 = agentH.GetList(AgentType.Office);

            comboBox_AgentID_Office.DataSource = bindingSource4;
            comboBox_AgentID_Office.DisplayMember = "Value";
            comboBox_AgentID_Office.ValueMember = "Key";
            comboBox_AgentID_Office.SelectedValue = -1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                pointReferences_Group();
                anAgentGroup.ID = agentGroupH.Add(anAgentGroup);

                label4.Text = Convert.ToString(anAgentGroup.ID);

                MessageBox.Show("Added", "Agent Group Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                pointReferences_Member();
                anAgentGroupDetail.ID = agentGroupDetailH.Add(anAgentGroupDetail);

                label_Add.Text = Convert.ToString(anAgentGroupDetail.ID);

                MessageBox.Show("Added", "Agent Group Detail Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Entry Error - Unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            loadLists();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var bindingList = agentGroupH.Show(anAgentGroup);
                var source = new BindingSource(bindingList, null);
                dataGridView1.DataSource = source;
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
            label_AgentGroupID.Text = comboBox_AgentGroupID.SelectedValue.ToString();

            if (Convert.ToInt32(label_AgentGroupID.Text) > 0)
            {
                anAgentGroup.ID = Convert.ToInt32(label_AgentGroupID.Text);
                anAgentGroup = agentGroupH.Show(anAgentGroup.ID);

            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_AgentID_Chief.Checked)
            {
                comboBox_AgentID_Chief.Enabled = true;
            }
            else {
                comboBox_AgentID_Chief.Enabled = false;
                comboBox_AgentID_Chief.SelectedValue = -1;
                textBox_AgentID.Text = "";
                label_AgentID.Text = "-1";
                label_AgentID_Chief.Text = "-1";
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_AgentID_Office.Checked)
            {
                comboBox_AgentID_Office.Enabled = true;
            }
            else
            {
                comboBox_AgentID_Office.Enabled = false;
                comboBox_AgentID_Office.SelectedValue = -1;
                textBox_AgentID.Text = "";
                label_AgentID.Text = "-1";
                label_AgentID_Office.Text = "-1";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_AgentID.Checked)
            {
                comboBox_AgentID.Enabled = true;
            }
            else
            {
                comboBox_AgentID.Enabled = false;
                comboBox_AgentID.SelectedValue = -1;
                textBox_AgentID.Text = "";
                label_AgentID.Text = "-1";
                label_AgentID_Representative.Text = "-1";
                
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Percentage.Checked)
            {
                numericUpDown_Percentage.Enabled = true;
                comboBox_RatioType.SelectedIndex = 1;
            }
            else
            {
                numericUpDown_Percentage.Enabled = false;
                numericUpDown_Percentage.Value = 0;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Amount.Checked)
            {
                numericUpDown_Amount.Enabled = true;
                comboBox_RatioType.SelectedIndex = 0;
            }
            else
            {
                numericUpDown_Amount.Enabled = false;
                numericUpDown_Amount.Value = 0;
            }
        }

        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label_AgentID_Representative.Text = comboBox_AgentID.SelectedValue.ToString();

            if (Convert.ToInt32(label_AgentID_Representative.Text) > 0)
            {
                anAgent.ID = Convert.ToInt32(label_AgentID_Representative.Text);
                anAgent = agentH.Show(anAgent.ID);

                numericUpDown_Percentage.Value = anAgent.CommissionPercentage;
                numericUpDown_Amount.Value = Convert.ToDecimal(anAgent.CommissionAmount);
                comboBox_RatioType.SelectedIndex = (int)anAgent.CommissionRatioType;
                comboBox5_SelectionChangeCommitted(sender, e);
            }

            textBox_AgentID.Text = comboBox_AgentID.Text;
            label_AgentID.Text = comboBox_AgentID.SelectedValue.ToString();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label_AgentID_Chief.Text = comboBox_AgentID_Chief.SelectedValue.ToString();

            if (Convert.ToInt32(label_AgentID_Chief.Text) > 0)
            {
                anAgent.ID = Convert.ToInt32(label_AgentID_Chief.Text);
                anAgent = agentH.Show(anAgent.ID);

                numericUpDown_Percentage.Value = anAgent.CommissionPercentage;
                numericUpDown_Amount.Value = Convert.ToDecimal(anAgent.CommissionAmount);
                comboBox_RatioType.SelectedIndex = (int)anAgent.CommissionRatioType;
                comboBox5_SelectionChangeCommitted(sender, e);
            }


            textBox_AgentID.Text = comboBox_AgentID_Chief.Text;
            label_AgentID.Text = comboBox_AgentID_Chief.SelectedValue.ToString();
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label_AgentID_Office.Text = comboBox_AgentID_Office.SelectedValue.ToString();

            if (Convert.ToInt32(label_AgentID_Office.Text) > 0)
            {
                anAgent.ID = Convert.ToInt32(label_AgentID_Office.Text);
                anAgent = agentH.Show(anAgent.ID);

                numericUpDown_Percentage.Value = anAgent.CommissionPercentage;
                numericUpDown_Amount.Value = Convert.ToDecimal(anAgent.CommissionAmount);
                comboBox_RatioType.SelectedIndex = (int)anAgent.CommissionRatioType;
                comboBox5_SelectionChangeCommitted(sender, e);
            }

            textBox_AgentID.Text = comboBox_AgentID_Office.Text;
            label_AgentID.Text = comboBox_AgentID_Office.SelectedValue.ToString();
        }

        private void comboBox5_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_RatioType.SelectedIndex.ParseEnum<RatioType>()== RatioType.Solid)
            {
                radioButton_Amount.Checked = true;
            }
            else if (comboBox_RatioType.SelectedIndex.ParseEnum<RatioType>() == RatioType.Fixed)
            {
                radioButton_Percentage.Checked = true;
            }
            else if (comboBox_RatioType.SelectedIndex.ParseEnum<RatioType>() == RatioType.Relative)
            {
                radioButton_Amount.Checked = false;
                radioButton_Percentage.Checked = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                pointReferences_Member();

                if (Convert.ToInt32(label_AgentGroupID.Text) > 0)
                {
                    anAgentGroup.ID = anAgentGroupDetail.AgentGroupID;

                    var bindingList = agentGroupDetailH.Show(anAgentGroup);
                    var source = new BindingSource(bindingList, null);
                    dataGridView_Member.DataSource = source;
                }
                else
                {
                    MessageBox.Show("Please Select an Agent Group to show member details against it.", "Agent Group Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (DataExistence ex)
            {
                MessageBox.Show(ex.Message, "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Data Entry Error - Unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


}

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                pointReferences_Group();
                DialogResult ButtonPressed = MessageBox.Show("Are you sure you want to delete the selected record?", "Data Entry Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);

                if (ButtonPressed == DialogResult.Yes)
                {
                    anAgentGroup.ID = Convert.ToInt32(label8.Text);

                    agentGroupH.Remove(anAgentGroup.ID);

                    MessageBox.Show("Removed", "Data Entry Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //refresh
                    button3_Click(sender, e);
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
                label8.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
                //do nothing
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                pointReferences_Member();
                DialogResult ButtonPressed = MessageBox.Show("Are you sure you want to delete the selected record?", "Data Entry Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);

                if (ButtonPressed == DialogResult.Yes)
                {
                    anAgentGroupDetail.ID = Convert.ToInt32(label_Remove.Text);

                    agentGroupDetailH.Remove(anAgentGroupDetail.ID);

                    MessageBox.Show("Removed", "Data Entry Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //refresh
                    button4_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Entry Error - Unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label_Remove.Text = dataGridView_Member.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
                //do nothing
            }
        }

    }
}
