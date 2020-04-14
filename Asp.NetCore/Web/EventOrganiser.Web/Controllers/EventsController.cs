namespace EventOrganiser.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EventOrganiser.Services.Data;
    using EventOrganiser.Web.ViewModels.Event;
    using Microsoft.AspNetCore.Mvc;

    public class EventsController : Controller
    {
        private readonly IEventsService eventsService;

        public EventsController(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public IActionResult ById(string id)
        {
            var viewModel = this.eventsService.GetById<EventViewModel>(id);

            return this.View(viewModel);
        }
    }
}
