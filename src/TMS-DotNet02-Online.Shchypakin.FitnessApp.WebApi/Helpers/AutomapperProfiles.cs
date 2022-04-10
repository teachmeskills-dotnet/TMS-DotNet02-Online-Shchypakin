using AutoMapper;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Enities;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Dto;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.WebApi.Helpers
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()//MembershypHistoryRecordsDto
        {
            CreateMap<Client, MemberDto>();
            CreateMap<Client, MembersNamesDto>();
            CreateMap<FromClientMemberDto, Client>();
            CreateMap<Membership, MembershipDto>();
            CreateMap<Membership, FromClientMembershipDto>();
            CreateMap<MembershipToAdd, Membership>();
            CreateMap<FromClientMembershipDto, Membership>();
            CreateMap<MembershipSize, MembershipSizeDto>();
            CreateMap<MembershipType, MembershipTypeDto>();
            CreateMap<RegisterDto, Client>();
            CreateMap<MembershipHistoryRecord, MembershypHistoryRecordsDto>();
            CreateMap<MembershypHistoryRecordsDto, MembershipHistoryRecord>();
        }
    }
}
