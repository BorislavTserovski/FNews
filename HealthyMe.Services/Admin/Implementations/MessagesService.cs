using AutoMapper.QueryableExtensions;
using FakeNews.Data;
using FakeNews.Services.Admin.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeNews.Services.Admin.Implementations
{
    public class MessagesService : IMessagesService
    {
        private readonly FakeNewsDbContext db;

        public MessagesService(FakeNewsDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<MessagesListingModel>> AllAsync()
        => await this.db
            .Messages
            .ProjectTo<MessagesListingModel>()
            .ToListAsync();

        public async Task Delete(int id)
        {
            var message = await this.db.Messages.FirstOrDefaultAsync();

            this.db.Remove(message);

            await this.db.SaveChangesAsync();
        }

        public async Task<MessagesListingModel> GetById(int id)
       => await this.db.Messages.Where(m => m.Id == id)
            .ProjectTo<MessagesListingModel>()
            .FirstOrDefaultAsync();
    }
}