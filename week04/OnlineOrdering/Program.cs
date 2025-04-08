using System;
using System.Collections.Generic;

class Address
{
    private string street, city, state, country;
    public Address(string st, string c, string s, string co) { street = st; city = c; state = s; country = co; }
    public bool IsInUSA() => country == "USA";
    public override string ToString() => $"{street}\n{city}, {state}\n{country}";
}

class Customer
{
    private string name; private Address address;
    public Customer(string n, Address a) { name = n; address = a; }
    public bool LivesInUSA() => address.IsInUSA();
    public override string ToString() => $"{name}\n{address}";
}

class Product
{
    private string name, id; private double price; private int quantity;
    public Product(string n, string i, double p, int q) { name = n; id = i; price = p; quantity = q; }
    public double GetTotalCost() => price * quantity;
    public override string ToString() => $"{name} (ID: {id}) x{quantity}";
}

class Order
{
    private List<Product> products = new List<Product>(); private Customer customer;
    public Order(Customer c) { customer = c; }
    public void AddProduct(Product p) => products.Add(p);
    public double GetTotalPrice() => products.Sum(p => p.GetTotalCost()) + (customer.LivesInUSA() ? 5 : 35);
    public string GetPackingLabel() => string.Join("\n", products);
    public string GetShippingLabel() => customer.ToString();
}

class Program
{
    static void Main()
    {
        var customer1 = new Customer("Alice", new Address("123 Main St", "New York", "NY", "USA"));
        var customer2 = new Customer("Bob", new Address("456 Elm St", "Toronto", "ON", "Canada"));
        
        var order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "A1", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "B2", 25.50, 2));
        
        var order2 = new Order(customer2);
        order2.AddProduct(new Product("Keyboard", "C3", 49.99, 1));
        order2.AddProduct(new Product("Monitor", "D4", 150.00, 1));
        
        Console.WriteLine("Order 1:\nPacking Label:\n" + order1.GetPackingLabel());
        Console.WriteLine("\nShipping Label:\n" + order1.GetShippingLabel());
        Console.WriteLine("\nTotal Price: $" + order1.GetTotalPrice());
        
        Console.WriteLine("\nOrder 2:\nPacking Label:\n" + order2.GetPackingLabel());
        Console.WriteLine("\nShipping Label:\n" + order2.GetShippingLabel());
        Console.WriteLine("\nTotal Price: $" + order2.GetTotalPrice());
    }
}
