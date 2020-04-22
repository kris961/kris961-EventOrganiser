namespace EventOrganiser.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EventOrganiser.Data;
    using EventOrganiser.Data.Common.Repositories;
    using EventOrganiser.Data.Models;
    using EventOrganiser.Web.ViewModels.Event;
    using EventOrganiser.Web.ViewModels.Review;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CommentsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext dbContext;
        private readonly IDeletableEntityRepository<Comment> commentRepository;

        public CommentsController(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext, IDeletableEntityRepository<Comment>commentRepository)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
            this.commentRepository = commentRepository;
        }

        [Authorize]
        public async Task<IActionResult> Post(CommentViewModel commentViewModel)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var comment = new Comment { EventId = commentViewModel.EventId, Messege = commentViewModel.Messege, UserId = user.GetUserId(),Replies = new HashSet<Reply>(), Username = user.UserName, PostedOn = DateTime.Now };
            await this.commentRepository.AddAsync(comment);
            await this.commentRepository.SaveChangesAsync();
            return this.RedirectToAction("ById", "Events", new { Id = comment.EventId });
        }

        [HttpGet("/e/Comment")]
        public IActionResult Comment(string eventId)
        {
            var @event = this.dbContext.Events.FirstOrDefault(x => x.Id == eventId);
            CommentViewModel comment = new CommentViewModel { EventId = eventId, EventName = @event.Title };
            return this.View(comment);
        }
    }
}
