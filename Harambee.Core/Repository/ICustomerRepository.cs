
namespace Harambee.Core.Repository
{
    public interface ICustomerRepository
    {
        bool AddProductToBasket(int customerId, int productId);
       decimal GetCartTotal(int id);
    }
}
