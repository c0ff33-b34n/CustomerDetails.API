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
            CreateMap<CreateCustomerDto, Customer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<EditCustomerDto, Customer>();
        }
    }
}