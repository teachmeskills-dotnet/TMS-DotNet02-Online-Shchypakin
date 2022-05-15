
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Constants;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Configurations
{
    /// <summary>
    /// EF Configuration for User entity.
    /// </summary>
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.Clients, Schema.Client)
                .HasKey(client => client.Id);

            builder.Property(client => client.Id).IsRequired();

            builder.Property(client => client.Fullname)
                .IsRequired()
                .HasMaxLength(SqlConfiguration.SqlMaxLengthMedium);

            builder.Property(client => client.Birthday)
                .HasColumnType(SqlConfiguration.SqlDateFormat);

            builder.Property(client => client.LastVisit)
                .HasColumnType(SqlConfiguration.SqlDateFormat);

            builder.Property(client => client.Email)
                .HasMaxLength(SqlConfiguration.SqlMaxLengthShort);

            builder.Property(client => client.Comment)
                .HasMaxLength(SqlConfiguration.SqlMaxLengthLong);

            builder.HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
        }
    }
}
