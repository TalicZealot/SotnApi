using System;
using SotnApi;
using Xunit;


namespace GameApiTests
{
    public class ConstructorShould
    {
        [Fact]
        public void ThrowArgumentNullException_WhenMemApiIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new GameApi(null));
        }
    }
}
