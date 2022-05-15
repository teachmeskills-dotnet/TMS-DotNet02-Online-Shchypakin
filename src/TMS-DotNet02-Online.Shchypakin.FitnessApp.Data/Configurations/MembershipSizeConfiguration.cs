
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Constants;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Configurations
{
    /// <summary>
    /// EF Configuration for Goal entity.
    /// </summary>
    public class MembershipSizeConfiguration : IEntityTypeConfiguration<MembershipSize>
    {
        public void Configure(EntityTypeBuilder<MembershipSize> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.MembershipSizes, Schema.Membership)
                .HasKey(size => size.Id);

            builder.Property(size => size.Id).IsRequired();
                
            builder.Property(size => size.Count).IsRequired();

            builder.Property(size => size.Comment)
                .HasMaxLength(SqlConfiguration.SqlMaxLengthLong);

        }
    }
}
