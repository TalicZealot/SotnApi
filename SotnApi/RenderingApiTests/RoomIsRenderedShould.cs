using BizHawk.Client.Common;
using NSubstitute;
using SotnApi;
using SotnApi.Interfaces;
using System;
using Xunit;

namespace MapApiTests
{
    public class RoomIsRenderedShould
    {
        private const int Height = 207;
        private const int Width = 255;

        [Fact]
        public void ThrowArgumentOutOfRangeException_WhenYIsGreaterThanHeight()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IMapApi classUnderTest = new MapApi(mockedMemAPI);
            string paramName = "y";
            //Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => classUnderTest.RoomIsRendered(default, Height + 1, 1));
            //Assert
            Assert.Equal(paramName, exception.ParamName);
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_WhenXIsGreaterThanWidth()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IMapApi classUnderTest = new MapApi(mockedMemAPI);
            string paramName = "x";
            //Act&Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => classUnderTest.RoomIsRendered(Width + 1, default, 1));
            //Assert
            Assert.Equal(paramName, exception.ParamName);
        }

        [Fact]
        public void CallReadByteMethodOfMemAPI_ExactlyOneTime_WithGpuramParameter()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IMapApi classUnderTest = new MapApi(mockedMemAPI);
            //Act
            classUnderTest.RoomIsRendered(default, default, 1);
            //Assert
            mockedMemAPI.Received(1).ReadByte(Arg.Any<long>(), "GPURAM");
        }
    }
}
