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

            // await dbContext.Events.AddAsync(new Event
            // {
            //     Name = "Category",
            //     Location = "Nowhere",
            //     Title = "test",
            //     Description = "firstSteps",
            //     Date = DateTime.Now,
            //     Entry = Entry.Free,
            //     Img = "https://blogmedia.evbstatic.com/wp-content/uploads/wpmulti/sites/8/shutterstock_199419065.jpg",
            // });
            //
            // await dbContext.Events.AddAsync(new Event
            // {
            //     Name = "Category",
            //     Location = "Nowhere",
            //     Title = "test",
            //     Description = "firstSteps",
            //     Date = DateTime.Now,
            //     Entry = Entry.Fundraiser,
            //     Img = "https://blogmedia.evbstatic.com/wp-content/uploads/wpmulti/sites/8/shutterstock_199419065.jpg",
            // });
            //
            // await dbContext.Events.AddAsync(new Event
            // {
            //     Name = "Category",
            //     Location = "Nowhere",
            //     Title = "test",
            //     Description = "firstSteps",
            //     Date = DateTime.Now,
            //     Entry = Entry.InviteOnly,
            //     Img = "https://blogmedia.evbstatic.com/wp-content/uploads/wpmulti/sites/8/shutterstock_199419065.jpg",
            // });
            // await dbContext.Events.AddAsync(new Event
            // {
            //     Name = "Category",
            //     Location = "Nowhere",
            //     Title = "test",
            //     Description = "firstSteps",
            //     Date = DateTime.Now,
            //     Entry = Entry.Payed,
            //     Img = "https://blogmedia.evbstatic.com/wp-content/uploads/wpmulti/sites/8/shutterstock_199419065.jpg",
            // });
        }
    }
}
