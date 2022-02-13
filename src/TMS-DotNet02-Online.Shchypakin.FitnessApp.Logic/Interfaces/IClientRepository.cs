using System;
using System.Collections.Generic;
using System.Linq;
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

        Task<Client> GetClientByIdAsync(int id);

        Task<Client> GetClientByClientNameAsync(string clientName);

        Task<MemberDto> GetMemberAsync(string clientname);

        Task<IEnumerable<MemberDto>> GetMembersAsync();

    }
}
