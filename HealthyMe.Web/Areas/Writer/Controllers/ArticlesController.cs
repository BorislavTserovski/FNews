using FakeNews.Data.Models;
using FakeNews.Services.Html;
using FakeNews.Services.Models;
using FakeNews.Services.Writer;
using FakeNews.Web.Areas.Writer.Models.Articles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;

namespace FakeNews.Web.Areas.Writer.Controllers
{
    [Area(WebConstants.WriterArea)]
    [Authorize(Roles = WebConstants.WriterRole)]
    public class ArticlesController : Controller
    {
        private readonly IHtmlService html;
        private readonly IWriterArticleService articles;
        private readonly UserManager<User> userManager;

        public ArticlesController(IHtmlService html, IWriterArticleService articles, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.articles = articles;
            this.html = html;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1)
        => View(new ArticleListingViewModel
        {
            Articles = await this.articles.AllAsync(page),
            TotalArticles = await this.articles.TotalAsync(),
            CurrentPage = page
        });

        public IActionResult Create()
        {
            PublishArticleFormModel model = new PublishArticleFormModel();
            model.Categories = this.articles.GetPosibleCategories();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PublishArticleFormModel model, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Content = this.html.Sanitize(model.Content);
            var userId = this.userManager.GetUserId(User);
            await this.articles.CreateAsync(model.Title, model.Content, userId, file, model.CategoryId);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            ArticleDeleteModel article = await this.articles.GetArticleById(id);

            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        [HttpPost]
        public async Task<IActionResult>Like(int id)
        {
            await this.articles.Like(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Dislike(int id)
        {
            await this.articles.Dislike(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Destroy(int id)
        {
            await this.articles.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}