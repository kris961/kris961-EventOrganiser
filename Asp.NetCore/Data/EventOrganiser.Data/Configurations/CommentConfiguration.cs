using EventOrganiser.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventOrganiser.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> comment)
        {
            comment
                .HasMany(r => r.Replies)
                .WithOne(c => c.Comment)
                .HasForeignKey(c => c.CommentId);

            comment.HasKey(i => i.Id);
        }
    }
}
