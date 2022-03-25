using BizHawk.Client.Common;
using NSubstitute;
using SotnApi;
using SotnApi.Constants.Addresses;
using SotnApi.Constants.Values.Game;
using SotnApi.Interfaces;
using System;
using Xunit;

namespace ActorApiTests
{
    public class FindEnemyShould
    {
        [Fact]
        public void ThrowArgumentOutOfRangeException_WhenMinHpIsLowerThanOne()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IEntityApi classUnderTest = new EntityApi(mockedMemAPI);
            string message = "minHp must be greater than 0\r\nParameter name: minHp";
            //Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => classUnderTest.FindEnemyEntity(0, 1));
            //Assert
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_WhenMaxHpIsLowerThanOne()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IEntityApi classUnderTest = new EntityApi(mockedMemAPI);
            string message = "maxHp must be greater than 0\r\nParameter name: maxHp";
            //Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => classUnderTest.FindEnemyEntity(1, 0));
            //Assert
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void CallReadByteMethodOfMemAPI_ExactlyMaximumTimes()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IEntityApi classUnderTest = new EntityApi(mockedMemAPI);
            //Act
            classUnderTest.FindEnemyEntity(1, 1);
            //Assert
            mockedMemAPI.Received(2 * Entities.EnemyEntitiesCount).ReadByte(Arg.Any<long>());
            mockedMemAPI.Received(2 * Entities.EnemyEntitiesCount).ReadU16(Arg.Any<long>());
        }

        [Fact]
        public void ReturnZeroWhenEnemyWasNotFound()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            IEntityApi classUnderTest = new EntityApi(mockedMemAPI);
            //Act
            long enemy = classUnderTest.FindEnemyEntity(1, 10);
            //Assert
            Assert.Equal(0, enemy);
        }
        [Fact]
        public void ReturnCorrectAddressWhenEnemyWasFound()
        {
            //Arrange
            var mockedMemAPI = Substitute.For<IMemoryApi>();
            mockedMemAPI
                .ReadU16(Arg.Any<long>())
                .ReturnsForAnyArgs<uint>(3);
            mockedMemAPI
                .ReadByte(Arg.Any<long>())
                .ReturnsForAnyArgs<uint>(3);
            IEntityApi classUnderTest = new EntityApi(mockedMemAPI);
            //Act
            long enemy = classUnderTest.FindEnemyEntity(1, 1000);
            //Assert
            Assert.Equal(Game.EnemyEntitiesStart, enemy);
        }
    }
}
