using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
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
    public class MembershipSizeRepository : IMembershipSizeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public MembershipSizeRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<MembershipSize> Add(MembershipSizeDto membershipSize)
        {
            var membershipSizeToAdd = _mapper.Map<MembershipSize>(membershipSize);

            await _context.MembershipSizes.AddAsync(membershipSizeToAdd);

            return membershipSizeToAdd;
        }

        public async Task<IEnumerable<MembershipSizeDto>> GetMemberShipSizesAsync()
        {
            var membershipTypes = await _context.MembershipSizes
                .ProjectTo<MembershipSizeDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return membershipTypes;
        }

        public bool MembershipSizeCountExists(int count)
        {
            return _context.MembershipSizes.Any(e => e.Count == count);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
