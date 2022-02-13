using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachMeSkills.Shchypakin.Homework_8.Entities
{
    public class MembershipType
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public ICollection<Membership> Memberships { get; set; }
    }
}
