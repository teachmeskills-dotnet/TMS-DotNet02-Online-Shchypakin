using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachMeSkills.Shchypakin.Homework_8.Entities
{
    public class MembershipSize
    {
        public int Id { get; set; }

        public int Count { get; set; }

        public string Comment { get; set; }

        public ICollection<Membership> Memberships { get; set; }

    }
}
