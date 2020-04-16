namespace EventOrganiser.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EventOrganiser.Data.Common.Models;

    public class Event : BaseDeletableModel<string>
    {
        public Event()
        {
            this.EventsUser = new HashSet<UsersEvents>();

            this.Reviews = new HashSet<Review>();

            this.Id = Guid.NewGuid().ToString();

            this.Invites = new HashSet<Invite>();
        }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime Date { get; set; }

        public string Img { get; set; }

        public ICollection<UsersEvents> EventsUser { get; set; }

        public Entry Entry { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<Invite> Invites { get; set; }

        public ApplicationUser Host { get; set; }

        public string HostId { get; set; }
    }
}
