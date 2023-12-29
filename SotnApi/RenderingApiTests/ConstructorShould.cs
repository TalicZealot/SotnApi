using SotnApi;
using System;
using Xunit;


namespace MapApiTests
{
    public class ConstructorShould
    {
        [Fact]
        public void ThrowArgumentNullException_WhenMemApiIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new MapApi(null));
        }
    }
}
