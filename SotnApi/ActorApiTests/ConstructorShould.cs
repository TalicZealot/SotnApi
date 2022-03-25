using SotnApi;
using System;
using Xunit;

namespace ActorApiTests
{
    public class ConstructorShould
    {
        [Fact]
        public void ThrowArgumentNullException_WhenMemApiIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new EntityApi(null));
        }
    }
}
