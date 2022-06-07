using LinkTekTest.Application.Commands;
using LinkTekTest.Application.Mappers;
using LinkTekTest.Core.Entities;
using LinkTekTest.Core.Repositories;
using MediatR;
using System;
using System.Threading.Tasks;

namespace LinkTekTest.Application.Handlers.CommandHandlers
{
    public class UpdateCustomerHandler : IAsyncRequestHandler<UpdateCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        public UpdateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(UpdateCustomerCommand request)
        {
            var customerEntitiy = CustomerMapper.Mapper.Map<Customer>(request);
            if (customerEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var updatedCustomer = await _customerRepository.UpdateAsync(customerEntitiy);
            return updatedCustomer;
        }
    }
}
