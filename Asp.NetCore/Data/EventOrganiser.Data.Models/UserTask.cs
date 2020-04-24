using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventOrganiser.Data.Models
{
    public class UserTask
    {
        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public Event Event { get; set; }

        public string EventId { get; set; }

        [Required(ErrorMessage = "The job msut be between 3 and 20 symbols")]
        [MaxLength(20), MinLength(3)]
        public string Job { get; set; }
    }
}
