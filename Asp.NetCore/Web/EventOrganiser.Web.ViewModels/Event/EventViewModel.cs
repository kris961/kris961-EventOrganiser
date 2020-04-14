namespace EventOrganiser.Web.ViewModels.Event
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EventOrganiser.Data.Models;
    using EventOrganiser.Services.Mapping;
    using EventOrganiser.Web.ViewModels.Review;
    using EventOrganiser.Web.ViewModels.User;

    public class EventViewModel : IMapFrom<Event>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime Date { get; set; }

        public string Img { get; set; }

        public Entry Entry { get; set; }

        public IEnumerable<UserViewModel> Users { get; set; }

        public IEnumerable<ReviewViewModel> Reviews { get; set; }
    }
}
