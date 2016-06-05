using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.RealEstate.Component.Data
{
    internal interface ICOQL<customTypeA>
    {
        List<customTypeA> SelectAll();
        customTypeA SelectByID(int SearchByID);
        int Insert(customTypeA anObject);
        void Delete(int DeleteByID);
        void Update(int SearchByID, customTypeA anObject);

    }
}
