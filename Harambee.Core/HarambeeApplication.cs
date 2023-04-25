using Harambee.Core.Models;
using Harambee.Core.Repository;

namespace Harambee.Core
{
    public class HarambeeApplication : IHarambeeApplication
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductsRepository _productRepository;

        public HarambeeApplication(ICustomerRepository customerRepository, IProductsRepository productRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }
 

        public async Task<bool> AddProductToBasket(int customerId, int productId)
        {
            List<string> errors = new List<string>();
            try
            {
                _customerRepository.AddProductToBasket(customerId, productId);
                return true;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public async Task<decimal?> GetCartTotal(int id)
        {
            return _customerRepository.GetCartTotal(id);
        }
    }
}
