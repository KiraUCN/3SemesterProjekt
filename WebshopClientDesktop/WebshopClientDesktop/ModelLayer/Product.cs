﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopClientDesktop.ModelLayer
{
    public class Product
    {

        public Product() { }
        public Product(int prodId, string prodName, string prodDescription, decimal prodPrice, int prodQuantity)
        {

            ProdId = prodId;
            ProdName = prodName;
            ProdDescription = prodDescription;
            ProdPrice = prodPrice;
            ProdQuantity = prodQuantity;

        }
        public int ProdId { get; set; }
        public string ProdName { get; private set; }
        public string ProdDescription { get; private set; }
        public decimal ProdPrice { get; private set; }
        public int ProdQuantity { get; private set; }
    }
}
