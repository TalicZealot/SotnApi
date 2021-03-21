using BizHawk.Client.Common;
using NSubstitute;
using SotnApi;
using SotnApi.Interfaces;
using System;
using Xunit;

namespace RenderingApiTests
{
    public class ColorMapLocationShould
    {
        private const int MaximumMapRows = 255;
        private const int MaximumMapCols = 255;
        private const int MaximumColorValue = 0xF;

        [Fact]
        public void ThrowArgumentOutOfRangeException_WhenRowIsGreaterThanMaximumMapRows()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IRenderingApi classUnderTest = new RenderingApi(mockedMemAPI);
            string paramName = "row";
            //Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => classUnderTest.ColorMapLocation(MaximumMapRows + 1, default, default));
            //Assert
            Assert.Equal(paramName, exception.ParamName);
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_WhenColIsGreaterThanMaximumMapCols()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IRenderingApi classUnderTest = new RenderingApi(mockedMemAPI);
            string paramName = "col";
            //Act&Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => classUnderTest.ColorMapLocation(default, MaximumMapCols + 1, default));
            //Assert
            Assert.Equal(paramName, exception.ParamName);
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_WhenColorIsGreaterThanMaximumColorValue()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IRenderingApi classUnderTest = new RenderingApi(mockedMemAPI);
            string paramName = "color";
            //Act&Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => classUnderTest.ColorMapLocation(default, default, MaximumColorValue + 1));
            //Assert
            Assert.Equal(paramName, exception.ParamName);
        }

        [Fact]
        public void CallWriteByteMethodOfMemAPI_ExactlyTwoTimes_WithGpuramParameter()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IRenderingApi classUnderTest = new RenderingApi(mockedMemAPI);
            //Act
            classUnderTest.ColorMapLocation(default, default, default);
            //Assert
            mockedMemAPI.Received(2).WriteByte(Arg.Any<long>(), Arg.Any<uint>(), "GPURAM");
        }
    }
}
