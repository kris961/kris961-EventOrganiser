using EventOrganiser.Data.Models;
using EventOrganiser.Services.Mapping;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventOrganiser.Web.ViewModels.Review
{
    public class CommentViewModel : IMapFrom<Comment>
    {
        public string Img { get; set; }

        public int Id { get; set; }

        public DateTime PostedOn { get; set; }

        public string Username { get; set; }

        public string EventName { get; set; }

        public string UserId { get; set; }

        public string EventId { get; set; }

        [Required(ErrorMessage = "The comment must be between 3 nad 1300 symbols")]
        [MaxLength(300), MinLength(3)]
        public string Messege { get; set; }

        public ICollection<ReplyViewModel> Replies { get; set; }
    }
}