﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebshopClientDesktop.ControlLayer;
using WebshopClientDesktop.Logging;
using WebshopClientDesktop.ModelLayer;

namespace WebshopClientDesktop.GUI
{
    public partial class EventUC : UserControl
    {
        readonly ProductControl _productControl;
        public EventUC()
        {
            InitializeComponent();

            _productControl = new ProductControl();
        }

        //Slettes
        private void label1_Click(object sender, EventArgs e)
        {

        }
        //Slettes
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void BtnGetEventProducts_Click(object sender, EventArgs e)
        {
            Logger.LogInfo("Button getEvents clicked");
            string processText = "OK";
            List<Product> fetchedProducts = await _productControl.GetAllProductsByEventType();

            if (fetchedProducts != null)
            {
                if (fetchedProducts.Count >= 1)
                {
                    processText = "Ok";
                }
                else
                {
                    processText = "No event products found";
                }
            }
            else
            {
                processText = "Failure: An error occurred";
            }
            lblProcessText.Text = processText;
            listBoxEventProducts.DataSource = fetchedProducts;
        }
    }
}
