using FakeNews.Data;
using FakeNews.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FakeNews.Web.Areas.Writer.Models.Articles
{
    public class PublishArticleFormModel
    {
       
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public int CategoryId { get; set; }

        public ArticleCategory Category { get; set; }

        [Required]
        [MinLength(5)]
        public string Content { get; set; }

        public List<ArticleCategory> Categories { get; set; } = new List<ArticleCategory>();

        public byte[] Image { get; set; }
    }
}