using AutoMapper;
using Feeder.Core.Domain;
using Feeder.Core.Dto;
using System;

namespace Feeder.Infrastructure.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Post, PostDto>();
        }
    }
}