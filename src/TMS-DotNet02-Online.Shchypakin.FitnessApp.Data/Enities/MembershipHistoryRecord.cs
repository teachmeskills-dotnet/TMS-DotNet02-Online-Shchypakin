﻿using System;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities
{
    public class MembershipHistoryRecord
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int MembershipId { get; set; }

        public Membership Membership { get; set; }
    }
}
