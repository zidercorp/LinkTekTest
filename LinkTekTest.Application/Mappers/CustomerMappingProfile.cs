using AutoMapper;
using LinkTekTest.Application.Commands;
using LinkTekTest.Application.Models;
using LinkTekTest.Core.Entities;

namespace LinkTekTest.Application.Mappers
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
            CreateMap<Customer, CustomerModel>().ReverseMap();
        }
    }
}
