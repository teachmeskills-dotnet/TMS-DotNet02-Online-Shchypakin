using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Dto;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Interfaces;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.WebApi.Controllers
{
    public class ClientsController : BaseApiController
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientsController(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetClients()
        {
            var clients = await _clientRepository.GetMembersAsync();
            return Ok(clients);
        }

        //[Authorize]
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Client>> GetClient(int id)
        //{
        //    return await _clientRepository.GetClientByIdAsync(id);
        //}

        //[Authorize]
        [HttpGet("{clientname}")]
        public async Task<ActionResult<MemberDto>> GetClientByName(string clientname)
        {
            var client = await _clientRepository.GetMemberAsync(clientname);
            return client;
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Client>> UpdateClient(int id, FromClientMemberDto client)
        {
            if (id != client.Id)
                return BadRequest("Client ID mismatch");

            

            if (!_clientRepository.ClientExists(id))
                return NotFound($"Client with Id = {id} not found");

            //Client clientToUpdate = _mapper.Map<Client>(client);

            var clientToUpdate = await _clientRepository.GetClientByIdAsync(id);

            clientToUpdate.Birthday = client.Birthday;

            _clientRepository.Update(clientToUpdate);

            await _clientRepository.SaveAllAsync();

            return Ok();
        }
    }
}
