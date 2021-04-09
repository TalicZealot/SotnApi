using BizHawk.Client.Common;
using NSubstitute;
using SotnApi;
using SotnApi.Constants.Values.Alucard;
using SotnApi.Interfaces;
using System;
using Xunit;

namespace AlucardApiTests
{
    public class TakeOneItemByNameShould
    {
        [Fact]
        public void ThrowArgumentNullException_WhenNameIsNull()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IAlucardApi classUnderTest = new AlucardApi(mockedMemAPI);
            //Act&Assert
            Assert.Throws<ArgumentNullException>(() => classUnderTest.TakeOneItemByName(null));
        }

        [Fact]
        public void ThrowArgumentExceptionWithCorrectMessage_WhenNameIsInvalid()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IAlucardApi classUnderTest = new AlucardApi(mockedMemAPI);
            string message = "Invalid item name!";
            //Act
            var exception = Assert.Throws<ArgumentException>(() => classUnderTest.TakeOneItemByName("invalid item"));
            //Act&Assert
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void CallReadByteMethodOfMemAPI_ExactlyOneTime()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            mockedMemAPI
                .ReadByte(Arg.Any<long>())
                .ReturnsForAnyArgs<uint>(1);
            IAlucardApi classUnderTest = new AlucardApi(mockedMemAPI);
            //Act
            classUnderTest.TakeOneItemByName(Equipment.Items[0]);
            //Assert
            mockedMemAPI.Received(1).ReadByte(Arg.Any<long>());
        }

        [Fact]
        public void CallWriteByteMethodOfMemAPI_ExactlyOneTime_WithExpectedValue()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            mockedMemAPI
                .ReadByte(Arg.Any<long>())
                .ReturnsForAnyArgs<uint>(1);
            IAlucardApi classUnderTest = new AlucardApi(mockedMemAPI);
            //Act
            classUnderTest.TakeOneItemByName(Equipment.Items[0]);
            //Assert
            mockedMemAPI.Received(1).WriteByte(Arg.Any<long>(), 0);
        }
    }
}
