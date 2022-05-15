using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Context;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Managers

{
    public static class Seed
    {
        public static async Task SeedData(UserManager<Client> userManager,
            DataContext context, RoleManager<AppRole> roleManager)
        {
            MembershipSize membershipSize8 = new MembershipSize
            {
                Count = 8
            };

            MembershipSize membershipSize12 = new MembershipSize
            {
                Count = 12
            };

            MembershipType membershipTypeOff = new MembershipType
            {
                Type = "Offline"
            };

            MembershipType membershipTypeOn = new MembershipType
            {
                Type = "Online"
            };

            Client client1 = new Client
            {
                UserName = "jennifer lopez",
                Fullname = "jennifer lopez"
            };

            Client client = new Client
            {
                UserName = "madonna",
                Fullname = "madonna"
            };

            Client admin = new Client
            {
                UserName = "admin",
                Fullname = "admin"
            };

            Membership membership1 = new Membership
            {
                ClientId = 2,
                MembershipSizeId = 1,
                MembershipTypeId = 1,
                IsActive = false
            };

            Membership membership2 = new Membership
            {
                ClientId = 1,
                MembershipSizeId = 1,
                MembershipTypeId = 1,
                IsActive = true
            };

            Membership membership3 = new Membership
            {
                ClientId = 1,
                MembershipSizeId = 2,
                MembershipTypeId = 2,
                IsActive = false
            };

            var roles = new List<AppRole>
            {
                new AppRole{Name = "Member"},
                new AppRole{Name = "Coach"},
                new AppRole{Name = "Admin"},
                new AppRole{Name = "Moderator"},
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            context.MembershipSizes.Add(membershipSize8);
            context.MembershipSizes.Add(membershipSize12);
            context.MembershipTypes.Add(membershipTypeOff);
            context.MembershipTypes.Add(membershipTypeOn);
            context.Users.Add(client1);
            context.Users.Add(client);
            await userManager.CreateAsync(client, "Shoroh47");
            await userManager.CreateAsync(client1, "Shoroh47");
            await userManager.CreateAsync(admin, "Shoroh47");
            await userManager.AddToRoleAsync(client, "Member");
            await userManager.AddToRoleAsync(client1, "Member");
            await userManager.AddToRolesAsync(admin, new[] { "Admin", "Moderator" });
            context.Memberships.Add(membership1);
            context.Memberships.Add(membership2);
            context.Memberships.Add(membership3);

            context.SaveChanges();
        }
    }
}
