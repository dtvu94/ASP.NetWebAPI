using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETWebAPI.Models
{
    public class Order
    {
        public long ID { get; set; }
        
        public long CustomerID { get; set; }
        
        public long EmployeeID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public long ShipperID { get; set; }

        public Customer Customer { get; set; }
        public Employee Employee { get; set; }

        public Shipper Shipper { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
