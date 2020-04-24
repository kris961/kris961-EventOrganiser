namespace EventOrganiser.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    using EventOrganiser.Data;
    using EventOrganiser.Data.Common.Repositories;
    using EventOrganiser.Data.Models;
    using EventOrganiser.Services.Data;
    using EventOrganiser.Services.Mapping;
    using EventOrganiser.Web.ViewModels;
    using EventOrganiser.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IEventsService eventsService;

        public HomeController(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public IActionResult Index()
        {
            try
            {
            var viewModel = new AllViewModel
            {
                Events =
                this.eventsService.GetAll<SingleEventViewModel>(5),
            };
            return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.View("Error");
            }
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
