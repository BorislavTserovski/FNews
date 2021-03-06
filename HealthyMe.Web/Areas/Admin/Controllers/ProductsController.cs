﻿using FakeNews.Services.Admin;
using FakeNews.Web.Areas.Admin.Models.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FakeNews.Web.Areas.Admin.Controllers
{
    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class ProductsController : Controller
    {
        private readonly IProductService products;

        public ProductsController(IProductService products)
        {
            this.products = products;
        }

        public async Task<IActionResult> Index(int page = 1)
         => View(new ProductListingViewModel
         {
             Products = await this.products.AllAsync(page),
             TotalProducts = await this.products.TotalAsync(),
             CurrentPage = page
         });

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductFormModel model, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await this.products.Create(model.Name, model.Category, model.Energy, model.Fat
                , model.Protein, model.Sugars, file);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await this.products.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Destroy(int id)
        {
            await this.products.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}