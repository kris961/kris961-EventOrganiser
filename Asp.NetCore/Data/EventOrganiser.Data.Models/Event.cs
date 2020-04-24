namespace EventOrganiser.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using EventOrganiser.Data.Common.Models;

    public class Event : BaseDeletableModel<string>
    {
        public Event()
        {
            this.EventsUser = new HashSet<UsersEvents>();

            this.Id = Guid.NewGuid().ToString();

            this.Invites = new HashSet<Invite>();

            this.Comments = new HashSet<Comment>();
        }

        [Required(ErrorMessage = "The title must be between 3 nad 20 symbols")]
        [MaxLength(20), MinLength(3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "The description must be between 3 nad 100 symbols")]
        [MaxLength(100), MinLength(3)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The location must be between 3 nad 50 symbols")]
        [MaxLength(50), MinLength(3)]
        public string Location { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Img { get; set; }

        public ICollection<UsersEvents> EventsUser { get; set; }

        public Entry Entry { get; set; }

        public ICollection<Invite> Invites { get; set; }

        public ApplicationUser Host { get; set; }

        public string HostId { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<UserTask> Tasks { get; set; }
    }
}
