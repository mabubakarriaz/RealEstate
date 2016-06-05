using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Com.RealEstate.Component.Data
{
    public interface IDML<customTypeA>
    {
        event EventHandler<EventArgs> DataInserted;
        event EventHandler<EventArgs> DataUpdated;
        event EventHandler<EventArgs> DataDeleted;

        BindingSource GetList();
        BindingList<customTypeA> Show(customTypeA aType);
        int Add(customTypeA aType);
        void Remove(customTypeA aType);
        void Change(customTypeA aType);

    }
}
