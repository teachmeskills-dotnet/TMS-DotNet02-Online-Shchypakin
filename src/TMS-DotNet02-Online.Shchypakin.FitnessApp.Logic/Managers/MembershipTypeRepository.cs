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
    public class MembershipTypeRepository : IMembershipTypeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public MembershipTypeRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<MembershipType> Add(MembershipTypeDto membershipType)
        {
            var membershipTypeToAdd = _mapper.Map<MembershipType>(membershipType);

            await _context.MembershipTypes.AddAsync(membershipTypeToAdd);

            return membershipTypeToAdd;
        }

        public async Task<IEnumerable<MembershipTypeDto>> GetMemberShipTypesAsync()
        {
            var membershipTypes = await _context.MembershipTypes
                .ProjectTo<MembershipTypeDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return membershipTypes;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
