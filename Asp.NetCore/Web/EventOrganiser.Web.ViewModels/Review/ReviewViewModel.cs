﻿namespace EventOrganiser.Web.ViewModels.Review
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EventOrganiser.Data.Models;
    using EventOrganiser.Services.Mapping;
    using EventOrganiser.Web.ViewModels.User;

    public class ReviewViewModel : IMapFrom<Review>
    {
        public DateTime CreatedOn { get; set; }

        public UserViewModel User { get; set; }

        public string EventId { get; set; }

        public string Messege { get; set; }
    }
}