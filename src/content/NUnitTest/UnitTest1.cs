using Moq.AutoMock;
using NUnit.Framework;
using Shouldly;

namespace NUnitTest
{
    public class Sample
    {
        private AutoMocker _mocker;

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMocker();
        }

        [Test]
        public void Test1()
        {
            //Arrange
            var sut = CreateSut();

            //Act
            var result = sut.ToString();

            //Assert
            result.ShouldNotBe("test");
        }

        private object CreateSut() => _mocker.CreateInstance<object>();
    }

}