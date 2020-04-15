namespace EventOrganiser.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EventOrganiser.Data.Common.Repositories;
    using EventOrganiser.Data.Models;
    using EventOrganiser.Web.ViewModels.Review;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ReviewController : Controller
    {
        //private readonly IDeletableEntityRepository<Review> reviewRepository;
        //private readonly UserManager<ApplicationUser> userManager;
        //
        //public ReviewController(IDeletableEntityRepository<Review>reviewRepository,UserManager<ApplicationUser> userManager)
        //{
        //    this.reviewRepository = reviewRepository;
        //    this.userManager = userManager;
        //}
        //
        //[HttpPost]
        //public async Task<IActionResult> Create(CreateReviewViewModel input)
        //{
        //    var user = await userManager.GetUserAsync(this.User);
        //    var review = new Review
        //    {
        //        UserId = user.Id,
        //        EventId = input.EventId,
        //        Messege = input.Messege,
        //    };
        //    await this.reviewRepository.AddAsync(review);
        //    await this.reviewRepository.SaveChangesAsync();
        //
        //    return this.RedirectToAction("ById", new { id=review.EventId});
        //}
    }
}
