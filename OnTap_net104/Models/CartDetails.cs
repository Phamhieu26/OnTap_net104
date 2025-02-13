﻿namespace OnTap_net104.Models
{
    public class CartDetails
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Username { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
        public int Status { get; set; }
        public virtual Product Product { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
