using FakeNews.Common.Mapping;
using FakeNews.Data.Models;

namespace FakeNews.Web.Areas.Admin.Models.Products
{
    public class ProductViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }
    }
}