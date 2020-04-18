namespace EventOrganiser.Web.ViewModels.Event
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EventOrganiser.Data.Models;
    using EventOrganiser.Services.Mapping;
    using Microsoft.AspNetCore.Identity;

    public class UsersEventsViewModel
    {
        public string EventId { get; set; }

        public string UserId { get; set; }
    }
}
