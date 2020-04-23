namespace EventOrganiser.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using EventOrganiser.Data.Common.Repositories;
    using EventOrganiser.Data.Models;
    using EventOrganiser.Services.Mapping;
    using EventOrganiser.Web.ViewModels.Event;

    public class EventsService : IEventsService
    {
        private readonly IDeletableEntityRepository<Event> eventRepository;

        public EventsService(IDeletableEntityRepository<Event> eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
           IQueryable<Event> query = this.eventRepository
                .All().OrderBy(x => x.Date).Take(10);

           if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

           return query.To<T>().ToList();
        }

        public T GetById<T>(string id)
        {
            var appevent = this.eventRepository.All().Where(x => x.Id == id).Where(x => x.IsDeleted == false)
                .To<T>().FirstOrDefault();
            return appevent;
        }

        public Event Join(EventCreateViewModel input)
        {
            var @event = new Event
            {
                Title = input.Title,
                Description = input.Description,
                Date = input.Date,
                Entry = input.Entry,
                Location = input.Location,
            };
            return @event;
        }
    }
}
