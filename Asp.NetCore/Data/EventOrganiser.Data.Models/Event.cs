namespace EventOrganiser.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EventOrganiser.Data.Common.Models;

    public class Event : BaseDeletableModel<int>
    {
        public Event()
        {
            this.Users = new HashSet<ApplicationUser>();

            this.Reviews = new HashSet<Review>();
        }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime Date { get; set; }

        public string Img { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }

        public bool IsWhitelisted { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
