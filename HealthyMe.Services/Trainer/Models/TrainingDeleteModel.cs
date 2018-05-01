using FakeNews.Common.Mapping;
using FakeNews.Data.Models;

namespace FakeNews.Services.Trainer.Models
{
    public class TrainingDeleteModel : IMapFrom<Training>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}