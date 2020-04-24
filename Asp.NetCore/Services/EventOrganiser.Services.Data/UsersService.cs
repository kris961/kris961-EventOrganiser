using EventOrganiser.Data.Common.Repositories;
using EventOrganiser.Data.Models;
using EventOrganiser.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventOrganiser.Services.Data
{
    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public UsersService(IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<ApplicationUser> query = this.userRepository
                 .All().Take(10);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetById<T>(string id)
        {
            var appevent = this.userRepository.All().Where(x => x.Id == id).Where(x => x.IsDeleted == false)
                .To<T>().FirstOrDefault();
            return appevent;
        }
    }
}
