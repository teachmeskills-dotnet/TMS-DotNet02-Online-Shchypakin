using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Context;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Interfaces;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Managers
{
    public class VideoRepository : IVideoRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public VideoRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Videolinks> Add(Videolinks record)
        {
            await _context.Videolinks.AddAsync(record);

            return record;
        }

        public Task<Videolinks> GetVideolinkByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Videolinks>> GetVideolinksAsync()
        {
            var videolinks = await _context.Videolinks.ToListAsync();

            return videolinks;
        }

        public async Task<bool> Remove(int id)
        {
            var videolinkToRemove = await _context.Videolinks.FindAsync(id);

            _context.Videolinks.Remove(videolinkToRemove);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool VideolinkExists(int id)
        {
            return _context.Videolinks.Any(x => x.Id == id);
        }
    }
}
