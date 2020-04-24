namespace EventOrganiser.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;
    using System.Text;

    using EventOrganiser.Data.Common.Models;

    public class Reply : BaseDeletableModel<int>
    {
        public Comment Comment { get; set; }

        [Required]
        public int CommentId { get; set; }

        [Required]
        [MaxLength(300), MinLength(3)]
        public string Content { get; set; }

        public string Username { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        public DateTime PostedOn { get; set; }
    }
}
