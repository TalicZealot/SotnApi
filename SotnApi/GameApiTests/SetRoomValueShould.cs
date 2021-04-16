using BizHawk.Client.Common;
using NSubstitute;
using SotnApi;
using SotnApi.Constants.Addresses;
using SotnApi.Interfaces;
using System;
using Xunit;

namespace GameApiTests
{
    public class SetRoomValueShould
    {
        [Fact]
        public void ThrowArgumentOutOfRangeExceptionWithCorrectMessage_WhenAddressIsBeforeMapAddresses()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IGameApi classUnderTest = new GameApi(mockedMemAPI);
            string message = "Not a valid map address.\r\nParameter name: address";
            //Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => classUnderTest.SetRoomValue(Game.MapStart - 0x1, default));
            //Assert
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void ThrowArgumentOutOfRangeExceptionWithCorrectMessage_WhenAddressIsAfterMapAddresses()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IGameApi classUnderTest = new GameApi(mockedMemAPI);
            string message = "Not a valid map address.\r\nParameter name: address";
            //Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => classUnderTest.SetRoomValue(Game.MapEnd + 0x1, default));
            //Assert
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void CallsWriteByteRangeMethodOfMemAPI_ExactlyOnce_WithValueOfMax()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IGameApi classUnderTest = new GameApi(mockedMemAPI);
            //Act
            classUnderTest.SetRoomToVisited(Game.MapStart + 0x1);
            //Assert
            mockedMemAPI.Received(1).WriteByte(Arg.Any<long>(), 0xFF, default);
        }
    }
}
