using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EventOrganiser.Data;
using EventOrganiser.Data.Common.Repositories;
using EventOrganiser.Data.Models;
using EventOrganiser.Web.ViewModels.Event;
using EventOrganiser.Web.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventOrganiser.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly Cloudinary cloudinary;

        public UserController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, Cloudinary cloudinary)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.cloudinary = cloudinary;
        }

        [HttpGet("/e/Users/Details")]
        public IActionResult Details(string userId)
        {
            var user = this.dbContext.Users.FirstOrDefault(x => x.Id == userId);
            var userViewModel = new UserViewModel { Id = userId, Username = user.UserName, Events = new List<EventViewModel>() };
            var events = this.dbContext.UsersEvents.Where(x => x.UserId == userId).Select(x => x.Event);
            foreach (var @event in events)
            {
                userViewModel.Events.Add(new EventViewModel { Date = @event.Date, Description = @event.Description, Entry = @event.Entry, HostId = @event.HostId, Img = @event.Img, Location = @event.Location, Title = @event.Title, Id = @event.Id });
            }
            return this.View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserViewModel input)
        {
            using var stream = input.Img.OpenReadStream();

            var user = await this.userManager.GetUserAsync(this.User);

            ImageUploadParams uploadParams = new ImageUploadParams
            {
                Folder = "Users",
                Transformation = new Transformation().Crop("limit").Width(800).Height(600),
                File = new FileDescription($"{Guid.NewGuid()}_{@input.Username}", stream),
            };

            UploadResult uploadResult = await this.cloudinary.UploadAsync(uploadParams);
            var imgUrl = uploadResult.SecureUri.AbsoluteUri;
            user.Img = imgUrl;
            await this.dbContext.SaveChangesAsync();
            return this.RedirectToAction("Details", new { userId = user.GetUserId() });
        }
    }
}
