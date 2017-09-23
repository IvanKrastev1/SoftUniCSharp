namespace _05_08.MyShop
{
    using System.Collections.Generic;

    public class Order
    {
        public Order(int customerId)
        {
            this.CustomerId = customerId;
        }

        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public List<ItemsOrders> Items { get; set; } = new List<ItemsOrders>();
    }
}