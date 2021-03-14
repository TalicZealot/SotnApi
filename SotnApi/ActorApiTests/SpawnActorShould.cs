using BizHawk.Client.Common;
using SotnApi.Constants.Values.Game;
using SotnApi.Constants.Addresses;
using NSubstitute;
using SotnApi;
using SotnApi.Interfaces;
using System;
using Xunit;
using SotnApi.Models;

namespace ActorApiTests
{
    public class SpawnActorShould
    {
        [Fact]
        public void CallsWriteByteRangeMethodOfMemAPI_ExactlyOnce()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IActorApi classUnderTest = new ActorApi(mockedMemAPI);
            Actor blankActor = new Actor();
            //Act
            classUnderTest.SpawnActor(blankActor);
            //Assert
            mockedMemAPI.Received(1).WriteByteRange(Arg.Any<long>(), blankActor.Value);
        }
    }
}
