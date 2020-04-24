using EventOrganiser.Data;
using EventOrganiser.Data.Models;
using EventOrganiser.Services.Data;
using EventOrganiser.Web.ViewModels.Event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventOrganiser.Web.Controllers
{
    public class TasksController : Controller
    {
        private readonly IEventsService eventsService;
        private readonly IUsersService usersService;
        private readonly ApplicationDbContext dbContext;

        public TasksController(IEventsService eventsService, IUsersService usersService, ApplicationDbContext dbContext)
        {
            this.eventsService = eventsService;
            this.usersService = usersService;
            this.dbContext = dbContext;
        }

        [Authorize][Authorize]
        public IActionResult Participants(string eventId)
        {
            var @event = this.dbContext.Events.FirstOrDefault(x => x.Id == eventId);
            var usersEvent = this.dbContext.UsersEvents.Where(x => x.EventId == eventId);
            EventViewModel eventViewModel = new EventViewModel { EventsUser = usersEvent, HostId = @event.HostId };
            foreach (var eventsUser in eventViewModel.EventsUser)
            {
                eventsUser.User = this.dbContext.Users.FirstOrDefault(x => x.Id == eventsUser.UserId);
                eventsUser.Event = this.dbContext.Events.FirstOrDefault(x => x.Id == eventsUser.EventId);
            }

            eventViewModel.Tasks = this.dbContext.Tasks.Where(x => x.EventId == @event.Id).ToArray();
            return this.View(eventViewModel);
        }

        [Authorize]
        [HttpGet("/e/AddTask")]
        public IActionResult Create(string taskParams)
        {
            string[] ids = taskParams.Split('|', StringSplitOptions.RemoveEmptyEntries);
            UserTask task = new UserTask { EventId = ids[1].Replace(" ", string.Empty), UserId = ids[0].Replace(" ", string.Empty)};
            return this.View(task);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateTask(UserTask task)
        {
            try
            {
            if(!this.ModelState.IsValid)
            {
                return this.View("Create", task);
            }

            this.dbContext.Tasks.Add(task);
            var @event = this.dbContext.Events.FirstOrDefault(x => x.Id == task.EventId);
            await this.dbContext.SaveChangesAsync();
            return this.RedirectToAction("ById", "Events", new { Id = task.EventId });
            }
            catch (Exception)
            {
                return this.View("Error");
            }
        }
    }
}
