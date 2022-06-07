using LinkTekTest.Core.Entities;

namespace LinkTekTest.Messages
{
    public class UpdatedCustomerMessage
    {
        public UpdatedCustomerMessage(Customer customer)
        {
            Customer = customer;
        }

        public Customer Customer { get; }
    }
}
