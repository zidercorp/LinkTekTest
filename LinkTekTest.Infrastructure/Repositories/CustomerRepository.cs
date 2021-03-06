using LinkTekTest.Core.Entities;
using LinkTekTest.Core.Repositories;
using LinkTekTest.Infrastructure.Data;
using LinkTekTest.Infrastructure.Repositories.Base;
using System.Threading.Tasks;

namespace LinkTekTest.Infrastructure.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(LinkTekTestContext linkTekTestContext) : base(linkTekTestContext)
        {

        }

        public override async Task<Customer> UpdateAsync(Customer customer)
        {
            var existingCustomer = await _linkTekTestContext.Customers.FindAsync(customer.CustomerId);

            if (existingCustomer == null)
            {
                return null;
            }

            customer.UpdatedTime = System.DateTime.UtcNow;
            customer.CreatedTime = existingCustomer.CreatedTime;

            _linkTekTestContext.Entry(existingCustomer).CurrentValues.SetValues(customer);

            _linkTekTestContext.SaveChanges();

            return customer;
        }
    }
}
