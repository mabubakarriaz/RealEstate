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

namespace Com.RealEstate.DesktopApp.GUI.Reports
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            defaultValues();
        }

        ContactHandler aContactH = new ContactHandler();
        Contact aContact = new Contact();
        FinancialTransactionHandler aFinancialTransactionH = new FinancialTransactionHandler();

        void defaultValues()
        {

            var bindingSource = aContactH.GetList();

            comboBox_ContactID.DataSource = bindingSource;
            comboBox_ContactID.DisplayMember = "Value";
            comboBox_ContactID.ValueMember = "Key";
            comboBox_ContactID.SelectedValue = -1;

            label_ContactID.Text = "0";

        }

        void pointReferences()
        {
            aContact.ID = Convert.ToInt32(label_ContactID.Text);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(label_ContactID.Text) > 0)
                {
                    pointReferences();
                    
                    var bindingList = aFinancialTransactionH.Show(aContact);
                    var source = new BindingSource(bindingList, null);
                    dataGridView_.DataSource = source;
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

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label_ContactID.Text = comboBox_ContactID.SelectedValue.ToString();
            
        }
    }
}
