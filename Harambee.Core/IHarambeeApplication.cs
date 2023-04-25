using Harambee.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harambee.Core
{
    public interface IHarambeeApplication
    {
      
        Task<bool> AddProductToBasket(int customerId, int productId);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<decimal?> GetCartTotal(int id);
    }
}
