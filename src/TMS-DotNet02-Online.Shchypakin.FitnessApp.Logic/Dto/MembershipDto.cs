using System;
using System.Collections.Generic;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Dto
{
    public class MembershipDto
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        //public int MembershipTypeId { get; set; }

        //public int MembershipSizeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        public MembershipSizeDto MembershipSize { get; set; }

        public int VisitsLeft { get; set; }

        public ICollection<MembershypHistoryRecordsDto> MembershipHistoryRecords { get; set; }

        public bool IsActive { get; set; }

        public bool Online { get; set; }
    }
}