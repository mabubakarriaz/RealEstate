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

namespace Com.RealEstate.Component.Handler
{
    public class AgentGroupDetailHandler : IDML<AgentGroupDetail> ,IListView
    {
        public event EventHandler<EventArgs> DataDeleted;
        public event EventHandler<EventArgs> DataInserted;
        public event EventHandler<EventArgs> DataUpdated;

        public int Add(AgentGroupDetail aType)
        {
            int returnValue = -1;

            List<AgentGroupDetail> AgentGroupDetailList = new AgentGroupDetailDataHelper().SelectByGroupID(aType.AgentGroupID);

            if (AgentGroupDetailList != null)
            {
                foreach (var item in AgentGroupDetailList)
                {
                    if (item.AgentID == aType.AgentID)
                    {
                        throw new DataEntryExistence("Duplication! This Agent is Already Added in this Group.");
                    }
                }
            }

            returnValue = new AgentGroupDetailDataHelper().Insert(aType);
            return returnValue;
        }

        public void Change(AgentGroupDetail aType)
        {
            throw new NotImplementedException();
        }

        public BindingSource GetList()
        {
            throw new NotImplementedException();
        }

        public List<ListViewItem> GetListView()
        {
            List<ListViewItem> ListViewItems = new List<ListViewItem>();

            AgentGroupDetailDataHelper DH = new AgentGroupDetailDataHelper();
            List<AgentGroupDetail> aList = DH.SelectAll();

            if (aList != null)
            {
                foreach (var item in aList)
                {
                    // Define the list items
                    ListViewItem aListViewItem = new ListViewItem(new AgentDataHelper().SelectByID(item.AgentID).Name.ToString());
                    aListViewItem.SubItems.Add(item.Amount.ToString());
                    aListViewItem.SubItems.Add(item.Percentage.ToString());
                    aListViewItem.SubItems.Add(item.RatioType.ToString());

                    // Add the list items to the ListView
                    ListViewItems.Add(aListViewItem);
                }
            }
            return ListViewItems;
        }

        public List<ListViewItem> GetListView(Deal aDeal)
        {
            List<ListViewItem> ListViewItems = new List<ListViewItem>();

            AgentGroupDetailDataHelper DH = new AgentGroupDetailDataHelper();
            List<AgentGroupDetail> aList = DH.SelectByGroupID(aDeal.AgentGroupID);

            if (aList != null)
            {
                foreach (var item in aList)
                {
                    // Define the list items
                    ListViewItem aListViewItem = new ListViewItem(new AgentDataHelper().SelectByID(item.AgentID).Name.ToString());
                    aListViewItem.SubItems.Add(item.Amount.ToString());
                    aListViewItem.SubItems.Add(item.Percentage.ToString());
                    aListViewItem.SubItems.Add(item.RatioType.ToString());

                    // Add the list items to the ListView
                    ListViewItems.Add(aListViewItem);
                }
            }
            return ListViewItems;
        }

        public void Remove(AgentGroupDetail aType)
        {
            throw new NotImplementedException();
        }

        public void Remove(int SearchByID)
        {
            new AgentGroupDetailDataHelper().Delete(SearchByID);
        }

        public BindingList<AgentGroupDetail> Show()
        {
            try
            {
                var myList = new AgentGroupDetailDataHelper().SelectAll();
                var bindingList = new BindingList<AgentGroupDetail>(myList);
                return bindingList;
            }
            catch (ArgumentNullException)
            {
                throw new DataExistence("No Data Found! No Members are avialable in selected Agent group.");
            }

        }

        public BindingList<AgentGroupDetail> Show(AgentGroupDetail aType)
        {
            throw new NotImplementedException();
        }


       
        public BindingList<AgentGroupDetail> Show(AgentGroup anAgentGroup)
        {
            try
            {
                var myList = new AgentGroupDetailDataHelper().SelectByGroupID(anAgentGroup.ID);
                var bindingList = new BindingList<AgentGroupDetail>(myList);
                return bindingList;
            }
            catch (ArgumentNullException)
            {
                throw new DataExistence("No Data Found! No Members are avialable in selected Agent group.");
            }

        }
    }
}
