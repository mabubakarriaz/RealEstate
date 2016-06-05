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
using System.Collections;
using Com.RealEstate.Component.Exceptions;
using System.Data.SqlClient;

namespace Com.RealEstate.Component.Handler
{
    public class DealHandler : IDML<Deal>
    {
        public event EventHandler<EventArgs> DataDeleted;
        public event EventHandler<EventArgs> DataInserted;
        public event EventHandler<EventArgs> DataUpdated;

        public int Add(Deal aType)
        {
            int returnValue = -1;
            returnValue = new DealDataHelper().Insert(aType);
            return returnValue;
        }

        public void Change(Deal aType)
        {
            throw new NotImplementedException();
        }

        public void Change(Deal aDeal, ProductTransaction aProductTransaction, SqlTransaction atrans)
        {
            new DealDataHelper().UpdateByTransactionAmount(aDeal.ID, aProductTransaction, atrans);
        }

        public void Change(Deal aDeal, ProductTransaction aProductTransaction)
        {
            new DealDataHelper().UpdateByTransactionAmount(aDeal.ID, aProductTransaction);
        }

        public BindingSource GetList()
        {
            DealDataHelper DH = new DealDataHelper();
            BindingSource BS = new BindingSource();
            Hashtable HT = new Hashtable();

            List<Deal> myList = DH.SelectAll();
            if (myList != null)
            {
                foreach (var item in myList)
                {
                    if (item.State == EntityState.Enabled)
                    {
                        HT.Add(item.ID, item.Name);
                    }
                }
            }

            HT.Add(-1, "Select Deal");
            BS.DataSource = HT;
            return BS;
        }

        public Deal GetItem(int searchByID)
        {

            return new DealDataHelper().SelectByID(searchByID);
        }

        public void Remove(Deal aType)
        {
            throw new NotImplementedException();
        }

        public void Remove(int SearchByID)
        {
            new DealDataHelper().Delete(SearchByID);
        }
        public BindingList<Deal> Show(Deal aType)
        {
            try
            {
                var myList = new DealDataHelper().SelectAll();
                var bindingList = new BindingList<Deal>(myList);
                return bindingList;
            }
            catch (ArgumentNullException)
            {
                throw new DataExistence("No Data Found! No Deals are yet added.");
            }
        }
    }
}
