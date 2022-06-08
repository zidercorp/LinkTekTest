using FluentAssertions;
using LinkTekTest.Application.Handlers.QueryHandlers;
using LinkTekTest.Application.UnitTests.Base;
using LinkTekTest.Core.Entities;
using LinkTekTest.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace LinkTekTest.Application.UnitTests.UseCases
{
    public class GetAllCustomersHandlerTests : UnitTestBase<GetAllCustomerHandler>
    {
        [Fact]
        public async Task Handle_ShouldReturnNull_WhenRepoReturnsNull()
        {
            //Arrange
            Mocker.GetMock<ICustomerRepository>().Setup(x => x.GetAllAsync()).Returns(Task.FromResult((IReadOnlyList<Customer>)null));

            //Act
            var result = await Sut.Handle(new Queries.GetAllCustomerQuery());

            //Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task Handle_ShouldReturnEmpty_WhenRepoReturnsEmpty()
        {
            //Arrange
            Mocker.GetMock<ICustomerRepository>().Setup(x => x.GetAllAsync()).Returns(Task.FromResult((IReadOnlyList<Customer>)new List<Customer>()));

            //Act
            var result = await Sut.Handle(new Queries.GetAllCustomerQuery());

            //Assert
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task Handle_ShouldReturnList_WhenRepoReturnsList()
        {
            //Arrange
            var list = new List<Customer>
            {
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "Dhave",
                    LastName = "Dayao"
                }
            };

            Mocker.GetMock<ICustomerRepository>().Setup(x => x.GetAllAsync()).Returns(Task.FromResult((IReadOnlyList<Customer>)list));

            //Act
            var result = await Sut.Handle(new Queries.GetAllCustomerQuery());

            //Assert
            result.Should().BeEquivalentTo(list);
        }
    }
}
