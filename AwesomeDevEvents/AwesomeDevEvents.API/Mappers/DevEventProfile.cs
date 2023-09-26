﻿using AutoMapper;
using AwesomeDevEvents.API.Entities;
using AwesomeDevEvents.API.Models;

namespace AwesomeDevEvents.API.Mappers
{
    public class DevEventProfile : Profile
    {
       public DevEventProfile() 
       {
            CreateMap<DevEvent, DevEventViewModel>();
            CreateMap<DevEventSpeaker,DevEventSpeakerViemModel>();

            CreateMap<DevEventInputModel, DevEvent>();
            CreateMap<DevEventSpeakerInputModel, DevEventSpeaker>();
       }
    }
}
