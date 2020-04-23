namespace EventOrganiser.Services.Data
{
    using EventOrganiser.Data.Models;
    using EventOrganiser.Web.ViewModels.Event;
    using System.Collections.Generic;
    using System.Text;

    public interface IEventsService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        T GetById<T>(string id);

        Event Join(EventCreateViewModel input);
    }
}
