using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Dto;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Interfaces;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.WebApi.Controllers
{
    public class HistoryRecordController : BaseApiController
    {
        private readonly IHistoryRecordRepository _recordRepository;
        private readonly IMapper _mapper;

        public HistoryRecordController(IHistoryRecordRepository historyRecordRepository, IMapper mapper)
        {
            _recordRepository = historyRecordRepository;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Add")]
        public async Task<ActionResult<MembershypHistoryRecordsDto>> Add(MembershypHistoryRecordsDto record)
        {
            if (!_recordRepository.MembershipExists(record.MembershipId))
                return NotFound($"Membership with Id = {record.MembershipId} not found");

            var recordToAdd = _mapper.Map<MembershipHistoryRecord>(record);

            var recordToSend = await _recordRepository.Add(recordToAdd);

            if (await _recordRepository.SaveAllAsync())
            {
                return _mapper.Map<MembershypHistoryRecordsDto>(recordToSend);
            }
            return BadRequest("Failed to add");
        }


    }
}
