using FakeNews.Common.Mapping;
using FakeNews.Data.Models;

namespace FakeNews.Services.Trainer.Models
{
    public class TrainingListingServiceModel : IMapFrom<Training>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string VideoUrl { get; set; }

        public bool IsForLoosingWeight { get; set; }

        public bool IsForGainingWeight { get; set; }

        public MuscleGroup MuscleGroup { get; set; }
    }
}