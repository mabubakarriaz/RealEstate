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
using System.Data.SqlClient;
using Com.RealEstate.Component.Exceptions;
using System.Collections;
using Com.RealEstate.Component.ExtensionMethods;

namespace Com.RealEstate.Component.Handler
{
    public class AgentHandler : IDML<Agent>
    {
        public event EventHandler<EventArgs> DataDeleted;
        public event EventHandler<EventArgs> DataInserted;
        public event EventHandler<EventArgs> DataUpdated;

        public int Add(Agent aType)
        {
            int returnValue = -1;
            returnValue = new AgentDataHelper().Insert(aType);
            
            return returnValue;
        }

        public void Change(Agent aType)
        {
            throw new NotImplementedException();
        }

        public BindingSource GetList()
        {

            AgentDataHelper DH = new AgentDataHelper();
            BindingSource BS = new BindingSource();
            Hashtable HT = new Hashtable();

            List<Agent> myList = DH.SelectAll();
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
            HT.Add(-1, "Select Agent");

            BS.DataSource = HT;
            return BS;

        }

        public BindingSource GetList(AgentType anAgentType)
        {
            AgentDataHelper DH = new AgentDataHelper();
            BindingSource BS = new BindingSource();
            Hashtable HT = new Hashtable();

            List<Agent> myList = DH.SelectAll();

            if (myList!=null)
            {
                foreach (var item in myList)
                {
                    if (item.State == EntityState.Enabled)
                    {
                        if (item.AgentType == anAgentType)
                        {
                            HT.Add(item.ID, item.Name);
                        }
                    }
                }
            }

            HT.Add(-1, "Select "+ anAgentType.ToString());

            BS.DataSource = HT;
            return BS;

        }



        public void Remove(Agent aType)
        {
            throw new NotImplementedException();
        }

        public void Remove(int SearchByID)
        {
            new AgentDataHelper().Delete(SearchByID);
        }

        public BindingList<Agent> Show(Agent aType)
        {
            try
            {
                var myList = new AgentDataHelper().SelectAll();
                var bindingList = new BindingList<Agent>(myList);
                return bindingList;
            }
            catch (ArgumentNullException)
            {
                throw new DataExistence("No Data Found! No Agents are yet added.");
            }
        }


        public Agent Show(int searchByID)
        {
            var mySingleItem = new AgentDataHelper().SelectByID(searchByID);

            return mySingleItem;
        }
    }
}
