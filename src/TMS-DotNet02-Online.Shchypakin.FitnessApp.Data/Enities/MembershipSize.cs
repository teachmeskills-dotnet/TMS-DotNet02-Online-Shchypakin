﻿using System.Collections.Generic;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities
{
    public class MembershipSize
    {
        public int Id { get; set; }

        public int Count { get; set; }

        public string Comment { get; set; }

        public ICollection<Membership> Memberships { get; set; }

    }
}
