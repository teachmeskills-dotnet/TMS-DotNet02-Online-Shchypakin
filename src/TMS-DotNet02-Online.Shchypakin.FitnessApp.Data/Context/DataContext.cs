
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Configurations;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Context
{
    public class DataContext : IdentityDbContext<Client, AppRole, int,
        IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Memberships
        /// </summary>
        public DbSet<Membership> Memberships { get; set; }
        /// <summary>
        /// Records of the visits
        /// </summary>
        public DbSet<MembershipHistoryRecord> MembershipHistoryRecords { get; set; }
        /// <summary>
        /// Memberships sizes
        /// </summary>
        public DbSet<MembershipSize> MembershipSizes { get; set; }
        /// <summary>
        /// Types of the memberships
        /// </summary>
        public DbSet<MembershipType> MembershipTypes { get; set; }

        public DbSet<Videolinks> Videolinks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ApplyConfiguration(new ClientConfiguration());
            builder.ApplyConfiguration(new AppRoleConfiguration());
            builder.ApplyConfiguration(new MembershipSizeConfiguration());
            builder.ApplyConfiguration(new MembershipTypeConfiguration());
            builder.ApplyConfiguration(new MembershipConfiguration());
            builder.ApplyConfiguration(new RecordConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
