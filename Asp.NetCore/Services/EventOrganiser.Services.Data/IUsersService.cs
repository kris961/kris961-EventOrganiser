using System;
using System.Collections.Generic;
using System.Text;

namespace EventOrganiser.Services.Data
{
    public interface IUsersService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        T GetById<T>(string id);
    }
}
