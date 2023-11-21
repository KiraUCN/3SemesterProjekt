﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebshopClientDesktop.GUI
{
    public partial class EventForm : Form
    {
        private Form1 form1;
        private MerchForm merchForm;
        public EventForm(Form1 existingForm1, MerchForm existingMerchForm)
        {
            InitializeComponent();

            //Relates to NorlysButton_Click method - home page
            form1 = existingForm1;
            norlysButton.Click += NorlysButton_Click;

            //Relates to MerchLbl_Click method - merch page
            merchForm = existingMerchForm;
            merchLbl.Click += MerchLbl_Click;

        }

        private void MerchLbl_Click(object? sender, EventArgs e)
        {
            try
            {
                //If MerchForm is not visible - that is, if Form1 is open - and we push the button "Merch", MerchForm is shown
                if (merchForm != null && !merchForm.Visible)
                {
                    merchForm.Show();
                }

                //When MerchForm is shown, this hides Form1
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error happened while trying to load Event page: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NorlysButton_Click(object? sender, EventArgs e)
        {
            try
            {
                //If EventForm is not visible - that is, if Form1 is open - and we push the button "Events", EventForm is shown
                if (!form1.Visible)
                {
                    form1.Show();
                }

                //When EventForm is shown, this hides Form1
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error happened while trying to load Home page: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EventForm_Load(object sender, EventArgs e)
        {

        }

    }
}