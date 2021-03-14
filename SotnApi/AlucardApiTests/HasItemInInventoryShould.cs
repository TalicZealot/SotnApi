using BizHawk.Client.Common;
using NSubstitute;
using SotnApi;
using SotnApi.Interfaces;
using System;
using Xunit;

namespace AlucardApiTests
{
    public class HasItemInInventoryShould
    {
        [Fact]
        public void ThrowArgumentNullException_WhenNameIsNull()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IAlucardApi classUnderTest = new AlucardApi(mockedMemAPI);
            //Act&Assert
            Assert.Throws<ArgumentNullException>(() => classUnderTest.HasItemInInventory(null));
        }

        [Fact]
        public void ThrowArgumentExceptionWithCorrectMessage_WhenNameIsInvalid()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IAlucardApi classUnderTest = new AlucardApi(mockedMemAPI);
            string message = "Invalid item name!";
            //Act
            var exception = Assert.Throws<ArgumentException>(() => classUnderTest.HasItemInInventory("invalid item"));
            //Act&Assert
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void CallReadByteMethodOfMemAPI_ExactlyOneTime()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IAlucardApi classUnderTest = new AlucardApi(mockedMemAPI);
            //Act
            classUnderTest.HasItemInInventory("empty hand");
            //Assert
            mockedMemAPI.Received(1).ReadByte(Arg.Any<long>());
        }

        [Fact]
        public void ReturnFalseWhenItemCountIsZero()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            mockedMemAPI
                .ReadByte(Arg.Any<long>())
                .ReturnsForAnyArgs<uint>(0);
            IAlucardApi classUnderTest = new AlucardApi(mockedMemAPI);
            //Act
            bool result = classUnderTest.HasItemInInventory("empty hand");
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void ReturnTrueWhenItemCountIsMoreThanZero()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            mockedMemAPI
                .ReadByte(Arg.Any<long>())
                .ReturnsForAnyArgs<uint>(1);
            IAlucardApi classUnderTest = new AlucardApi(mockedMemAPI);
            //Act
            bool result = classUnderTest.HasItemInInventory("empty hand");
            //Assert
            Assert.True(result);
        }
    }
}
