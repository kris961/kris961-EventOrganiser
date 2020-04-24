using EventOrganiser.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventOrganiser.Data.Configurations
{
    public class UserTaskConfiguration : IEntityTypeConfiguration<UserTask>
    {
        public void Configure(EntityTypeBuilder<UserTask> userTask)
        {
            //userEvent.HasKey(x => new { x.EventId, x.UserId });
            //
            //userEvent.HasOne(e => e.Event)
            //    .WithMany(u => u.EventsUser)
            //    .HasForeignKey(e => e.EventId);
            //
            //userEvent.HasOne(u => u.User)
            //    .WithMany(e => e.UsersEvent)
            //    .HasForeignKey(u => u.UserId);
            userTask.HasKey(x => new { x.EventId, x.UserId });

            userTask.HasOne(x => x.User)
                .WithMany(y => y.Tasks);

            userTask.HasOne(x => x.Event)
                .WithMany(y => y.Tasks);
        }
    }
}
