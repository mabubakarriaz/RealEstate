using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.RealEstate.Component.Data;
using Com.RealEstate.Component.DataHelper;
using Com.RealEstate.Component.Exceptions;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;

namespace Com.RealEstate.Component.Entity
{
    public class Contact
    {
         public Contact()
        {
            Type = EntityType.Unknown;
            State = EntityState.Enabled;
        }

        public int ID { get; set; }
        public string FullName { get; set; }
        public EntityType Type { get; set; }
        public string NIC { get; set; }

        public EntityState State { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime EntryDate { get; set; }
   
    }
}
