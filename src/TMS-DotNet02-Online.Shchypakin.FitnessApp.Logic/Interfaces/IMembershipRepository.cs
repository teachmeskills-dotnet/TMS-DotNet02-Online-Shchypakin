using System.Collections.Generic;
using System.Threading.Tasks;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Dto;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Interfaces
{
    public interface IMembershipRepository
    {
        void Update(Membership membership);

        Task<bool> SaveAllAsync();

        Task<Membership> GetMembershipByIdAsync(int id);

        Task<Membership> Add(Membership membership);

        Task<IEnumerable<MembershipDto>> GetAllAsync(int clientId);

        bool MembershipExists(int id);
    }
}
