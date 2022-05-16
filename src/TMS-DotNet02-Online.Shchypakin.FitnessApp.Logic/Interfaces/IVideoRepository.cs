using System.Collections.Generic;
using System.Threading.Tasks;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Interfaces
{
    public interface IVideoRepository
    {

        Task<bool> SaveAllAsync();

        Task<IEnumerable<Videolinks>> GetVideolinksAsync();

        Task<Videolinks> GetVideolinkByIdAsync(int id);

        Task<Videolinks> Add(Videolinks record);

        Task<bool> Remove(int id);

        bool VideolinkExists(int id);
    }
}
