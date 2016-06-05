using Com.RealEstate.Component.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Com.RealEstate.Component.Exceptions;
using Com.RealEstate.Component.DataHelper;
using System.ComponentModel;
using System.Windows.Forms;

namespace Com.RealEstate.Component.Entity
{
    public class Product
    {

        public Product() {
            State = EntityState.Enabled;
        }

        public int ID { get; set; }
        public string PlotNo { get; set; }
        public string Block { get; set; }
        public string Sector { get; set; }
        public string Mesuring { get; set; }
        public string Scheme { get; set; }
        public bool OnGround { get; set; }

        public EntityState State { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime EntryDate { get; set; }

       
    }
}
