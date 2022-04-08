using AutoMapper;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Dto;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.WebApi.Helpers
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Client, MemberDto>();
            CreateMap<FromClientMemberDto, Client>();
            CreateMap<Membership, MembershipDto>();
            CreateMap<Membership, FromClientMembershipDto>();
            CreateMap<FromClientMembershipDto, Membership>();
            CreateMap<MembershipSize, MembershipSizeDto>();
            CreateMap<MembershipType, MembershipTypeDto>();
            CreateMap<RegisterDto, Client>();
        }
    }
}
