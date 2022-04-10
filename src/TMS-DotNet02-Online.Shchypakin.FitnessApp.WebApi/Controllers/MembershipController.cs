using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Dto;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Interfaces;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.WebApi.Controllers
{
    public class MembershipController : BaseApiController
    {
        private readonly IMembershipRepository _membershipRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public MembershipController(IMembershipRepository membershipRepository, 
            IClientRepository clientRepository, IMapper mapper)
        {
            _membershipRepository = membershipRepository;
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Add")]
        public async Task<ActionResult<MembershipDto>> Add(MembershipToAdd membership)
        {
            if (!_clientRepository.ClientExists(membership.ClientId))
                return NotFound($"Client with Id = {membership.ClientId} not found");

            var membershipToAdd = _mapper.Map<Membership>(membership);

            var membershipToSend = await _membershipRepository.Add(membershipToAdd);

            if (await _membershipRepository.SaveAllAsync())
            {
                return _mapper.Map<MembershipDto>(membershipToSend);
            }
            return BadRequest("Failed to add");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Update")]
        public async Task<ActionResult<MembershipDto>> Update(FromClientMembershipDto membership)
        {
            if (!_membershipRepository.MembershipExists(membership.Id))
                return BadRequest("Membership doesn't exist");

            var membershipToUpdate = await _membershipRepository.GetMembershipByIdAsync(membership.Id);

            _mapper.Map(membership, membershipToUpdate);

            _membershipRepository.Update(membershipToUpdate);

            await _membershipRepository.SaveAllAsync();

            return Ok();
        }
    }
}
