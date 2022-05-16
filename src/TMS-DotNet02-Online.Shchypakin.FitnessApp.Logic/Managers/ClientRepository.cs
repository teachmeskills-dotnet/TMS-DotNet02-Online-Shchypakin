using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Context;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Dto;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Interfaces;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Managers
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;


        public ClientRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Client> GetClientByClientNameAsync(string clientName)
        {
            return await _context.Users
                .Include(c => c.Memberships)
                .SingleOrDefaultAsync(x => x.Fullname == clientName);
        }

        public async Task<MemberDto> GetClientByIdAsync(int id)
        {
            var users = await _context.Users.ProjectTo<MemberDto>(_mapper.ConfigurationProvider).ToListAsync();
            return users.Where(x => x.Id == id).SingleOrDefault();
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _context.Users
                .Include(c => c.Memberships)
                .ToListAsync();
        }

        public async Task<MemberDto> GetMemberAsync(string clientname)
        {
            var client = await _context.Users
                .Where(x => x.Fullname == clientname)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();

            return client;
        }

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {


            var clients = await _context.Users
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var clientsToSend = clients.Select(c => new MemberDto
            {
                FullName = c.FullName,
                PhoneNumber = c.PhoneNumber,
                Birthday = c.Birthday,
                Comment = c.Comment,
                Memberships = c.Memberships.Where(m => m.IsActive == true).ToList()
            });

            return clientsToSend;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
        }

        public bool ClientExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        public async Task<IEnumerable<MembersNamesDto>> GetMembersNamesAsync()
        {
            var clientsNames = await _context.Users
                .ProjectTo<MembersNamesDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return clientsNames;
        }

        public async Task<Client> GetRawClientByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
