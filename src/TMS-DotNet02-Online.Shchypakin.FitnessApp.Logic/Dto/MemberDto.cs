using System;
using System.Collections.Generic;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Dto
{
    public class MemberDto
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime LastVisit { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Comment { get; set; }

        public ICollection<MembershipDto> Memberships { get; set; }
    }
}
