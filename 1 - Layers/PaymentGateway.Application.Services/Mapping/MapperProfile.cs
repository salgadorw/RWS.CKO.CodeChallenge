using AutoMapper;
using PaymentGateway.Application.DTO;
using PaymentGateway.Domain.Model;

namespace PaymentGateway.Application.Services.Mapping
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {

            CreateMap<CardInfoDto, CardInfoModel>().ReverseMap();
            CreateMap<PaymentDto, PaymentModel>().ReverseMap();
        }
    }
}
