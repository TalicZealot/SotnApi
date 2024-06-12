using BizHawk.Client.Common;
using NSubstitute;
using SotnApi;
using SotnApi.Interfaces;
using System;
using Xunit;

namespace MapApiTests
{
    public class ColorMapRoomShould
    {
        private const int Height = 207;
        private const int Width = 255;
        private const int MaximumColorValue = 0xF;

        [Fact]
        public void ThrowArgumentOutOfRangeException_WhenRowIsGreaterThanMaximumMapRows()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IMapApi classUnderTest = new MapApi(mockedMemAPI);
            string paramName = "y";
            //Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => classUnderTest.ColorMapRoom(default, Height + 1, default, default));
            //Assert
            Assert.Equal(paramName, exception.ParamName);
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_WhenYIsGreaterThanHeight()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IMapApi classUnderTest = new MapApi(mockedMemAPI);
            string paramName = "x";
            //Act&Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => classUnderTest.ColorMapRoom(Width + 1, default, default, default));
            //Assert
            Assert.Equal(paramName, exception.ParamName);
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_WhenXIsGreaterThanWidth()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IMapApi classUnderTest = new MapApi(mockedMemAPI);
            string paramName = "color";
            //Act&Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => classUnderTest.ColorMapRoom(default, default, MaximumColorValue + 1, default));
            //Assert
            Assert.Equal(paramName, exception.ParamName);
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_WhenBorderColorIsGreaterThanMaximumColorValue()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IMapApi classUnderTest = new MapApi(mockedMemAPI);
            string paramName = "borderColor";
            //Act&Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => classUnderTest.ColorMapRoom(default, default, default, MaximumColorValue + 1));
            //Assert
            Assert.Equal(paramName, exception.ParamName);
        }

        [Fact]
        public void CallWriteByteMethodOfMemAPI_ExactlyFifteenTimes_WithGpuramParameter()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IMapApi classUnderTest = new MapApi(mockedMemAPI);
            //Act
            classUnderTest.ColorMapRoom(default, default, default, default);
            //Assert
            mockedMemAPI.Received(15).WriteByte(Arg.Any<long>(), Arg.Any<uint>(), "GPURAM");
        }
    }
}
