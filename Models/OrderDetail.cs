namespace ASP.NETWebAPI.Models
{
    public class OrderDetail
    {
        public long ID { get; set; }
        
        public long OrderID { get; set; }
        
        public long ProductID { get; set; }
        
        public long Quantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
