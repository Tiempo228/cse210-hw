using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Online Ordering System");
        Console.WriteLine("======================\n");

        // Create addresses
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Oak Ave", "Toronto", "Ontario", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Smith", address1);
        Customer customer2 = new Customer("Emma Johnson", address2);

        // Create products
        Product product1 = new Product("Laptop", "LAP1001", 899.99, 1);
        Product product2 = new Product("Wireless Mouse", "MSE2001", 25.50, 2);
        Product product3 = new Product("USB-C Cable", "CBL3001", 15.75, 3);
        Product product4 = new Product("Monitor", "MON4001", 299.99, 1);
        Product product5 = new Product("Keyboard", "KEY5001", 79.99, 1);

        // Create first order (USA customer)
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        // Create second order (International customer)
        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product2); // Adding mouse again

        // Display order information
        DisplayOrder(order1);
        Console.WriteLine("\n" + new string('=', 50) + "\n");
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetOrderSummary());
    }
}