using EventOrganiser.Data;
using EventOrganiser.Data.Common.Repositories;
using EventOrganiser.Data.Models;
using EventOrganiser.Web.ViewModels.Review;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventOrganiser.Web.Controllers
{
    public class RepliesController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IDeletableEntityRepository<Reply> replyRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public RepliesController(ApplicationDbContext dbContext, IDeletableEntityRepository<Reply> replyRepository, UserManager<ApplicationUser>userManager)
        {
            this.dbContext = dbContext;
            this.replyRepository = replyRepository;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpGet("/e/Comment/Reply")]
        public IActionResult Reply(int commentId)
        {
            try
            {
            var comment = this.dbContext.Comments.FirstOrDefault(x => x.Id == commentId);
            if (comment == null)
                {
                    return this.RedirectToAction("All");
                }

            var user = this.dbContext.Users.FirstOrDefault(x => x.Id == comment.UserId);
            var @event = this.dbContext.Events.FirstOrDefault(x => x.Id == comment.EventId);
            var replyComment = new ReplyCommentViewModel { EventId = comment.EventId, EventName = @event.Title, Messege = comment.Messege, PostedOn = comment.PostedOn, UserId = comment.UserId, Username = comment.Username };
            var reply = new ReplyViewModel { Img = user.Img ,ReplyComment = replyComment, UserId = comment.UserId, CommentId = comment.Id , Username = comment.Username};
            return this.View(reply);
            }
            catch (Exception)
            {
                return this.View("Error");
            }
        }

        [Authorize]
        public async Task<IActionResult> PostReply(ReplyViewModel replyView)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View("Reply", replyView);
                }
                if (replyView == null)
             {
                    return this.RedirectToAction("All");
             }

            var user = await this.userManager.GetUserAsync(this.User);
            var reply = new Reply { PostedOn=DateTime.Now, Username = user.UserName, CommentId = replyView.CommentId, Content = replyView.Content, UserId = replyView.UserId };
            var comment = this.dbContext.Comments.FirstOrDefault(x => x.Id == reply.CommentId);
            await this.replyRepository.AddAsync(reply);
            await this.replyRepository.SaveChangesAsync();
            return this.RedirectToAction("ById", "Events", new { Id = comment.EventId });
            }
            catch (Exception)
            {
                return this.View("Error");
            }
        }
    }
}
