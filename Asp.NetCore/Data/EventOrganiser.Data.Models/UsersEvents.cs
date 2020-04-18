namespace EventOrganiser.Data.Models
{
    using EventOrganiser.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class UsersEvents
    {
        public Event Event { get; set; }

        public string EventId { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }
    }
}
