using FakeNews.Services.Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FakeNews.Web.Areas.Admin.Models.Users
{
    public class AdminUsersViewModel
    {
        public IEnumerable<SelectListItem> Roles { get; set; }

        public IEnumerable<AdminListingServiceModel> Users { get; set; }
    }
}