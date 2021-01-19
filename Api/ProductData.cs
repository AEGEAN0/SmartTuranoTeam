using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public interface IProductData
    {
        Task<Product> AddProduct(Product product);
        Task<bool> DeleteProduct(int id);
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> UpdateProduct(Product product);
    }

    public class ProductData : IProductData
    {
        private readonly List<Product> products = new List<Product>
        {
            new Product
            {
                Id = 10,
                Name = "Lucio",
                Description = "/Image/lucio1.jpg",
                Quantity = 1
            },
            new Product
            {
                Id = 20,
                Name = "Mark",
                Description = "/Image/mark1.jpg",
                Quantity = 1
            },
            new Product
            {
                Id = 30,
                Name = "Pier",
                Description = "/Image/pier1.jpg",
                Quantity = 1
            },
            new Product
            {
                Id = 30,
                Name = "Robert",
                Description = "/Image/robert1.jpg",
                Quantity = 1
            }
        };

        private int GetRandomInt()
        {
            var random = new Random();
            return random.Next(100, 1000);
        }

        public Task<Product> AddProduct(Product product)
        {
            product.Id = GetRandomInt();
            products.Add(product);
            return Task.FromResult(product);
        }

        public Task<Product> UpdateProduct(Product product)
        {
            var index = products.FindIndex(p => p.Id == product.Id);
            products[index] = product;
            return Task.FromResult(product);
        }

        public Task<bool> DeleteProduct(int id)
        {
            var index = products.FindIndex(p => p.Id == id);
            products.RemoveAt(index);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Product>> GetProducts()
        {
            return Task.FromResult(products.AsEnumerable());
        }
    }
}
