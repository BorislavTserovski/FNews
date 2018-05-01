using AutoMapper.QueryableExtensions;
using FakeNews.Data;
using FakeNews.Data.Models;
using FakeNews.Services.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FakeNews.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly FakeNewsDbContext db;

        public UserService(FakeNewsDbContext db)
        {
            this.db = db;
        }

        public async Task ClearFoodAndDrinksList(string userId)
        {
            var user = this.db.Users.Where(u => u.Id == userId).FirstOrDefault();
            foreach (var product in this.db.Products)
            {
                if (product.UserId == userId)
                {
                    product.UserId = null;
                }
            }
            user.MyProducts.Clear();
            await this.db.SaveChangesAsync();
        }

        public async Task<UserWithProductsServiceModel> MyProducts(string userId)
        => await this.db.Users
            .Where(u => u.Id == userId)
            .ProjectTo<UserWithProductsServiceModel>()
            .FirstOrDefaultAsync();

        public async Task SendMessage(string userId, string content)
        {
            Message message = new Message
            {
                Content = content,
                UserId = userId
            };

            if (message == null)
            {
                return;
            }

            this.db.Add(message);
            await this.db.SaveChangesAsync();
        }
    }
}