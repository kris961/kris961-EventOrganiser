namespace EventOrganiser.Web.ViewModels.Home
{
    using EventOrganiser.Data.Models;
    using EventOrganiser.Services.Mapping;
    using EventOrganiser.Web.ViewModels.Review;
    using System.Collections;
    using System.Collections.Generic;

    public class SingleEventViewModel : IMapFrom<Event>
    {
        public SingleEventViewModel()
        {
            this.Comments = new HashSet<CommentViewModel>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Img { get; set; }

        public string Location { get; set; }

        public string DateTime { get; set; }

        public string Entry { get; set; }

        public string Url => $"/e/{this.Id}";

        public ICollection<CommentViewModel> Comments { get; set; }
    }
}
