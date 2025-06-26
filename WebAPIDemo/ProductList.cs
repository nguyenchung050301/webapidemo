namespace WebAPIDemo
{
    public static class ProductList
    {
        public static List<Product> Products { get; } = new List<Product>
        {
            new Product(1, "Laptop", "High performance laptop", 999.99m),
            new Product(2, "Smartphone", "Latest model smartphone", 699.99m),
            new Product(3, "Tablet", "Portable tablet with stylus support", 499.99m),
            new Product(4, "Smartwatch", "Fitness tracking smartwatch", 199.99m),
            new Product(5, "Headphones", "Noise-cancelling over-ear headphones", 149.99m)
        };
    }
}
