/*
 * AUTHOR: Gabriel Aquino
 * DATE: 01/15/2023
 * PURPOSE: Simple OOP Sales Entities
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer(1, "1111.2222.3333.4444");

            Product p1 = new Product(1, "Milk", 3.99m);
            Product p2 = new Product(2, "Coffee", 7.99m);
            Product p3 = new Product(3, "Butter", 4.99m);
            Product p4 = new Product(4, "Bun", 6.99m);

            OrderItem oi1 = new OrderItem(1, p1, 3);
            OrderItem oi2 = new OrderItem(2, p2, 1);

            List<OrderItem> l1 = new List<OrderItem>();
            l1.Add(oi1);
            l1.Add(oi2);

            Order o1 = new Order(1, c1, new DateTime(2022, 01, 15, 20, 12, 0, 0), l1);

            Console.WriteLine(o1.ToString());
            Console.ReadLine();

        }
    }
}
