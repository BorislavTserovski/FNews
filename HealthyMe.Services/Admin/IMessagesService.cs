using FakeNews.Services.Admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FakeNews.Services.Admin
{
    public interface IMessagesService
    {
        Task<IEnumerable<MessagesListingModel>> AllAsync();

        Task Delete(int id);

        Task<MessagesListingModel> GetById(int id);
    }
}