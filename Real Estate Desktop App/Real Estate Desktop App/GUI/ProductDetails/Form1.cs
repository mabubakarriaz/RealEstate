using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Com.RealEstate.Component.Entity;
using Com.RealEstate.Component.DataHelper;
using Com.RealEstate.Component.Handler;

using System.Collections;
using Com.RealEstate.Component.Exceptions;

namespace Com.RealEstate.DesktopApp.GUI.ProductDetails
{
    public partial class Add_Product : Form
    {
        public Add_Product()
        {
            InitializeComponent();
            defaultValues();
        }

        Product aProduct = new Product();
        ProductHandler productH = new ProductHandler();

        void pointReferences() {

            aProduct.ID = Convert.ToInt32(label_Add.Text) ;
            aProduct.PlotNo = textBox_PlotNo.Text;
            aProduct.Block = textBox_Block.Text;
            aProduct.Sector = textBox_Sector.Text;
            aProduct.Mesuring = textBox_Measuring.Text;
            aProduct.Scheme = textBox_Scheme.Text;
            aProduct.OnGround = radioButton_OnGround.Checked;

            

        }

        void clearControls() {

            label_Add.Text = "0";
            textBox_PlotNo.Clear();
            textBox_Block.Clear();
            textBox_Sector.Clear();
            textBox_Measuring.Clear();
            textBox_Scheme.Clear();
            radioButton_OnGround.Checked = false;
        }

        public void defaultValues() {

            label_Add.Text = "0";

        }
        private void button1_Click(object sender, EventArgs e)
        {
        
            try
            {
                pointReferences();

                aProduct.ID = productH.Add(aProduct);
                label_Add.Text = Convert.ToString(aProduct.ID);

                MessageBox.Show("Added", "Data Entry Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                clearControls();
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
                var bindingList = productH.Show(aProduct);
                var source = new BindingSource(bindingList, null);
                dataGridView_.DataSource = source;
            }
            catch (DataExistence ex)
            {
                MessageBox.Show(ex.Message, "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Data Entry Error - Unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            //textBox1.Text=dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            //dataGridView1.
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            label_Remove.Text = dataGridView_.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                pointReferences();
                DialogResult ButtonPressed= MessageBox.Show("Are you sure you want to delete the selected record?", "Data Entry Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);

                if (ButtonPressed== DialogResult.Yes)
                {
                    aProduct.ID = Convert.ToInt32(label_Remove.Text);

                    productH.Remove(aProduct.ID);

                    MessageBox.Show("Removed", "Data Entry Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Entry Error - Unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
