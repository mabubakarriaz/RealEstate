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
    public class InvestmentGroupHandler : IDML<InvestmentGroup>
    {
        public event EventHandler<EventArgs> DataDeleted;
        public event EventHandler<EventArgs> DataInserted;
        public event EventHandler<EventArgs> DataUpdated;

        public int Add(InvestmentGroup aType)
        {
            int returnValue = -1;

            returnValue= new InvestmentGroupDataHelper().Insert(aType);
            DataInserted(this, new EventArgs());

            return returnValue;
        }

        public void Change(InvestmentGroup aType)
        {
            throw new NotImplementedException();
        }

        public BindingSource GetList()
        {
            InvestmentGroupDataHelper DH = new InvestmentGroupDataHelper();
            BindingSource BS = new BindingSource();
            Hashtable HT = new Hashtable();

            List<InvestmentGroup> myList = DH.SelectAll();
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
            HT.Add(-1, "Select Investment Group");

            BS.DataSource = HT;
            return BS;
        }

        public InvestmentGroup GetItem(int searchByID) {

            return new InvestmentGroupDataHelper().SelectByID(searchByID);
        }

        public void Remove(InvestmentGroup aType)
        {
            throw new NotImplementedException();
        }

        public void Remove(int SearchByID)
        {
            new InvestmentGroupDataHelper().Delete(SearchByID);
        }


        public BindingList<InvestmentGroup> Show(InvestmentGroup aType)
        {
            try
            {
                var myList = new InvestmentGroupDataHelper().SelectAll();
                var bindingList = new BindingList<InvestmentGroup>(myList);
                return bindingList;
            }
            catch (ArgumentNullException)
            {
                throw new DataExistence("No Data Found! No Investment group is yet created.");
            }

        }

        public InvestmentGroup Show(int SearchbyID)
        {
            var mySingleItem = new InvestmentGroupDataHelper().SelectByID(SearchbyID);

            return mySingleItem;
        }

    }
}
