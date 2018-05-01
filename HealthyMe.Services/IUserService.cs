using FakeNews.Services.Models;
using System.Threading.Tasks;

namespace FakeNews.Services
{
    public interface IUserService
    {
        Task<UserWithProductsServiceModel> MyProducts(string userId);

        Task ClearFoodAndDrinksList(string userId);

        Task SendMessage(string userId, string content);
    }
}