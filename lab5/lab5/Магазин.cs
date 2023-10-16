using System;
using System.Collections.Generic;
class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }

    public Product(string name, double price, string description, string category)
    {
        Name = name;
        Price = price;
        Description = description;
        Category = category;
    }
}
class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public List<Order> PurchaseHistory { get; set; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
        PurchaseHistory = new List<Order>();
    }
}
class Order
{
    public List<Product> Products { get; set; }
    public List<int> Quantities { get; set; }
    public double TotalCost { get; set; }
    public string Status { get; set; }

    public Order(List<Product> products, List<int> quantities, double totalCost, string status)
    {
        Products = products;
        Quantities = quantities;
        TotalCost = totalCost;
        Status = status;
    }
}

interface ISearchable
{
    List<Product> SearchByPrice(double maxPrice);
    List<Product> SearchByCategory(string category);
}

class Shop : ISearchable
{
    private List<User> Users;
    private List<Product> Products;
    private List<Order> Orders;

    public Shop()
    {
        Users = new List<User>();
        Products = new List<Product>();
        Orders = new List<Order>();
    }

    public void AddUser(User user)
    {
        Users.Add(user);
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public void PlaceOrder(User user, List<Product> products, List<int> quantities)
    {
        double totalCost = CalculateTotalCost(products, quantities);
        Order order = new Order(products, quantities, totalCost, "Pending");
        user.PurchaseHistory.Add(order);
        Orders.Add(order);
    }

    private double CalculateTotalCost(List<Product> products, List<int> quantities)
    {
        double totalCost = 0;
        for (int i = 0; i < products.Count; i++)
        {
            totalCost += products[i].Price * quantities[i];
        }
        return totalCost;
    }

    public List<Product> SearchByPrice(double maxPrice)
    {
        List<Product> result = new List<Product>();
        foreach (var product in Products)
        {
            if (product.Price <= maxPrice)
            {
                result.Add(product);
            }
        }
        return result;
    }

    public List<Product> SearchByCategory(string category)
    {
        List<Product> result = new List<Product>();
        foreach (var product in Products)
        {
            if (product.Category == category)
            {
                result.Add(product);
            }
        }
        return result;
    }


    public static void Main(string[] args)
    {
    }
}

