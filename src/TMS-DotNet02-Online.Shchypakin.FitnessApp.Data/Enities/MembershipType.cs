using System.Collections.Generic;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities
{
    public class MembershipType
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public ICollection<Membership> Memberships { get; set; }
    }
}
