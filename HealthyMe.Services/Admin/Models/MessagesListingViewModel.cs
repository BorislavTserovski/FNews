using FakeNews.Services.Admin.Models;
using System.Collections.Generic;

namespace FakeNews.Web.Areas.Admin.Models.Messages
{
    public class MessagesListingViewModel
    {
        public IEnumerable<MessagesListingModel> Messages { get; set; }
    }
}