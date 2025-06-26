namespace WebAPIDemo
{
    public class ProductService
    {
        public Product GetProductByID(int id, out Product ?product) //out yêu cầu biến có giá trị dù có là null hay không, ? = nullable
        {
            if (id < 0)
            {
                throw new ArgumentNullException(nameof(id), "Product ID cannot be null");
            }
            product = ProductList.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found");
            }
            return product;
        }
        public List<Product> GetAllProducts()
        {
            return ProductList.Products;
        }
        public void AddProducts(List<Product> products)
        {
            if (products == null)
            {
                throw new ArgumentNullException(nameof(products), "Product list cannot be null");
            }
            products.AddRange(ProductList.Products);
        }
        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            }
            ProductList.Products.Add(product);
        }
        public void UpdateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
                //nameof(product) returns the name of the variable as a string
            }
            var existingProduct = ProductList.Products.FirstOrDefault(p => p.Id == product.Id);
            //Default return default value, ex: int => 0, string => null    

            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product with ID {product.Id} not found");
            }
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
        }
        public void DeleteProductByID(int id)
        {
            var product = ProductList.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found");
            }
            ProductList.Products.Remove(product);
        }
    }
}
