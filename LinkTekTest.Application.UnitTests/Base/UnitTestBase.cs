using Moq;
using Moq.AutoMock;

namespace LinkTekTest.Application.UnitTests.Base
{
    public class UnitTestBase<TSut> where TSut : class
    {
        public UnitTestBase()
        {
            Mocker = new AutoMocker(Moq.MockBehavior.Default, Moq.DefaultValue.Mock);
            Sut = Mocker.CreateInstance<TSut>();
            SutMock = Mocker.GetMock<TSut>();
        }

        public AutoMocker Mocker { get; }

        public TSut Sut { get; set; }

        public Mock<TSut> SutMock { get; set; }
    }
}
