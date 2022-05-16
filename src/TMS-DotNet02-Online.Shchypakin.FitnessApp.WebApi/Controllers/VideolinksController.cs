using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Dto;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Interfaces;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.WebApi.Controllers
{
    public class VideolinksController : BaseApiController
    {
        private readonly IVideoRepository _videolinksRepository;
        private readonly IMapper _mapper;

        public VideolinksController(IVideoRepository videolinksRepository, IMapper mapper)
        {
            _videolinksRepository = videolinksRepository;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Add")]
        public async Task<ActionResult<VideolinksDto>> Add(VideolinksDto videolink)
        {
            var videolinkToAdd = _mapper.Map<Videolinks>(videolink);

            var videolinkToSend = await _videolinksRepository.Add(videolinkToAdd);

            if (await _videolinksRepository.SaveAllAsync())
            {
                return _mapper.Map<VideolinksDto>(videolinkToSend);
            }
            return BadRequest("Failed to add");
        }

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<ActionResult<Videolinks>> GetAll()
        {
            var videolinks = await _videolinksRepository.GetVideolinksAsync();

            return Ok(videolinks);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!_videolinksRepository.VideolinkExists(id))
                return NotFound("Такого видео в базе не существует");


            if (await _videolinksRepository.Remove(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Не удалось удалить запись");
            }
        }
    }
}
