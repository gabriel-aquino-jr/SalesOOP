/*
 * AUTHOR: Gabriel Aquino
 * DATE: 01/15/2023
 * PURPOSE: Simple OOP Sales Entities
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SalesOOP
{
    public class Customer
    {
        public Customer(int customerId, string cardNumber)
        {
            CustomerId = customerId;
            CardNumber = cardNumber;
        }

        public int CustomerId { get; set; }
        public string CardNumber { get; set; }        
    }

    public class Order
    {
        public Order(int orderId, Customer customer, DateTime datePurchase, List<OrderItem> items)
        {
            OrderId = orderId;
            Customer = customer;
            DatePurchase = datePurchase;
            Items = items;
        }

        public int OrderId { get; set;}

        public Customer Customer { get; set; }

        public DateTime DatePurchase { get; set; }

        public List<OrderItem> Items { get; set; }

        public decimal OrderTotal
        {
            get
            {                
                return Items.Sum(i => i.TotalItemAmount);
            }
        }

        public double TotalItems
        {
            get
            {
                return Items.Sum(i => i.Quantity);
            }
        }

        public override string ToString()
        {
            string lineBar = "-----------------------------------------------------------";
            string header = $"\t\t\tSales Store\r\n";
            header += $"\t\tDate { this.DatePurchase}\r\n";
            header += $"{lineBar}\r\n";
            header += $"#\tItem\t\tQty\tUnit Price\tTotalPrice\r\n";
            string details = "";
            foreach (OrderItem item in Items)
            {
                details += $"{item.ItemNum}\t{item.Product.ProductName}\t\t{item.Quantity}\t{item.Product.Price:c2}\t\t{item.TotalItemAmount:c2}\r\n";
            }
            string footer = $"{lineBar}\r\n";
            footer += $"{this.TotalItems} Items\t\t\t\tOrder Total:\t{this.OrderTotal:c2}\r\n";
            footer += $"{lineBar}\r\n";
            footer += "TYPE:  PURCHASE\r\n";
            footer += $"ACCT:  FLASH DEFAULT\t\t\tCAD$ {this.OrderTotal:c2}\r\n";
            footer += "Card Type:  DEBIT\r\n";
            string fullCardNumber = this.Customer.CardNumber;
            footer += $"CARD NUMBER:\t ****.****.****{fullCardNumber.Substring(fullCardNumber.LastIndexOf("."))} ";



            return header + details + footer;
        }
    }

    public class OrderItem
    {
        public OrderItem(int itemNum, Product product, double quantity)
        {
            ItemNum = itemNum;
            Product = product;
            Quantity = quantity;
        }

        public int ItemNum { get; set; }
        public Product Product { get; set; }
        public double Quantity { get; set; }

        public decimal TotalItemAmount {
            get
            {
                return Product.Price * Convert.ToDecimal( Quantity );
            }
        }
    }

    public class Product
    {
        public Product(int productId, string productName, decimal price)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }

}
