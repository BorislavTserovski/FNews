using FakeNews.Data.Models;
using FakeNews.Services.Admin.Models;
using FakeNews.Web.Areas.Admin.Models.Products;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FakeNews.Services.Admin
{
    public interface IProductService
    {
        Task<IEnumerable<ProductListingModel>> AllAsync(int page = 1);

        Task Create(string name, Category category, int energy, double fats,
            double proteins, double sugars, IFormFile file);

        Task Delete(int id);

        Task<ProductViewModel> GetByIdAsync(int id);

        Task<IEnumerable<ProductListingModel>> Search(string SearchBy, string searchTerm);

        Task AddToDay(int id, string userId);

        Product GetProductById(int id);

        Task<int> TotalAsync();
    }
}