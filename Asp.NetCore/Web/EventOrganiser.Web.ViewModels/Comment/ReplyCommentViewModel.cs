using EventOrganiser.Data.Models;
using EventOrganiser.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventOrganiser.Web.ViewModels.Review
{
    public class ReplyCommentViewModel : IMapFrom<Comment>
    {
        public DateTime PostedOn { get; set; }

        public string Username { get; set; }

        public string EventName { get; set; }

        public string UserId { get; set; }

        public string EventId { get; set; }

        public string Messege { get; set; }
    }
}
