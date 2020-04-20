namespace EventOrganiser.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EventOrganiser.Data;
    using EventOrganiser.Data.Common.Repositories;
    using EventOrganiser.Data.Models;
    using EventOrganiser.Web.ViewModels.Review;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ReviewController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext dbContext;

        public ReviewController(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        //public async Task<IActionResult> PostComment(string eventId)
        //{
        //    var user = await this.userManager.GetUserAsync(this.User);
        //
        //    var review = new Review { EventId = id, Messege = content, UserId = user.Id };
        //    await this.dbContext.Reviews.AddAsync(review);
        //    await this.dbContext.SaveChangesAsync();
        //
        //    return this.RedirectToAction("ById", new { Id = id });
        //}


        [Authorize]
        [HttpGet("/e/AddCommentEvent")]
        public IActionResult PostComment()
        {
            return this.View();
        }
    }
}
