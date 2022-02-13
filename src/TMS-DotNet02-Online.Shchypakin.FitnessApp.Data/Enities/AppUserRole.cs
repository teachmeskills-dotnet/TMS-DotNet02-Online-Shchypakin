using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public Client User { get; set; }

        public AppRole Role { get; set; }
    }
}
