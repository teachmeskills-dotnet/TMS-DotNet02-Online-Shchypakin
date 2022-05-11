using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        private readonly IMembershipSizeRepository _membershipSizeRepository;
        private readonly IMembershipTypeRepository _membershipTypeRepository;

        public MembershipController(IMembershipRepository membershipRepository, 
            IClientRepository clientRepository, IMapper mapper, 
            IMembershipSizeRepository membershipSizeRepository,
            IMembershipTypeRepository membershipTypeRepository)
        {
            _membershipRepository = membershipRepository;
            _clientRepository = clientRepository;
            _mapper = mapper;
            _membershipSizeRepository = membershipSizeRepository;
            _membershipTypeRepository = membershipTypeRepository;
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
        [HttpPost("AddType")]
        public async Task<ActionResult<MembershipType>> AddType(string membershipType)
        {
            if(_membershipTypeRepository.MembershipTypeNameExists(membershipType))
            {
                return BadRequest("A type with the same name already exists");
            }

            var newType = await _membershipTypeRepository.Add(new MembershipTypeDto { Type = membershipType });

            if( await _membershipTypeRepository.SaveAllAsync())
            {
                return Ok(newType);
            }
            return BadRequest("Failed to add");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddSize")]
        public async Task<ActionResult<MembershipSize>> AddSize(int membershipSize)
        {
            if (_membershipSizeRepository.MembershipSizeCountExists(membershipSize))
            {
                return BadRequest("A size with the same count already exists");
            }

            var newSize = await _membershipSizeRepository.Add(new MembershipSizeDto { Count = membershipSize });

            if (await _membershipSizeRepository.SaveAllAsync())
            {
                return Ok(newSize);
            }
            return BadRequest("Failed to add");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateType")]
        public async Task<ActionResult<MembershipDto>> UpdateType(MembershipTypeDto membershipType)
        {
            if (!_membershipTypeRepository.MembershipTypeExists(membershipType.Id))
                return BadRequest("Membership type doesn't exist");

            var membershipToUpdate = await _membershipTypeRepository.GetMembershipTypeByIdAsync(membershipType.Id);

            _mapper.Map(membershipType, membershipToUpdate);

            _membershipTypeRepository.Update(membershipToUpdate);

            await _membershipRepository.SaveAllAsync();

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("SizeType")]
        public async Task<ActionResult<TypeSizeDto>> GetSizeType()
        {
            var membershipTypes = await _membershipTypeRepository.GetMemberShipTypesAsync();

            var membershipSizes = await _membershipSizeRepository.GetMemberShipSizesAsync();

            var typeSize = new TypeSizeDto()
            {
                Sizes = (ICollection<MembershipSizeDto>)membershipSizes,

                Types = (ICollection<MembershipTypeDto>)membershipTypes
            };

            return Ok(typeSize);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Update")]
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

        [Authorize]
        [HttpGet("AllMemberships")]
        public async Task<ActionResult<IEnumerable<MembershipDto>>> GetAll(int clientId)
        {
            if (!_membershipRepository.MembershipExists(clientId))
                return BadRequest("Membership doesn't exist");

            var memberships = await _membershipRepository.GetAllAsync(clientId);

            foreach (var membership in memberships)
            {
                membership.VisitsLeft = membership.MembershipSize.Count - membership.MembershipHistoryRecords.Count;
            }

            return Ok(memberships);
        }

    }
}
