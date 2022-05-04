using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Context;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Dto;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Interfaces;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Managers
{
    public class MembershipRepository : IMembershipRepository
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public MembershipRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool MembershipExists(int id)
        {
            return _context.Memberships.Any(e => e.Id == id);
        }

        public async Task<Membership> GetMembershipByIdAsync(int id)
        {
            return await _context.Memberships.FindAsync(id);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Membership membership)
        {
            _context.Entry(membership).State = EntityState.Modified;
        }

        public async Task<Membership> Add(Membership membership)
        {
            await _context.Memberships.AddAsync(membership);
            
            return membership;
        }

        public async Task<IEnumerable<MembershipDto>> GetAllAsync(int clientId)
        {
            return await _context.Memberships.Where(m => m.ClientId == clientId)
                .ProjectTo<MembershipDto>(_mapper.ConfigurationProvider).ToListAsync();
                                        ;
        }
    }
}
