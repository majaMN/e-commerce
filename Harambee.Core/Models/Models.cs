using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harambee.Core.Models
{
    //public record Customer(int Id, string FirstName, string LastName, string Email, List<Product> Cart = null);
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Product> Cart { get; set; } = new List<Product>();
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int BulkQuantity { get; set; }
        public decimal BulkDiscount { get; set; }
        public string Category { get; set; }
    }


}
