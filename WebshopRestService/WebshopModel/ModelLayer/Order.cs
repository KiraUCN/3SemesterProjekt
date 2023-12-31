﻿namespace WebshopModel.ModelLayer
{
    public class Order 
    {
        public Order() 
        {
            OrderLines = new List<OrderLine>();
        }

        public Order(int orderId, DateTime orderDate, decimal orderPrice, int personId_FK) 
        {
            OrderId = orderId;
            OrderDate = orderDate;
            OrderPrice = orderPrice;
            OrderLines = new List<OrderLine>();
            PersonId_FK = personId_FK;
        }

        public Order(decimal orderPrice, Person person, List<OrderLine> orderLines)
        {
            OrderDate = DateTime.Now; // Provide a default value for orderDate or modify as needed
            OrderLines = orderLines ?? new List<OrderLine>();
            Person = person ?? throw new ArgumentNullException(nameof(person));
            OrderPrice = orderPrice;
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public Person Person { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public int PersonId_FK { get; }
        public decimal OrderPrice { get; set; }
    }
}
