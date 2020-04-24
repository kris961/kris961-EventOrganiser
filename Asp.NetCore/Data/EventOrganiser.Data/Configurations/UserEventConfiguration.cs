using EventOrganiser.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventOrganiser.Data.Configurations
{
    public class UserEventConfiguration : IEntityTypeConfiguration<UsersEvents>
    {
        public void Configure(EntityTypeBuilder<UsersEvents> userEvent)
        {
            userEvent.HasKey(x => new { x.EventId, x.UserId });

            userEvent.HasOne(e => e.Event)
                .WithMany(u => u.EventsUser)
                .HasForeignKey(e => e.EventId);

            userEvent.HasOne(u => u.User)
                .WithMany(e => e.UsersEvent)
                .HasForeignKey(u => u.UserId);
        }
    }
}
