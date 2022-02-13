using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Context;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Dto;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Interfaces;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Managers;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.WebApi.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<Client> _userManager;
        private readonly SignInManager<Client> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly DataContext _dataContext;

        public AccountController(UserManager<Client> userManager, SignInManager<Client> signInManager, 
            ITokenService tokenService, IMapper mapper, 
            RoleManager<AppRole> roleManager, DataContext dataContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
            _roleManager = roleManager;
            _dataContext = dataContext;
        }

        [HttpPost("seed")]
        public async Task<ActionResult> SeedData()
        {
            await Seed.SeedData(_userManager, _dataContext, _roleManager);
            return Ok();
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await ClientExist(registerDto.Username)) return BadRequest("Username is taken");

            var client = _mapper.Map<Client>(registerDto);

            client.UserName = registerDto.Username.ToLower();

            client.Fullname = registerDto.Username.ToLower();

            var result = await _userManager.CreateAsync(client, registerDto.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleRequest = await _userManager.AddToRoleAsync(client, "Member");

            if (!roleRequest.Succeeded) return BadRequest(result.Errors);

            return new UserDto
            {
                Username = client.UserName,

                Token = await _tokenService.CreateToken(client)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users
                .Include(u => u.Memberships)
                .SingleOrDefaultAsync(x => x.UserName == loginDto.ClientName.ToLower());

            if (user == null) return Unauthorized("Invalid user name");

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized();

            return new UserDto
            {
                Username = loginDto.ClientName,
                Token = await _tokenService.CreateToken(user)
            };
        }


        private async Task<bool> ClientExist(string clientName)
        {
            return await _userManager.Users.AnyAsync(x => x.Fullname == clientName.ToLower());
        }

    }
}
