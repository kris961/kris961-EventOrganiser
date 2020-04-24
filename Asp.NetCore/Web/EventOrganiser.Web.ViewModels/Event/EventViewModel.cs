namespace EventOrganiser.Web.ViewModels.Event
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EventOrganiser.Data.Models;
    using EventOrganiser.Services.Mapping;
    using EventOrganiser.Web.ViewModels.Review;
    using EventOrganiser.Web.ViewModels.User;
    using Microsoft.AspNetCore.Identity;

    public class EventViewModel : IMapFrom<Event>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime Date { get; set; }

        public string Img { get; set; }

        public Entry Entry { get; set; }

        public IEnumerable<UsersEvents> EventsUser { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public string HostId { get; set; }

        public string Comment { get; set; }

        public ICollection<UserTask> Tasks { get; set; }
    }
}
