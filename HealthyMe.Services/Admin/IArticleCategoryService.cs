namespace FakeNews.Services.Admin
{
    using FakeNews.Services.Admin.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IArticleCategoryService
    {
        Task<IEnumerable<ArticleCategoriesListingModel>> AllAsync();

        Task Add(string name);

        Task<ArticleCategoriesListingModel> GetByIdAsync(int id);

        Task Delete(int id);
    }
}
