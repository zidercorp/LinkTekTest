using LinkTekTest.Core.Entities;
using MediatR;
using System.Collections.Generic;

namespace LinkTekTest.Application.Queries
{
    public class GetAllCustomerQuery : IRequest<List<Customer>>
    {
        public GetAllCustomerQuery()
        {

        }
    }
}
