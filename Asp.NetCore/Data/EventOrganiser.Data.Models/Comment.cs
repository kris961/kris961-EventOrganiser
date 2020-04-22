namespace EventOrganiser.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EventOrganiser.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public Comment()
        {
            this.Replies = new HashSet<Reply>();
        }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string EventId { get; set; }

        public Event Event { get; set; }

        public string Messege { get; set; }

        public ICollection<Reply> Replies { get; set; }

        public string Username { get; set; }

        public DateTime PostedOn { get; set; }
    }
}
