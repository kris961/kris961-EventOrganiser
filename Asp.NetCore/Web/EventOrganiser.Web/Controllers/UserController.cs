using EventOrganiser.Data;
using EventOrganiser.Data.Common.Repositories;
using EventOrganiser.Data.Models;
using EventOrganiser.Web.ViewModels.Event;
using EventOrganiser.Web.ViewModels.User;
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

        public UserController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("/e/Users/Details")]
        public IActionResult Details(string userId)
        {
            var user = this.dbContext.Users.FirstOrDefault(x => x.Id == userId);
            var userViewModel = new UserViewModel { Username = user.UserName, Events = new List<EventViewModel>() };
            var events = this.dbContext.UsersEvents.Where(x => x.UserId == userId).Select(x => x.Event);
            foreach (var @event in events)
            {
                userViewModel.Events.Add(new EventViewModel { Date = @event.Date, Description = @event.Description, Entry = @event.Entry, HostId = @event.HostId, Img = @event.Img, Location = @event.Location, Title = @event.Title, Id = @event.Id });
            }

            return this.View(userViewModel);
        }
    }
}
