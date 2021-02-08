using AutoMapper;
using CustomerDetailsApi.Models;

namespace CustomerDetailsApi.Mappers
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerNameToReturnDto>();
            CreateMap<Customer, CustomerToReturnDto>();
        }
    }
}