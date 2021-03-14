using SotnApi;
using System;
using Xunit;


namespace RenderingApiTests
{
    public class ConstructorShould
    {
        [Fact]
        public void ThrowArgumentNullException_WhenMemApiIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new RenderingApi(null));
        }
    }
}
