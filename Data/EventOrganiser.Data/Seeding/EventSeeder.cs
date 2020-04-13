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
                    Img = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ibizadiscoticket.com%2Fblog%2Fes%2Ftop-5-ibiza-pool-parties%2F&psig=AOvVaw0FF1LgkEhS3DbSJp4ffK4C&ust=1586854902774000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCKCD_6eF5egCFQAAAAAdAAAAABAc",
                });
            }
        }
    }
}
