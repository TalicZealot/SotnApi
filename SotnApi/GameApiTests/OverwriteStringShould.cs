using BizHawk.Client.Common;
using NSubstitute;
using SotnApi;
using SotnApi.Interfaces;
using System;
using Xunit;

namespace GameApiTests
{
    public class OverwriteStringShould
    {
        private const int MaxStringLenght = 31;
        [Fact]
        public void ThrowArgumentNullException_WhenTextIsNull()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IGameApi classUnderTest = new GameApi(mockedMemAPI);
            //Act&Assert
            Assert.Throws<ArgumentNullException>(() => classUnderTest.OverwriteString(default, null));
        }

        [Fact]
        public void ThrowArgumentExceptionWithCorrectMessage_WhenTextIsEmpty()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IGameApi classUnderTest = new GameApi(mockedMemAPI);
            string message = "Text cannot be empty!";
            //Act
            var exception = Assert.Throws<ArgumentException>(() => classUnderTest.OverwriteString(default, String.Empty));
            //Assert
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void CallReadByteMethodOfMemAPI_ExactlyMaxStringLenghtTimes()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IGameApi classUnderTest = new GameApi(mockedMemAPI);
            //Act
            classUnderTest.OverwriteString(default, "some text");
            //Assert
            mockedMemAPI.Received(MaxStringLenght).ReadByte(Arg.Any<long>());
        }

        [Fact]
        public void CallWriteByteMethodOfMemAPI_ExactlyMaxStringLenghtTimes()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IGameApi classUnderTest = new GameApi(mockedMemAPI);
            //Act
            classUnderTest.OverwriteString(default, "some text");
            //Assert
            mockedMemAPI.Received(MaxStringLenght).WriteByte(Arg.Any<long>(), Arg.Any<uint>());
        }
    }
}
