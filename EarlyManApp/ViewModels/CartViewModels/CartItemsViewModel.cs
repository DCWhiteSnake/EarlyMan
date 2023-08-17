using System;
using System.Collections.Generic;

namespace EarlyMan.ViewModels.CartViewModels
{
    public class CartIndexViewModel
    {
        public List<CartViewItem> Items {get;set;} = new List<CartViewItem>();
    }

    public class CartViewItem
    {
        public Guid ProductId { get; set; }
        public Guid CartItemId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int PurchaseQuantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public string ImageLocation { get; set; }
        public decimal SubTotal { get; set; }
    }
}
