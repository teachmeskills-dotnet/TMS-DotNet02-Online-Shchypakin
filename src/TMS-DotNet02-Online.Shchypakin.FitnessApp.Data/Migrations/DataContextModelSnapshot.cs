﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Context;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.AppUserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RoleId1")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserId1")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("RoleId1");

                    b.HasIndex("UserId1");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("Comment")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(127)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastVisit")
                        .HasColumnType("date");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.Membership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("End")
                        .HasColumnType("date");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MembershipSizeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MembershipTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Online")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Start")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("MembershipSizeId");

                    b.HasIndex("MembershipTypeId");

                    b.ToTable("Memberships", "membership");
                });

            modelBuilder.Entity("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.MembershipHistoryRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("MembershipId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MembershipId");

                    b.ToTable("MembershipHistoryRecords", "membership");
                });

            modelBuilder.Entity("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.MembershipSize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("MembershipSizes", "membership");
                });

            modelBuilder.Entity("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.MembershipType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(63)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MembershipTypes", "membership");
                });

            modelBuilder.Entity("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.Videolinks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Videolinks");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.Client", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.Client", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.Client", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.AppUserRole", b =>
                {
                    b.HasOne("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.AppRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId1");

                    b.HasOne("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.Client", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.Client", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId1");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.Membership", b =>
                {
                    b.HasOne("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.Client", "Client")
                        .WithMany("Memberships")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.MembershipSize", "MembershipSize")
                        .WithMany("Memberships")
                        .HasForeignKey("MembershipSizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.MembershipType", "MembershipType")
                        .WithMany("Memberships")
                        .HasForeignKey("MembershipTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("MembershipSize");

                    b.Navigation("MembershipType");
                });

            modelBuilder.Entity("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.MembershipHistoryRecord", b =>
                {
                    b.HasOne("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.Membership", "Membership")
                        .WithMany("MembershipHistoryRecords")
                        .HasForeignKey("MembershipId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Membership");
                });

            modelBuilder.Entity("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.AppRole", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.Client", b =>
                {
                    b.Navigation("Memberships");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.Membership", b =>
                {
                    b.Navigation("MembershipHistoryRecords");
                });

            modelBuilder.Entity("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.MembershipSize", b =>
                {
                    b.Navigation("Memberships");
                });

            modelBuilder.Entity("TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities.MembershipType", b =>
                {
                    b.Navigation("Memberships");
                });
#pragma warning restore 612, 618
        }
    }
}
