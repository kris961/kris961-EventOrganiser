namespace EventOrganiser.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EventOrganiser.Data.Models;

    public class EventSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Events.Any())
            {
                return;
            }

            var events = new List<string> { "PoolParty", "BeachParty", "FootballGame", "barHunting" };

            foreach (var seedEvent in events)
            {
                await dbContext.Events.AddAsync(new Event
                {
                    Name = "Category",
                    Location = "Nowhere",
                    Title = "test",
                    Description = "firstSteps",
                    Date = DateTime.Now,
                    IsWhitelisted = false,
                    Img = "https://blogmedia.evbstatic.com/wp-content/uploads/wpmulti/sites/8/shutterstock_199419065.jpg",
                });
            }
        }
    }
}
