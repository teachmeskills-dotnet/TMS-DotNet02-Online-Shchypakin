using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachMeSkills.Shchypakin.Homework_8.Entities
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public Client User { get; set; }

        public AppRole Role { get; set; }
    }
}
