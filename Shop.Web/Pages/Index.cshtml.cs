using Harambee.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Shop.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;


        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<string> Category { get; set; }

        [BindProperty(SupportsGet = true)]

        public List<Product> Products { get; set; }

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public string SortBy { get; set; }


        public async Task OnGet()
        {
            var response = await _httpClient.GetAsync("https://localhost:7071/api/products");

            // Get all products
            var products = new List<Product>()
    {
        new Product { Id = 1, Name = "Samsung TV", Category = "Tv", Price = 799.99M },
        new Product { Id = 2, Name = "Sony Radio", Category = "Radio", Price = 99.99M },
        new Product { Id = 3, Name = "Canon Camera", Category = "Camera", Price = 549.99M },
        new Product { Id = 4, Name = "LG TV", Category = "Tv", Price = 899.99M },
        new Product { Id = 5, Name = "Bose Radio", Category = "Radio", Price = 149.99M },
        new Product { Id = 6, Name = "Nikon Camera", Category = "Camera", Price = 449.99M }
    };

            // Filter by search string and category
            Products = products
                .Where(p => string.IsNullOrEmpty(SearchString) || p.Name.Contains(SearchString))
                .Where(p => Category == null || Category.Count == 0 || Category.Contains(p.Category))
                .ToList();

            // Sort by price
            if (SortBy == "PriceAsc")
            {
                Products = Products.OrderBy(p => p.Price).ToList();
            }
            else if (SortBy == "PriceDesc")
            {
                Products = Products.OrderByDescending(p => p.Price).ToList();
            }
        }
    }
}