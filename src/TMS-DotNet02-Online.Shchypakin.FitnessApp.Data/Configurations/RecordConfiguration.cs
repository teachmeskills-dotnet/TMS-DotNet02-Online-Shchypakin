using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Constants;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Configurations
{
    /// <summary>
    /// EF Configuration for Record entity.
    /// </summary>
    public class RecordConfiguration : IEntityTypeConfiguration<MembershipHistoryRecord>
    {
        public void Configure(EntityTypeBuilder<MembershipHistoryRecord> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.MembershipHistoryRecords, Schema.Membership)
                .HasKey(record => record.Id);

            builder.Property(record => record.Id).IsRequired();
               

            builder.Property(record => record.Date)
                .HasColumnType(SqlConfiguration.SqlDateFormat);

            builder.HasOne(record => record.Membership)
                .WithMany(membership => membership.MembershipHistoryRecords)
                .HasForeignKey(record => record.MembershipId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
