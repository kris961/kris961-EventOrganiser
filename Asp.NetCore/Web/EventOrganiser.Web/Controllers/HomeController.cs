namespace EventOrganiser.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using EventOrganiser.Data;
    using EventOrganiser.Web.ViewModels;
    using EventOrganiser.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext db;

        public HomeController(Data.ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            var events = this.db.Events.Select(x => new IndexEventViewModel
            {
                Name = x.Name,
                Title = x.Title,
                Description = x.Description,
                Img = x.Img,
                Location = x.Location,
                DateTime = x.Date.ToString(),
                IsWhitelisted = x.IsWhitelisted,
            }).ToList();
            viewModel.Events = events;
            return this.View(viewModel);
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
