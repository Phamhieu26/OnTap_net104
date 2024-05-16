namespace OnTap_net104.Models
{
    public class Product
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; }
        public virtual List<BillDetail>? BillDetails { get; set; }
        public virtual List<CartDetails>? CartDetails { get; set; }
    }
}
