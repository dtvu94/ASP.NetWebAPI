using System;
using System.Collections.Generic;

namespace ASP.NETWebAPI.Models
{
    public class Category
    {
        public long ID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
