using System.Threading.Tasks;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Interfaces
{
    public interface IHistoryRecordRepository
    {
        void Update(MembershipHistoryRecord record);

        Task<bool> SaveAllAsync();

        Task<MembershipHistoryRecord> GetMembershipByIdAsync(int id);

        Task<MembershipHistoryRecord> Add(MembershipHistoryRecord record);

        Task<bool> Remove(int id);

        bool MembershipExists(int id);

        bool MembershipHistoryExists(int id);
    }
}
