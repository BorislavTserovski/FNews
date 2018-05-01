using AutoMapper;
using FakeNews.Common.Mapping;
using FakeNews.Data.Models;
using System;

namespace FakeNews.Services.Writer.Models
{
    public class WriterArticleListingServiceModel : IMapFrom<Article>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public byte[] Image { get; set; }

        public string Author { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public string ArticleCategoryName { get; set; }

        public void ConfigureMapping(Profile mapper)
        { 
             mapper.CreateMap<Article, WriterArticleListingServiceModel>()
            .ForMember(a => a.Author, cfg => cfg.MapFrom(a => a.Author.UserName));

            mapper.CreateMap<Article, WriterArticleListingServiceModel>()
           .ForMember(a => a.ArticleCategoryName, cfg => cfg.MapFrom(a => a.ArticleCategory.Name));
        }
    }
}