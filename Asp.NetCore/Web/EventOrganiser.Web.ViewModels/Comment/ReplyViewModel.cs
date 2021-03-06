﻿using EventOrganiser.Data.Models;
using EventOrganiser.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventOrganiser.Web.ViewModels.Review
{
    public class ReplyViewModel : IMapFrom<Reply>
    {
        public string Img { get; set; }

        public int Id { get; set; }

        public string Username { get; set; }

        public int ReplyId { get; set; }

        public int CommentId { get; set; }

        [Required(ErrorMessage = "The reply must be between 3 nad 100 symbols")]
        [MaxLength(100), MinLength(3)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public ReplyCommentViewModel ReplyComment { get; set; }

        public DateTime PostedOn { get; set; }
    }
}