using AutoMapper;
using FakeNews.Common.Mapping;
using FakeNews.Data.Models;
using System.Collections.Generic;

namespace FakeNews.Services.Models
{
    public class UserWithProductsServiceModel : IMapFrom<User>, IHaveCustomMapping
    {
        public string Name { get; set; }

        public List<UserProductServiceModel> Products { get; set; } = new List<UserProductServiceModel>();

        public int AllowedCalories { get; set; }

        public void ConfigureMapping(Profile mapper)
        => mapper.CreateMap<User, UserWithProductsServiceModel>()
            .ForMember(u => u.Products, cfg => cfg.MapFrom(p => p.MyProducts));
    }
}