using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.RealEstate.Component.Exceptions
{
    public class DataEntryExistence : ApplicationException
    {

        public DataEntryExistence() {
        }

        public DataEntryExistence(string msg) : base(msg)
        {
        }
    }
}
