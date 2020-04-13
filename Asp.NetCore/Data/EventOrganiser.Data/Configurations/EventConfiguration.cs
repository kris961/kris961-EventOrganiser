namespace EventOrganiser.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EventOrganiser.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> appEvent)
        {
            appEvent
                .HasMany(r => r.Reviews)
                .WithOne(e => e.Event)
                .HasForeignKey(e => e.EventId);

            appEvent.HasKey(i => i.Id);
        }
    }
}
