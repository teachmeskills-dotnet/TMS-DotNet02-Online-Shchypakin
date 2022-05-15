﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Context;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Interfaces;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Managers
{
    public class HistoryRecordRepository : IHistoryRecordRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public HistoryRecordRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MembershipHistoryRecord> Add(MembershipHistoryRecord record)
        {
            await _context.MembershipHistoryRecords.AddAsync(record);

            return record;
        }

        public Task<MembershipHistoryRecord> GetMembershipByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(MembershipHistoryRecord record)
        {
            _context.Entry(record).State = EntityState.Modified;
        }

        public bool MembershipExists(int id)
        {
            return _context.Memberships.Any(e => e.Id == id);
        }

        public async Task<bool> Remove(int id)
        {
            var recordToRemove = await _context.MembershipHistoryRecords.FindAsync(id);

            _context.MembershipHistoryRecords.Remove(recordToRemove);

            return await _context.SaveChangesAsync() > 0;

        }

        public bool MembershipHistoryExists(int id)
        {
            return _context.MembershipHistoryRecords.Any(e => e.Id == id);
        }
    }
}
