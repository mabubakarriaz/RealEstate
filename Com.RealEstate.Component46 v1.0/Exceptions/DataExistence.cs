using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.RealEstate.Component.Exceptions
{
    public class DataExistence : ApplicationException
    {

        public DataExistence()
        {
        }

        public DataExistence(string msg) : base(msg)
        {
        }
    }
}
