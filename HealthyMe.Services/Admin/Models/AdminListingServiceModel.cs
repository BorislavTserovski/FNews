using FakeNews.Common.Mapping;
using FakeNews.Data.Models;

namespace FakeNews.Services.Admin.Models
{
    public class AdminListingServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }
}