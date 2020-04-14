namespace EventOrganiser.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EventOrganiser.Data.Common.Models;

    public class Review : BaseDeletableModel<int>
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string EventId { get; set; }

        public Event Event { get; set; }

        public string Messege { get; set; }
    }
}
