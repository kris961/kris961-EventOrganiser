namespace EventOrganiser.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EventOrganiser.Data.Common.Repositories;
    using EventOrganiser.Data.Models;
    using EventOrganiser.Data.Repositories;
    using EventOrganiser.Services.Data;
    using EventOrganiser.Web.ViewModels.Event;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class EventsController : Controller
    {
        private readonly IEventsService eventsService;
        private readonly IDeletableEntityRepository<Event> eventRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public EventsController(IEventsService eventsService, IDeletableEntityRepository<Event> eventRepository, UserManager<ApplicationUser> userManager)
        {
            this.eventsService = eventsService;
            this.eventRepository = eventRepository;
            this.userManager = userManager;
        }

        public IActionResult ById(string id)
        {
            var viewModel = this.eventsService.GetById<EventViewModel>(id);

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(EventCreateViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var @event = new Event
            {
                Title = input.Title,
                Name = input.Title,
                Description = input.Description,
                Img = input.Img,
                Date = input.Date,
                Entry = input.Entry,
                HostId = user.Id,
            };
            UsersEvents usersEvents = new UsersEvents { Event = @event, EventId = @event.Id, User = user, UserId = user.Id };
            @event.EventsUser.Add(usersEvents);
            await this.eventRepository.AddAsync(@event);
            await this.eventRepository.SaveChangesAsync();
            return this.RedirectToAction("ById", new { Id = @event.Id });
        }
    }
}
