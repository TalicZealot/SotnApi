using System;
using SotnApi;
using Xunit;

namespace AlucardApiTests
{
    public class ConstructorShould
    {
        [Fact]
        public void ThrowArgumentNullException_WhenMemApiIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new AlucardApi(null));
        }
    }
}
