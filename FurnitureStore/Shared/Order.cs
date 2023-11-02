using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureStore.Shared
{
    public class Order
    {
        public Order()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public int ClientId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal Total { 
            get 
            {
                decimal suma = 0;
                if(Products != null && Products.Any())
                {
                    suma = Products.Sum(p => (p.Price * p.Quantity));
                }
                return suma;
            } 
        }
        public int ProductCategoryId { get; set; }
        public List<Product> Products { get; set; }
    }
}
