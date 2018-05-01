using FakeNews.Data.Models;
using FakeNews.Services.Models;
using FakeNews.Services.Writer.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FakeNews.Services.Writer
{
    public interface IWriterArticleService
    {
        Task CreateAsync(string title, string content, string authorId, IFormFile file, int CategoryId);

        Task<IEnumerable<WriterArticleListingServiceModel>> AllAsync(int page = 1);

        Task<int> TotalAsync();

        Task<WriterArticleDetailsServiceModel> ById(int id);

        Task Delete(int id);

        Task<ArticleDeleteModel> GetArticleById(int id);

        Task Like(int id);

        Task Dislike(int id);

        List<ArticleCategory> GetPosibleCategories();
    }
}