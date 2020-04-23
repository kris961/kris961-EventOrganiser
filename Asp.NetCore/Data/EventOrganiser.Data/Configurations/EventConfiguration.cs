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
                .HasMany(r => r.Comments)
                .WithOne(e => e.Event)
                .HasForeignKey(e => e.EventId);

            appEvent.HasKey(i => i.Id);
        }
        public void Configure(EntityTypeBuilder<Task> task)
        {
            task.HasOne(x => x.Event)
                .WithMany(e => e.Tasks)
                .HasForeignKey(x => x.EventId);

            task.HasKey(x => x.Id);
        }

            public void Configure(EntityTypeBuilder<Comment> comment)
        {
            comment
                .HasMany(r => r.Replies)
                .WithOne(c => c.Comment)
                .HasForeignKey(c => c.CommentId);

            comment.HasKey(i => i.Id);
        }

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

        public void Configure(EntityTypeBuilder<Invite> invite)
        {
            invite.HasKey(i => i.Id);
        }
    }
}
