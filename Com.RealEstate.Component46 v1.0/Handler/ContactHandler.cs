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
    public class ContactHandler : IDML<Contact>
    {
        public event EventHandler<EventArgs> DataDeleted;
        public event EventHandler<EventArgs> DataInserted;
        public event EventHandler<EventArgs> DataUpdated;

        public int Add(Contact aType)
        {
            int returnValue = -1;
            returnValue= new ContactDataHelper().Insert(aType);

            return returnValue;
        }

        public void Change(Contact aType)
        {
            throw new NotImplementedException();
        }

        public BindingSource GetList()
        {

            ContactDataHelper DH = new ContactDataHelper();
            BindingSource BS = new BindingSource();
            Hashtable HT = new Hashtable();

            List<Contact> myList = DH.SelectAll();
            if (myList != null)
            {
                foreach (var item in myList)
                {
                    if (item.State == EntityState.Enabled)
                    {
                        HT.Add(item.ID, item.FullName);
                    }
                }
            }

            HT.Add(-1, "Select Contact");

            BS.DataSource = HT;
            return BS;
        }

        public void Remove(Contact aType)
        {
            throw new NotImplementedException();
        }

        public void Remove(int SearchByID)
        {
            new ContactDataHelper().Delete(SearchByID);
        }
        public BindingList<Contact> Show(Contact aType)
        {
            try
            {
                var myList = new ContactDataHelper().SelectAll();
                var bindingList = new BindingList<Contact>(myList);
                return bindingList;
            }
            catch (ArgumentNullException)
            {
                throw new DataExistence("No Data Found! No Contacts are yet added.");
            }
        }
    }
}
