using AutoMapper;
using GatewayAPI.Models.Entities;
using GatewayAPI.Models.ModelsDto;

namespace GatewayAPI.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Gateway, GatewayDto>();
            CreateMap<Gateway,GatewayDtoNotPeripherals>();           
            CreateMap<GatewayDtoForCreation, Gateway>();           
           
            CreateMap<Peripheral, PeripheralDto>();
            CreateMap<PeripheralDtoForCreation, Peripheral>();

        }
    }
}
