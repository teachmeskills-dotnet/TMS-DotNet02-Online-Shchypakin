﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TeachMeSkills.Shchypakin.Homework_8.Entities
{
    public class Membership
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int MembershipTypeId { get; set; }

        public MembershipType MembershipType { get; set; }

        public int MembershipSizeId { get; set; }

        public MembershipSize MembershipSize { get; set; }

        public bool IsActive { get; set; }

        public ICollection<MembershipHistoryRecord> MembershipHistoryRecords { get; set; }
    }
}
