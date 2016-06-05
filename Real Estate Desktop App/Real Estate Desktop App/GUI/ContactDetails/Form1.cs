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

namespace Com.RealEstate.DesktopApp.GUI.ContactDetails
{
    public partial class Form1 : Form
    {

        Contact aContact = new Contact();
        ContactDataHelper contactDH = new ContactDataHelper();
        ContactHandler aContactH = new ContactHandler();

        public Form1()
        {
            InitializeComponent();
            defaultValues();
            
        }

        void pointReferences() {

            aContact.ID =Convert.ToInt32(label_Add.Text);
            aContact.FullName = textBox_FullName.Text;
            aContact.Type = comboBox_Type.SelectedIndex.ParseEnum<EntityType>();
            aContact.NIC = textBox_NIC.Text;
        }

        void defaultValues() {

            label_Add.Text = "0";
            comboBox_Type.DataSource = UtilityExtension.EnumArray<EntityType>();
            comboBox_Type.SelectedIndex = 0;

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            
            try
            {
                pointReferences();
                aContact.ID = aContactH.Add(aContact);

                label_Add.Text = Convert.ToString(aContact.ID);

                MessageBox.Show("Added", "Contact Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                var bindingList = aContactH.Show(aContact);
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                pointReferences();
                DialogResult ButtonPressed = MessageBox.Show("Are you sure you want to delete the selected record?", "Data Entry Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);

                if (ButtonPressed == DialogResult.Yes)
                {
                    aContact.ID = Convert.ToInt32(label_Remove.Text);

                    aContactH.Remove(aContact.ID);

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
                label_Remove.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
                //do nothing
            }
        }
    }
}
