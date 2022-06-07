using LinkTekTest.Core.Entities;
using MediatR;

namespace LinkTekTest.Application.Commands
{
    public class UpdateCustomerCommand : IRequest<Customer>
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Phone { get; set; }

        public int Age { get; set; }

        public decimal Sales { get; set; }
    }
}
