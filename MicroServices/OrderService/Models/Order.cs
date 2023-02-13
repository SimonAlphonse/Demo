﻿namespace OrderService.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
    }
}