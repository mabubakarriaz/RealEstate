using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.RealEstate.Component.Entity
{
    public class EntityClass
    {
        public EntityClass() { }

        public long ID { get; set; }
        public string FullName { get; set; }
        public EntityType Type { get; set; }
        public string NIC { get; set; }
        public string ContactNumber { get; set; }
        public string PermanentAddress { get; set; }
        public string Notes { get; set; }
        public bool Exists { get; set; }
        public EntityState State { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
