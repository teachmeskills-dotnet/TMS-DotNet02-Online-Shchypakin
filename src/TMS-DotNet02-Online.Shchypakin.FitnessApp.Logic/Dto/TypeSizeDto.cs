using System.Collections.Generic;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Dto
{
    public class TypeSizeDto
    {
        public ICollection<MembershipTypeDto> Types { get; set; }

        public ICollection<MembershipSizeDto> Sizes { get; set; }
    }
}
