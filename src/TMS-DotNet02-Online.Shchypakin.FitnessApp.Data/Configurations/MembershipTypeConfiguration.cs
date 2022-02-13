using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Constants;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Configurations
{
    public class MembershipTypeConfiguration : IEntityTypeConfiguration<MembershipType>
    {
        public void Configure(EntityTypeBuilder<MembershipType> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.MembershipTypes, Schema.Membership)
                .HasKey(type => type.Id);

            builder.Property(type => type.Id).IsRequired();

            builder.Property(type => type.Type)
                .IsRequired()
                .HasMaxLength(SqlConfiguration.SqlMaxLengthShort);
        }
    }
}
