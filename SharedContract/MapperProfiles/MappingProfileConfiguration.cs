using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.MapperProfiles
{
    public static class MappingProfileConfiguration
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PatientDemographicsProfile()); 
            });

            return config;
        }

    }
}
