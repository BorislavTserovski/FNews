using System;
namespace FakeNews.Web.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using FakeNews.Data;
    using FakeNews.Data.Models;
    using FakeNews.Services.Admin;
    using FakeNews.Services.Admin.Models;

    [Area("Admin")]
    public class ArticleCategoriesController : Controller
    {
        private readonly IArticleCategoryService categories;

        public ArticleCategoriesController(IArticleCategoryService categories)
        {
            this.categories = categories;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.categories.AllAsync());
        }


        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArticleCategoriesListingModel model)
        {
            if (ModelState.IsValid)
            {
                await this.categories.Add(model.Name);
                return RedirectToAction(nameof(Index));
            }
            return View(model);

        }
        
        public async Task<IActionResult> Delete(int id)
        {
            ArticleCategoriesListingModel model = await this.categories.GetByIdAsync(id);

            if (model == null)
            {
                return NotFound();
            }


            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.categories.Delete(id);

            return RedirectToAction(nameof(Index));
        }

       
    }
}
