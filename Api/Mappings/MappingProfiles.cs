using Api.Dtos;
using AutoMapper;
using Core.Entities;

namespace Api.Mappings;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, ProductResponse>();
    }   
}
