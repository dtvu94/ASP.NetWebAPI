using System;
using System.Collections.Generic;

namespace ASP.NETWebAPI.Models
{
    public class Shipper
    {
        public long ID { get; set; }
        
        public String Name { get; set; }
        
        public String Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
