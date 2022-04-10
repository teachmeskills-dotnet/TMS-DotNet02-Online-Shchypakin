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

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetClients()
        {
            var clients = await _clientRepository.GetMembersAsync();
            return Ok(clients);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("ClientsNames")]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetClientsNames()
        {
            var clientsNames = await _clientRepository.GetMembersNamesAsync();
            return Ok(clientsNames);
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

        [Authorize(Roles = "Admin")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<MemberDto>> GetClientById(int id)
        {
            if (!_clientRepository.ClientExists(id))
                return NotFound($"Client with Id = {id} not found");

            var client = await _clientRepository.GetClientByIdAsync(id);

            DateTime lastVisit = DateTime.MinValue;

            foreach(var membership in client.Memberships)
            {
                foreach(var record in membership.MembershipHistoryRecords)
                {
                    if(record.Date > lastVisit)
                    {
                        lastVisit = record.Date;
                    }
                }
            }

            client.LastVisit = lastVisit;

            var memberships = client.Memberships.Where(m => m.End > DateTime.UtcNow).ToList();

            foreach(var membership in memberships)
            {
                membership.VisitsLeft = membership.MembershipSize.Count - membership.MembershipHistoryRecords.Count;
            }

            client.Memberships = memberships;
            
            var clientToSend = _mapper.Map<MemberDto>(client);

            return clientToSend;
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Client>> UpdateClient(int id, FromClientMemberDto client)
        {
            if (id != client.Id)
                return BadRequest("Client ID mismatch");

            if (!_clientRepository.ClientExists(id))
                return NotFound($"Client with Id = {id} not found");

            var clientToUpdate = await _clientRepository.GetRawClientByIdAsync(id);

            _mapper.Map(client, clientToUpdate);

            _clientRepository.Update(clientToUpdate);

            await _clientRepository.SaveAllAsync();

            return Ok();
        }
    }
}
