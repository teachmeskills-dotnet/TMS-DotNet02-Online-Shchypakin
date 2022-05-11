using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Dto;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Interfaces
{
    public interface IMembershipSizeRepository
    {
        Task<IEnumerable<MembershipSizeDto>> GetMemberShipSizesAsync();

        Task<MembershipSize> Add(MembershipSizeDto membershipSize);

        bool MembershipSizeCountExists(int count);

        Task<bool> SaveAllAsync();
    }
}
