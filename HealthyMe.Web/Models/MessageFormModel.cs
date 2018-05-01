using AutoMapper;
using FakeNews.Common.Mapping;
using FakeNews.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace FakeNews.Web.Models
{
    public class MessageFormModel : IMapFrom<Message>, IHaveCustomMapping
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Content { get; set; }

        public string User { get; set; }

        public void ConfigureMapping(Profile mapper)
        => mapper.CreateMap<Message, MessageFormModel>()
            .ForMember(m => m.User, cfg => cfg.MapFrom(m => m.User.Name));
    }
}