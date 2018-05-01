using AutoMapper.QueryableExtensions;
using FakeNews.Data;
using FakeNews.Data.Models;
using FakeNews.Services.Models;
using FakeNews.Services.Writer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FakeNews.Services.Writer.Implementations
{
    public class WriterArticleService : IWriterArticleService
    {
        private FakeNewsDbContext db;

        public WriterArticleService(FakeNewsDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<WriterArticleListingServiceModel>> AllAsync(int page = 1)
        => await this.db.Articles
            .OrderByDescending(a => a.PublishDate)
            .Skip((page - 1) * ServiceConstants.ArticlePageSize)
            .Take(ServiceConstants.ArticlePageSize)
            .ProjectTo<WriterArticleListingServiceModel>()
            .ToListAsync();

        public async Task<WriterArticleDetailsServiceModel> ById(int id)
       => await this.db.Articles
            .Where(a => a.Id == id)
            .ProjectTo<WriterArticleDetailsServiceModel>()
            .FirstOrDefaultAsync();

        public async Task CreateAsync(string title, string content, string authorId, IFormFile file, int categoryId)
        {
            ArticleCategory category = await db.ArticleCategories
                .Where(ac => ac.Id == categoryId).FirstOrDefaultAsync();
            var article = new Article
            {
                Title = title,
                Content = content,
                PublishDate = DateTime.UtcNow,
                AuthorId = authorId,
                ArticleCategoryId = categoryId,
                ArticleCategory = category
            };
            using (MemoryStream ms = new MemoryStream())
            {
                if (file != null)
                {
                    file.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                    article.Image = array;
                }
            }

            this.db.Add(article);

            await this.db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var article = this.db.Articles.FirstOrDefault(a => a.Id == id);
            if (article == null)
            {
                return;
            }
            this.db.Remove(article);
            await this.db.SaveChangesAsync();
        }

        public async Task<int> TotalAsync()
        => await this.db.Articles.CountAsync();

        public async Task<ArticleDeleteModel> GetArticleById(int id)
      => await this.db.Articles.Where(a => a.Id == id)
            .ProjectTo<ArticleDeleteModel>()
            .FirstOrDefaultAsync();

        public List<ArticleCategory> GetPosibleCategories()
        {
            return this.db.ArticleCategories.OrderBy(ac => ac.Id)
                   .ToList();
        }

        public async Task Like(int id)
        {
           Article article = await this.db.Articles.Where(a => a.Id == id)
            .FirstOrDefaultAsync();

            article.Likes++;

            await this.db.SaveChangesAsync();
        }

        public async Task Dislike(int id)
        {
            Article article = await this.db.Articles.Where(a => a.Id == id)
             .FirstOrDefaultAsync();

            article.Dislikes++;

            await this.db.SaveChangesAsync();
        }
    }
}