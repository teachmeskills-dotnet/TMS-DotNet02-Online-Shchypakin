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

        void Update(MembershipType membershipType);

        Task<MembershipType> GetMembershipTypeByIdAsync(int id);

        bool MembershipTypeExists(int id);

        bool MembershipTypeNameExists(string type);

        Task<bool> SaveAllAsync();
    }
}
