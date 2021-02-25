using AutoMapper;
using OB.Data.Entities;
using OB.Data.Models;

namespace OB.Data
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            //-----------------------------------------------------  Application
            CreateMap<Candidate, CandidateModel>().ReverseMap();
        }
    }
}
