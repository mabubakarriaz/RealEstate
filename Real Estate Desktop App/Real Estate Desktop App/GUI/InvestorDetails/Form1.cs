using Com.RealEstate.Component.DataHelper;
using Com.RealEstate.Component.Entity;
using Com.RealEstate.Component.Exceptions;
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

namespace Com.RealEstate.DesktopApp.GUI.InvestorDetails
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            defaultValues();
        }

        
        ContactHandler ContactH = new ContactHandler();
        Investor anInvestor = new Investor();
        InvestorHandler aInvestorH = new InvestorHandler();

        void defaultValues() {

            var bindingSource= ContactH.GetList();

            comboBox_ContactID.DataSource = bindingSource;
            comboBox_ContactID.DisplayMember = "Value";
            comboBox_ContactID.ValueMember = "Key";
            comboBox_ContactID.SelectedValue = -1;


            label_ContactID.Text = "0";
            label_Add.Text = "0";
            textBox_Name.Text = "";

        }

        void pointReferences() {


            anInvestor.ID = Convert.ToInt32(label_ContactID.Text);
            anInvestor.Name = textBox_Name.Text;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_ContactID.Text = comboBox_ContactID.SelectedValue.ToString();
            textBox_Name.Text = comboBox_ContactID.Text.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                pointReferences();
                anInvestor.ID = aInvestorH.Add(anInvestor);
                label_Add.Text = Convert.ToString(anInvestor.ID);

                MessageBox.Show("Added", "Data Entry Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                var bindingList = aInvestorH.Show(anInvestor);
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                pointReferences();
                DialogResult ButtonPressed = MessageBox.Show("Are you sure you want to delete the selected record?", "Data Entry Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);

                if (ButtonPressed == DialogResult.Yes)
                {
                    anInvestor.ID = Convert.ToInt32(label_Remove.Text);

                    aInvestorH.Remove(anInvestor.ID);

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
