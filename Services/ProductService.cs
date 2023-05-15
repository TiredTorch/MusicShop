using MusicShopc.Models;

namespace MusicShopc.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> CreateProduct(Product product);
        Task<bool> UpdateProduct(int id, Product updatedProduct);
        Task<bool> DeleteProduct(int id);
    }

    public class ProductService : IProductService
    {
        private readonly List<Product> _products;

        public ProductService()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Guitar", Price = 21},
                new Product { Id = 2, Name = "Guitar", Price = 22},
                new Product { Id = 3, Name = "Guitar", Price = 23},
                new Product { Id = 4, Name = "Guitar", Price = 42},
                new Product { Id = 5, Name = "Guitar", Price = 25},
                new Product { Id = 6, Name = "Guitar", Price = 26},
                new Product { Id = 7, Name = "Guitar", Price = 72},
                new Product { Id = 8, Name = "Guitar", Price = 28},
                new Product { Id = 9, Name = "Guitar", Price = 29},
            };
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await Task.FromResult(_products);
        }

        public async Task<Product> CreateProduct(Product product)
        {
            _products.Add(product);
            return await Task.FromResult(product);
        }

        public async Task<bool> UpdateProduct(int id, Product updatedProduct)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return false;

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;

            return true;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return false;

            _products.Remove(product);
            return true;
        }
    }


}
