using System;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Dto
{
    public class FromClientMembershipDto
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int MembershipTypeId { get; set; }

        public int MembershipSizeId { get; set; }

        public bool Online { get; set; }

        public bool IsActive { get; set; }
    }
}
