using FakeNews.Common.Mapping;
using FakeNews.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace FakeNews.Services.Models
{
    public class DietFormModel : IMapFrom<Diet>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        public string Description { get; set; }

        public byte[] Image { get; set; }
    }
}