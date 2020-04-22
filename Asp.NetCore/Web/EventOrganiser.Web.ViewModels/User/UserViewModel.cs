namespace EventOrganiser.Web.ViewModels.User
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EventOrganiser.Data.Models;
    using EventOrganiser.Services.Mapping;
    using EventOrganiser.Web.ViewModels.Event;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Username { get; set; }

        public string Id { get; set; }

        public List<EventViewModel> Events { get; set; }
    }
}
