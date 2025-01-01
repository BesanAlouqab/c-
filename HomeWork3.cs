using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork3
{
    public partial class Form1 : Form
    {
        private readonly (string Name, string Category, double Price)[] menuItems = {
            ("Soda", "Beverage", 1.5),
            ("Tea", "Beverage", 1.5),
            ("Coffee", "Beverage", 1.25),
            ("Mineral Water", "Beverage", 2.95),
            ("Juice", "Beverage", 2.5),
            ("Milk", "Beverage", 1.5),
            ("Nachos", "Appetizer", 8.5),
            ("Buffalo Fingers", "Appetizer", 6.95),
            ("Buffalo Wings", "Appetizer", 9.5),
            ("Potato Skins", "Appetizer", 8.5),
            ("Mashroom Caps", "Appetizer", 10.5),
            ("Shrimp Cocktail", "Appetizer", 12.5),
            ("Chips and Salsa", "Appetizer",6.5),
            ("Chicken Alfredo", "Main Course", 13.95),
            ("Sea Food Alfredo", "Main Course", 15.95),
            ("Chicken Picatta", "Main Course", 13.95),
            ("Turcky Club", "Main Course", 11.95),
            ("Lobester Pie", "Main Course", 19.95),
            ("Prime Rip", "Main Course", 20.95),
            ("Chicken Alfredo", "Main Course", 13.95),
            ("Apple Pie", "Dessert", 5.5),
            ("Carrot cake", "Dessert", 6.5),
            ("Apple crisp", "Dessert", 5.59),
        };
        public Form1()
        {
            InitializeComponent();
            LoadMenuItems();
        }
        private void LoadMenuItems()
        {
            foreach (var item in menuItems)
            {
                switch (item.Category)
                {
                    case "Beverage":
                       comboBreverage.Items.Add(item.Name);
                        break;
                    case "Appetizer":
                        compoAppetizer.Items.Add(item.Name);
                        break;
                    case "Main Course":
                        comboMain.Items.Add(item.Name);
                        break;
                    case "Dessert":
                        comboDessert.Items.Add(item.Name);
                        break;
                }
            }
        }
        private void CalculateBill_Click(object sender, EventArgs e)
        {
            double subtotal = 0;
            subtotal += GetItemPrice(comboBreverage.SelectedItem?.ToString());
            subtotal += GetItemPrice(compoAppetizer.SelectedItem?.ToString());
            subtotal += GetItemPrice(comboMain.SelectedItem?.ToString());
            subtotal += GetItemPrice(comboDessert.SelectedItem?.ToString());

           
            double tax = subtotal * 0.16; 
            double total = subtotal + tax;

           
            txtSubtotal.Text = subtotal.ToString("F2"); 
            txtTax.Text = tax.ToString("F2");
            txtTotal.Text = total.ToString("F2");
        }

        private double GetItemPrice(string itemName)
        {
            foreach (var item in menuItems)
            {
                if (item.Name == itemName)
                    return item.Price;
            }
            return 0;
        }
        private void ClearBill_Click(object sender, EventArgs e)
        {

            comboBreverage.SelectedIndex = -1;
           compoAppetizer.SelectedIndex = -1;
            comboMain.SelectedIndex = -1;
            comboDessert.SelectedIndex = -1;

            txtSubtotal.Text = "$0.00";
            txtTax.Text = "$0.00";
            txtTotal.Text = "$0.00";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearBill_Click();
        }

        private void ClearBill_Click()
        {
        }
    }

   
}

        

