using FakeNews.Services;
using FakeNews.Services.Trainer.Models;
using System;
using System.Collections.Generic;

namespace FakeNews.Web.Areas.Trainer.Models
{
    public class TrainingListingViewModel
    {
        public IEnumerable<TrainingListingServiceModel> Trainings { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalTrainings / ServiceConstants.TrainingsPageSize);

        public int NextPage
            => this.CurrentPage == this.TotalPages
            ? this.TotalPages
            : this.CurrentPage + 1;

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int TotalTrainings { get; set; }
    }
}