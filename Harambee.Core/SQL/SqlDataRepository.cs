using Harambee.Core.Models;
using Harambee.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace Harambee.Data.SQL
{
    public class SqlDataRepository : ICustomerRepository, IProductsRepository
    {
        private readonly ShopDbContext _dbContext;

        public SqlDataRepository(ShopDbContext shopDbContext)
        {
            _dbContext = shopDbContext;
        }

        public bool AddProductToBasket(int customerId, int productId)
        {
            var customer = _dbContext.Customers.Include(c => c.Cart).FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
            {
                throw new Exception("Customer does not exist");
            }
            var product = _dbContext.Products.Find(productId);
            if (product == null)
            {
                throw new Exception("Product does not exist");
            }
            customer.Cart.Add(product);
            if (customer.Cart.Count(p => p.Id == productId) >= product.BulkQuantity)
            {
                var totalDiscount = product.Price * customer.Cart.Count(p => p.Id == productId) * product.BulkDiscount;
                customer.Cart.ForEach(p =>
                {
                    if (p.Id == productId)
                    {
                        p.Price -= totalDiscount / customer.Cart.Count;
                    }
                });
            }
            _dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<Product> GetAllProducts() => _dbContext.Products.ToList();

        public decimal GetCartTotal(int id)
        {
            var customer = _dbContext.Customers.Include(c => c.Cart).FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new Exception("Customer does not exist");
            }
            return customer.Cart.Sum(p => p.Price);
        }

        public Product GetProduct(int id) => _dbContext.Products.FirstOrDefault(c => c.Id == id);      
    }
}
