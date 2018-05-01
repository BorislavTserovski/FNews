namespace FakeNews.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ArticleCategory
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Article> Articles { get; set; } = new List<Article>();
    }
}
