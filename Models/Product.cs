using System;
using System.Collections.Generic;

namespace ASP.NETWebAPI.Models
{
    public class Product
    {
        public long ID { get; set; }
        
        public String Name { get; set; }
        
        public long SupplierID { get; set; }
        
        public long CategoryID { get; set; }

        public String Unit { get; set; }

        public double Price { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
