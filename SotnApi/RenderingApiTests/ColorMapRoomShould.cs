using BizHawk.Client.Common;
using NSubstitute;
using SotnApi;
using SotnApi.Interfaces;
using System;
using Xunit;

namespace RenderingApiTests
{
    public class ColorMapRoomShould
    {
        private const int MaximumMapRows = 255;
        private const int MaximumMapCols = 255;

        [Fact]
        public void ThrowArgumentOutOfRangeException_WhenRowIsGreaterThanMaximumMapRows()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IRenderingApi classUnderTest = new RenderingApi(mockedMemAPI);
            string paramName = "row";
            //Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => classUnderTest.ColorMapRoom(MaximumMapRows + 1, default, default, default));
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
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => classUnderTest.ColorMapRoom(default, MaximumMapCols + 1, default, default));
            //Assert
            Assert.Equal(paramName, exception.ParamName);
        }

        [Fact]
        public void CallWriteByteMethodOfMemAPI_ExactlyFifteenTimes_WithGpuramParameter()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IRenderingApi classUnderTest = new RenderingApi(mockedMemAPI);
            //Act
            classUnderTest.ColorMapRoom(default, default, default, default);
            //Assert
            mockedMemAPI.Received(15).WriteByte(Arg.Any<long>(), Arg.Any<uint>(), "GPURAM");
        }
    }
}
