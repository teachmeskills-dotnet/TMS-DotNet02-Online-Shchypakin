using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachMeSkills.Shchypakin.Homework_8.Entities
{
    public class MembershipHistoryRecord
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int MembershipId { get; set; }

        public Membership Membership { get; set; }
    }
}
