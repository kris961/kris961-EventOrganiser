﻿// ReSharper disable VirtualMemberCallInConstructor
namespace EventOrganiser.Data.Models
{
    using System;
    using System.Collections.Generic;

    using EventOrganiser.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.UsersEvent = new HashSet<UsersEvents>();
            this.Tasks = new HashSet<UserTask>();
        }

        public string Img { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public ICollection<UsersEvents> UsersEvent { get; set; }

        public ICollection<Event> OrganisedEvents { get; set; }

        public ICollection<UserTask> Tasks { get; set; }

        public string GetUserId()
        {
            return this.Id;
        }
    }
}
