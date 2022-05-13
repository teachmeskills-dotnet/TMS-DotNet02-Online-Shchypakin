using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Dto;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Interfaces
{
    public interface IVideoRepository
    {
        
        Task<bool> SaveAllAsync();

        Task<IEnumerable<VideolinksDto>> GetVideolinksAsync();

        Task<Videolinks> GetVideolinkByIdAsync(int id);

        Task<Videolinks> Add(Videolinks record);

        Task<bool> Remove(int id);

        bool VideolinkExists(int id);
    }
}
