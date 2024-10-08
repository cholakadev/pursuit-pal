﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PursuitPal.Core.Enums;
using PursuitPal.Core.Helpers;
using PursuitPal.Infrastructure.Entities;

namespace PursuitPal.Infrastructure.Configurations
{
    public class GoalEntityConfiguration : IEntityTypeConfiguration<Goal>
    {
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FromDate).IsRequired();
            builder.Property(x => x.ToDate).IsRequired();
            builder.Property(x => x.Status)
                .HasMaxLength(20)
                .HasConversion(new EnumToStringConverter<GoalStatus>())
                .HasDefaultValue(GoalStatus.Active);
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.HasOne(x => x.User);
            builder.HasOne(x => x.Details);
            builder.HasMany(x => x.Feedbacks)
                .WithOne(x => x.Goal)
                .HasForeignKey(x => x.GoalId);
        }
    }
}
