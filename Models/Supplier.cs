using System;
using System.Collections.Generic;

namespace ASP.NETWebAPI.Models
{
    public class Supplier
    {
        public long ID { get; set; }
        
        public String Name { get; set; }

        public String ContactName { get; set; }

        public String Address { get; set; }

        public String City { get; set; }

        public String PostalCode { get; set; }

        public String Country { get; set; }

        public String Phone { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
