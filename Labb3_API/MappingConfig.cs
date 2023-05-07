using AutoMapper;
using AutoMapper.Execution;
using Labb3_API.Models;
using Labb3_API.Models.DTO.InterestDTO;
using Labb3_API.Models.DTO.ListDTO;
using Labb3_API.Models.DTO.MemberDTO;
using Member = Labb3_API.Models.Member; // Jag var tvungen att lägga till denna using, varför vet jag inte riktigt

namespace Labb3_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Member, MemberDTO>().ReverseMap();
            CreateMap<Member, MemberCreateDTO>().ReverseMap();
            CreateMap<Member, MemberUpdateDTO>().ReverseMap();

            CreateMap<Interest, InterestDTO>().ReverseMap();
            CreateMap<Interest, InterestCreateDTO>().ReverseMap();
            CreateMap<Interest, InterestUpdateDTO>().ReverseMap();

            CreateMap<Link, LinkCreateDTO>().ReverseMap();
            CreateMap<Link, LinkDTO>().ReverseMap();
            CreateMap<Link, LinkUpdateDTO>().ReverseMap();

        }
    }
}
