using Com.RealEstate.Component.Data;
using Com.RealEstate.Component.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using Com.RealEstate.Component.DataHelper;
using Com.RealEstate.Component.Exceptions;
using System.Collections;

namespace Com.RealEstate.Component.Handler
{
    public class ProductHandler : IDML<Product>
    {
        public event EventHandler<EventArgs> DataDeleted;
        public event EventHandler<EventArgs> DataInserted;
        public event EventHandler<EventArgs> DataUpdated;

        public int Add(Product aType)
        {
            int returnValue = -1;
            returnValue =new ProductDataHelper().Insert(aType);
            return returnValue;
        }

        public void Change(Product aType)
        {
            throw new NotImplementedException();
        }

        public BindingSource GetList()
        {
            ProductDataHelper DH = new ProductDataHelper();
            BindingSource BS = new BindingSource();
            Hashtable HT = new Hashtable();

            List<Product> myList = DH.SelectAll();
            if (myList != null)
            {
                foreach (var item in myList)
                {
                    if (item.State == EntityState.Enabled)
                    {
                        HT.Add(item.ID, item.PlotNo + "-" + item.Block);
                    }
                }
            }

            HT.Add(-1, "Select Product");
            BS.DataSource = HT;
            return BS;
        }

        public void Remove(Product aType)
        {
            throw new NotImplementedException();
        }

        public void Remove(int SearchByID)
        {
            new ProductDataHelper().Delete(SearchByID);
        }

        public BindingList<Product> Show(Product aType)
        {
            try
            {
                var myList = new ProductDataHelper().SelectAll();
                var bindingList = new BindingList<Product>(myList);
                return bindingList;
            }
            catch (ArgumentNullException)
            {
                throw new DataExistence("No Data Found! No Plots are yet added.");
            }
            
        }
    }
}
