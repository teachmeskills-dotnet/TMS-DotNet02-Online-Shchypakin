using System.Collections.Generic;
using System.Threading.Tasks;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Dto;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Interfaces
{
    public interface IClientRepository
    {
        void Update(Client client);

        Task<bool> SaveAllAsync();

        Task<IEnumerable<Client>> GetClientsAsync();

        Task<MemberDto> GetClientByIdAsync(int id);

        Task<Client> GetRawClientByIdAsync(int id);

        Task<Client> GetClientByClientNameAsync(string clientName);

        Task<MemberDto> GetMemberAsync(string clientname);

        Task<IEnumerable<MemberDto>> GetMembersAsync();

        Task<IEnumerable<MembersNamesDto>> GetMembersNamesAsync();

        bool ClientExists(int id);

    }
}
