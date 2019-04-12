using AutoMapper;
using Repo;
using SharedContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.MapperProfiles
{
    public class PatientDemographicsProfile : Profile
    {
        public PatientDemographicsProfile()
        {
            CreateMap<PatientDemographicsDto, PatientDemographics>()
            .ReverseMap();
        }
    }
}
