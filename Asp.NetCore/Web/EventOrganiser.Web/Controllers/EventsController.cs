namespace EventOrganiser.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using EventOrganiser.Data;
    using EventOrganiser.Data.Common.Repositories;
    using EventOrganiser.Data.Models;
    using EventOrganiser.Data.Repositories;
    using EventOrganiser.Services.Data;
    using EventOrganiser.Web.ViewModels.Event;
    using EventOrganiser.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class EventsController : Controller
    {
        private readonly IEventsService eventsService;
        private readonly IDeletableEntityRepository<Event> eventRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext dbContext;
        private readonly Cloudinary cloudinary;

        public EventsController(
            IEventsService eventsService,
            IDeletableEntityRepository<Event> eventRepository,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext dbContext,
            Cloudinary cloudinary)
        {
            this.eventsService = eventsService;
            this.eventRepository = eventRepository;
            this.userManager = userManager;
            this.dbContext = dbContext;
            this.cloudinary = cloudinary;
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

            using var stream = input.Img.OpenReadStream();

            var user = await this.userManager.GetUserAsync(this.User);

            var @event = new Event
            {
                Title = input.Title,
                Description = input.Description,
                Date = input.Date,
                Entry = input.Entry,
                HostId = user.Id,
                Location = input.Location,
            };

            ImageUploadParams uploadParams = new ImageUploadParams
            {
                Folder = "Events",
                Transformation = new Transformation().Crop("limit").Width(800).Height(600),
                File = new FileDescription($"{Guid.NewGuid()}_{@event.Title}", stream),
            };

            UploadResult uploadResult = await this.cloudinary.UploadAsync(uploadParams);
            var imgUrl = uploadResult.SecureUri.AbsoluteUri;

            @event.Img = imgUrl;
            UsersEvents usersEvents = new UsersEvents { Event = @event, EventId = @event.Id, User = user, UserId = user.Id };
            @event.EventsUser.Add(usersEvents);
            await this.eventRepository.AddAsync(@event);
            await this.eventRepository.SaveChangesAsync();
            return this.RedirectToAction("ById", new { Id = @event.Id });
        }

        [Authorize]
        [HttpGet("/e/AddUserToEvent")]
        public async Task<IActionResult> Join(string eventId)
        {
            var @event = this.dbContext.Events.FirstOrDefault(x => x.Id == eventId);
            var user = await this.userManager.GetUserAsync(this.User);
            UsersEvents usersEvents = new UsersEvents { EventId = eventId, Event = @event, User = user, UserId = user.Id };
            user.UsersEvent.Add(usersEvents);
            @event.EventsUser.Add(usersEvents);
            await this.dbContext.UsersEvents.AddAsync(usersEvents);
            await this.dbContext.SaveChangesAsync();

            return this.RedirectToAction("ById", new { Id = eventId });
        }

        [Authorize]
        [HttpGet("/e/RemoveUserFromEvent")]
        public async Task<IActionResult> Leave(string eventId)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var usersEvent = this.dbContext.UsersEvents.Where(x => x.UserId == user.Id).Where(x => x.EventId == eventId).FirstOrDefault();
            this.dbContext.UsersEvents.Remove(usersEvent);
            await this.dbContext.SaveChangesAsync();

            return this.RedirectToAction("ById", new { Id = eventId });
        }

        [HttpGet("/e/EditEvent")]
        public IActionResult Edit(string eventId)
        {
            var @event = this.dbContext.Events.FirstOrDefault(x => x.Id == eventId);
            return this.View(@event);
        }

        [HttpPost]
        public IActionResult EditEvent(Event @event)
        {
            var oldevent = this.dbContext.Events.FirstOrDefault(x => x.Id == @event.Id);
            this.dbContext.Events.Remove(oldevent);
            this.dbContext.Events.Add(@event);
            this.dbContext.SaveChanges();
            return this.RedirectToAction("All");
        }

        [HttpGet("/e/DeleteEvent")]
        public async Task<IActionResult> Delete(string eventId)
        {
            var @event = this.dbContext.Events.FirstOrDefault(x => x.Id == eventId);
            @event.IsDeleted = true;
            this.eventRepository.Update(@event);
            await this.dbContext.SaveChangesAsync();
            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var viewModel = new AllViewModel
            {
                Events =
                this.eventsService.GetAll<SingleEventViewModel>(),
            };
            return this.View(viewModel);
        }
    }
}
