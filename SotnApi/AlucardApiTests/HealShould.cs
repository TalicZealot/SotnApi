using BizHawk.Client.Common;
using NSubstitute;
using SotnApi;
using SotnApi.Interfaces;
using System;
using Xunit;

namespace AlucardApiTests
{
    public class HealShould
    {
        [Fact]
        public void CallWriteByteMethodOfMemAPI_ExactlyOneTime_WithCorrectParameter()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IAlucardApi classUnderTest = new AlucardApi(mockedMemAPI);
            //Act
            classUnderTest.Heal(1);
            //Assert
            mockedMemAPI.Received(1).WriteByte(Arg.Any<long>(), 1);
        }

        [Fact]
        public void CallWriteS16MethodOfMemAPI_ExactlyOneTime_WithCorrectParameter()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IAlucardApi classUnderTest = new AlucardApi(mockedMemAPI);
            //Act
            classUnderTest.Heal(666);
            //Assert
            mockedMemAPI.Received(1).WriteS16(Arg.Any<long>(), 666);
        }
    }
}
