namespace EventOrganiser.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Invite
    {
        public ApplicationUser Invited { get; set; }

        public int InvitedId { get; set; }

        public ApplicationUser Inviter { get; set; }

        public int InviterId { get; set; }

        public Event Event { get; set; }

        public int EventId { get; set; }

        public int Id { get; set; }
    }
}
