public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        // Add shipping cost
        total += GetShippingCost();
        return total;
    }

    private double GetShippingCost()
    {
        return _customer.IsInUSA() ? 5 : 35;
    }

    public string GetPackingLabel()
    {
        string label = "PACKING LABEL:\n";
        label += "====================\n";
        foreach (Product product in _products)
        {
            label += $"Product: {product.GetName()}\n";
            label += $"ID: {product.GetProductId()}\n";
            label += $"Quantity: {product.GetQuantity()}\n";
            label += "--------------------\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        string label = "SHIPPING LABEL:\n";
        label += "====================\n";
        label += $"Customer: {_customer.GetName()}\n";
        label += $"Address:\n{_customer.GetAddress().GetFullAddress()}\n";
        return label;
    }

    public string GetOrderSummary()
    {
        string summary = "ORDER SUMMARY:\n";
        summary += "====================\n";
        summary += $"Number of Items: {_products.Count}\n";
        summary += $"Shipping Cost: ${GetShippingCost()}\n";
        summary += $"Total Cost: ${CalculateTotalCost()}\n";
        return summary;
    }
}