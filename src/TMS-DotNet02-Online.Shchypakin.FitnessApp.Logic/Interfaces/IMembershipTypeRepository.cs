using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Dto;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Interfaces
{
    public interface IMembershipTypeRepository
    {
        Task<IEnumerable<MembershipTypeDto>> GetMemberShipTypesAsync();

        Task<MembershipType> Add(MembershipTypeDto membershipType);

        Task<bool> SaveAllAsync();
    }
}
