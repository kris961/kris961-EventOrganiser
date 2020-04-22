namespace EventOrganiser.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    using EventOrganiser.Data.Common.Models;

    public class Reply : BaseDeletableModel<int>
    {
        public Comment Comment { get; set; }

        public int CommentId { get; set; }

        public string Content { get; set; }

        public string Username { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public DateTime PostedOn { get; set; }
    }
}
