using BizHawk.Client.Common;
using NSubstitute;
using SotnApi;
using SotnApi.Interfaces;
using System;
using Xunit;

namespace RenderingApiTests
{
    public class RoomIsRenderedShould
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
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => classUnderTest.RoomIsRendered(MaximumMapRows + 1, default));
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
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => classUnderTest.RoomIsRendered(default, MaximumMapCols + 1));
            //Assert
            Assert.Equal(paramName, exception.ParamName);
        }

        [Fact]
        public void CallReadByteMethodOfMemAPI_ExactlyOneTime_WithGpuramParameter()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IRenderingApi classUnderTest = new RenderingApi(mockedMemAPI);
            //Act
            classUnderTest.RoomIsRendered(default, default);
            //Assert
            mockedMemAPI.Received(1).ReadByte(Arg.Any<long>(), "GPURAM");
        }
    }
}
