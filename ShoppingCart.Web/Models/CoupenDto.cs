﻿namespace ShoppingCart.Web.Models
{
    public class CoupenDto
    {
        public int CoupenId { get; set; }
        public string CoupenCode { get; set; }
        public decimal DiscountAmount { get; set; }
        public int MinAmount { get; set; }

    }
}
