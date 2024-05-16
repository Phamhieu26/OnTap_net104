namespace OnTap_net104.Models
{
    public class Bill
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        public string Username { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual List<BillDetail>? BillDetails { get; set; }
        public virtual Account Account { get; set; }
    }
}
