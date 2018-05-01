namespace FakeNews.Services.Admin.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using FakeNews.Data;
    using FakeNews.Data.Models;
    using FakeNews.Services.Admin.Models;
    using Microsoft.EntityFrameworkCore;

    public class ArticleCategoryService : IArticleCategoryService
    {
        private readonly FakeNewsDbContext db;

        public ArticleCategoryService(FakeNewsDbContext db)
        {
            this.db = db;
        }

        public async Task Add(string name)
        {
            var category = new ArticleCategory
            {
                Name = name,
            };

            this.db.Add(category);
            await this.db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ArticleCategoriesListingModel>> AllAsync()
         => await this.db.ArticleCategories
            .OrderBy(p => p.Id)
            .ProjectTo<ArticleCategoriesListingModel>()
            .ToListAsync();
        

        public async Task Delete(int id)
        {
            var articleCategory = this.db.ArticleCategories.Where(ac => ac.Id == id).FirstOrDefault();

            if (articleCategory == null)
            {
                return;
            }

            this.db.ArticleCategories.Remove(articleCategory);

            await this.db.SaveChangesAsync();
        }

        public async Task<ArticleCategoriesListingModel> GetByIdAsync(int id)
        => await
            this.db.ArticleCategories
                .Where(ac => ac.Id == id)
                .ProjectTo<ArticleCategoriesListingModel>()
                .FirstOrDefaultAsync();


    }
}
