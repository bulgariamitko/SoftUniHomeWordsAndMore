using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Orders.Models;

namespace Orders
{
    internal class Program
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var dataMapper = new DataMapper();
            var allCategories = dataMapper.GetAllCategories();
            var allProducts = dataMapper.GetAllProducts();
            var allOrders = dataMapper.GetAllOrders();

            // Names of the 5 most expensive products
            IEnumerable<Product> products = allProducts as Product[] ?? allProducts.ToArray();
            var top5MostExpensiveProducts = products
                .OrderByDescending(p => p.UnitPrice)
                .Take(5)
                .Select(p => p.Name);
            Console.WriteLine(string.Join(Environment.NewLine, top5MostExpensiveProducts));

            Console.WriteLine(new string('-', 10));

            // Number of products in each Category
            var NumsOfProducts = products
                .GroupBy(p => p.CategoryId)
                .Select(grp => new { Category = allCategories.First(category => category.Id == grp.Key).Name, Count = grp.Count() })
                .ToList();
            foreach (var item in NumsOfProducts)
            {
                Console.WriteLine("{0}: {1}", item.Category, item.Count);
            }

            Console.WriteLine(new string('-', 10));

            // The 5 top products (by Order quantity)
            var orders = allOrders as Order[] ?? allOrders.ToArray();
            var top5Products = orders
                .GroupBy(order => order.ProductId)
                .Select(grouping => new { Product = products.First(product => product.Id == grouping.Key).Name, Quantities = grouping.Sum(order => order.Quantity) })
                .OrderByDescending(arg => arg.Quantities)
                .Take(5);
            foreach (var item in top5Products)
            {
                Console.WriteLine("{0}: {1}", item.Product, item.Quantities);
            }

            Console.WriteLine(new string('-', 10));

            // The most profitable Category
            var mostProfitableCategory = orders
                .GroupBy(order => order.ProductId)
                .Select(grouping => new {products.First(product => product.Id == grouping.Key).CategoryId, price = products.First(product => product.Id == grouping.Key).UnitPrice, quantity = grouping.Sum(order => order.Quantity) })
                .GroupBy(group => group.CategoryId)
                .Select(grouping => new { category_name = allCategories.First(category => category.Id == grouping.Key).Name, total_quantity = grouping.Sum(arg => arg.quantity * arg.price) })
                .OrderByDescending(arg => arg.total_quantity)
                .First();
            Console.WriteLine("{0}: {1}", mostProfitableCategory.category_name, mostProfitableCategory.total_quantity);
        }
    }
}