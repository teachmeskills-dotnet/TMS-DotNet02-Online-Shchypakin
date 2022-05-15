using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
