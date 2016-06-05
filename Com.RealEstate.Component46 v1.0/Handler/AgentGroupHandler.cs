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
    public class AgentGroupHandler : IDML<AgentGroup>
    {
        public event EventHandler<EventArgs> DataDeleted;
        public event EventHandler<EventArgs> DataInserted;
        public event EventHandler<EventArgs> DataUpdated;

        public int Add(AgentGroup aType)
        {
            int returnValue = -1;
            returnValue = new AgentGroupDataHelper().Insert(aType);
            return returnValue;
        }

        public void Change(AgentGroup aType)
        {
            throw new NotImplementedException();
        }

        public BindingSource GetList()
        {
            AgentGroupDataHelper DH = new AgentGroupDataHelper();
            BindingSource BS = new BindingSource();
            Hashtable HT = new Hashtable();

            List<AgentGroup> myList = DH.SelectAll();

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

            HT.Add(-1, "Select Agent Group");

            BS.DataSource = HT;
            return BS;
        }

        public void Remove(AgentGroup aType)
        {
            throw new NotImplementedException();
        }

        public void Remove(int SearchByID)
        {
            new AgentGroupDataHelper().Delete(SearchByID);
        }

        public BindingList<AgentGroup> Show(AgentGroup aType)
        {
            try
            {
                var myList = new AgentGroupDataHelper().SelectAll();
                var bindingList = new BindingList<AgentGroup>(myList);
                return bindingList;
            }
            catch (ArgumentNullException)
            {
                throw new DataExistence("No Data Found! No groups are yet added.");
            }
        }

        public AgentGroup Show(int searchByID)
        {
            var mySingleItem = new AgentGroupDataHelper().SelectByID(searchByID);

            return mySingleItem;
        }
    }
}
