using Harambee.Core.Models;

namespace Harambee.Core.Repository
{
    public interface IProductsRepository
    {
        IEnumerable<Product> GetAllProducts();
    
    }
}
