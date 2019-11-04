namespace ASP.NETWebAPI.Models
{
    public class OrderDetail
    {
        public long ID { get; set; }
        
        public long OrderID { get; set; }
        
        public long ProductID { get; set; }
        
        public long Quantity { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}
