namespace EventOrganiser.Services.Data
{
    using System.Collections.Generic;
    using System.Text;

    public interface IEventsService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        T GetById<T>(string id);
    }
}
