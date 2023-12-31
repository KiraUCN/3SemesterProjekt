﻿using System.Net;
using WebshopClientWeb.Model;
using WebshopClientWeb.ServiceLayer;

namespace WebshopClientWeb.BusinessLogicLayer
{
    public class OrderDataControl
    {
        readonly IOrderServiceAccess _OrderAccess;

        public HttpStatusCode CurrentHttpStatusCode { get; set; }

        public OrderDataControl()
        {
            _OrderAccess = new OrderServiceAccess();
        }

        // Creates an order using the OrderAccess service and returns the inserted order ID
        public async Task<int> CreateOrder(Order orderToCreate)
        {
            int insertedOrderId = await _OrderAccess.CreateOrder(orderToCreate);

            return insertedOrderId;
        }
    }
}
