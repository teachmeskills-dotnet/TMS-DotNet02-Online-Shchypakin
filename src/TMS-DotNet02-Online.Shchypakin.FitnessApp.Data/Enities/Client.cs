using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities
{
    public class Client : IdentityUser<int>
    {

        public string Fullname { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime LastVisit { get; set; }

        public string Comment { get; set; }

        public ICollection<Membership> Memberships { get; set; }

        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
