
namespace FakeNews.Services.Admin.Models
{
    using FakeNews.Common.Mapping;
    using FakeNews.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ArticleCategoriesListingModel : IMapFrom<ArticleCategory>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
