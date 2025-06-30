using WebAPIDemo.Data;
using WebAPIDemo.Models;

namespace WebAPIDemo.Services
{
    public class ProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "AppDbContext cannot be null");
        }
        public Guid? instanceID;

        public ProductService()
        {
            if (instanceID == null || instanceID == Guid.Empty)
            {
                instanceID = Guid.NewGuid(); // Initialize instanceID only once
            }
        }
        public Product GetProductByID(int id)
        {
            var found = _context.Products.Find(id);
            if (found == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found");
            }
            return found;
        }
        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
        public void AddProduct(ProductDTO productDto)
        {
            var product = new Product
            {
                Id = RandomID(), // Generate a unique ID
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price
            };
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void UpdateProduct(ProductDTO productDTO, int ID)
        {
            if (ID < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(ID), "Product ID cannot be negative.");
            }

        }
        private int RandomID()
        {
            Random random = new Random();
            int id;
            do
            {
                id = random.Next(1, 1000); // Generate a random ID between 1 and 1000
            } while (ProductList.Products.Any(p => p.Id == id)); // Ensure the ID is unique
            return id;
        }
       /* public Product GetProductByID(int id) //out yêu cầu biến có giá trị dù có là null hay không, ? = nullable
        {
            var found = FindByID(id);
            if (found == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found");
            }
            return found ;
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
        public void AddProduct(ProductDTO product)
        {
            var _product = new Product
            {
                Id = RandomID(), // Generate a unique ID
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
            };
            ProductList.Products.Add(_product);
        }
        public void UpdateProduct(ProductDTO product, int ID)
        {
           
            var existingProduct = FindByID(ID);   

            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product with ID {ID} not found");
            }
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
        }
        public void DeleteProductByID(int id)
        {
          
            var existingProduct = FindByID(id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found");
            }
            ProductList.Products.Remove(existingProduct);
        }
        private Product? FindByID(int ID)
        {
            if (ID < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(ID), "Product ID cannot be negative.");
            }

            return ProductList.Products.FirstOrDefault(p => p.Id == ID);
        }
        private int RandomID()
        {
            Random random = new Random();
            int id;
            do
            {
                id = random.Next(1, 1000); // Generate a random ID between 1 and 1000
            } while (ProductList.Products.Any(p => p.Id == id)); // Ensure the ID is unique
            return id;
        }*/
    }
}
