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

namespace Com.RealEstate.Component.Handler
{
    public class InvestorHandler : IDML<Investor>
    {
        public event EventHandler<EventArgs> DataDeleted;
        public event EventHandler<EventArgs> DataInserted;
        public event EventHandler<EventArgs> DataUpdated;

        public int Add(Investor aType)
        {
            int returnValue = -1;
            returnValue= new InvestorDataHelper().Insert(aType);
            return returnValue;
        }

        public void Change(Investor aType)
        {
            throw new NotImplementedException();
        }

        public BindingSource GetList()
        {
            InvestorDataHelper DH = new InvestorDataHelper();
            BindingSource BS = new BindingSource();
            Hashtable HT = new Hashtable();

            List<Investor> myList = DH.SelectAll();
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

            HT.Add(-1, "Select Investor");
            BS.DataSource = HT;
            return BS;
        }

        public void Remove(Investor aType)
        {
            throw new NotImplementedException();
        }

        public void Remove(int SearchByID)
        {
            new InvestorDataHelper().Delete(SearchByID);
        }

        public BindingList<Investor> Show(Investor aType)
        {
            try
            {
                var myList = new InvestorDataHelper().SelectAll();
                var bindingList = new BindingList<Investor>(myList);
                return bindingList;
            }
            catch (ArgumentNullException)
            {
                throw new DataExistence("No Data Found! No Investor is yet added.");
            }

        }
    }
}
