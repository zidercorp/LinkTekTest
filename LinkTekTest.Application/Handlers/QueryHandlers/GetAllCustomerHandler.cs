using LinkTekTest.Application.Queries;
using LinkTekTest.Core.Entities;
using LinkTekTest.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinkTekTest.Application.Handlers.QueryHandlers
{
    public class GetAllCustomerHandler : IAsyncRequestHandler<GetAllCustomerQuery, List<Customer>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> Handle(GetAllCustomerQuery request)
        {
            return (List<Customer>) await _customerRepository.GetAllAsync();
        }
    }
}
