using LinkTekTest.Core.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LinkTekTest.Infrastructure.Data
{
    public class LinkTekTestContext : DbContext
    {
        public LinkTekTestContext() : base("LinkTekTestContext")
        {

        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
