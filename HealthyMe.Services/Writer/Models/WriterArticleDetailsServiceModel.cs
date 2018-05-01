using AutoMapper;
using FakeNews.Common.Mapping;
using FakeNews.Data.Models;
using System;

namespace FakeNews.Services.Writer.Models
{
    public class WriterArticleDetailsServiceModel : IMapFrom<Article>, IHaveCustomMapping
    {
        public string Content { get; set; }

        public string Title { get; set; }

        public DateTime PublishDate { get; set; }

        public string Author { get; set; }

        public void ConfigureMapping(Profile mapper)
       => mapper.CreateMap<Article, WriterArticleDetailsServiceModel>()
            .ForMember(a => a.Author, cfg => cfg.MapFrom(a => a.Author.UserName));
    }
}