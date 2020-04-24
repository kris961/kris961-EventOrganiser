namespace EventOrganiser.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using EventOrganiser.Data.Common.Models;

    public class UsersEvents
    {
        [Required]
        public Event Event { get; set; }

        public string EventId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
