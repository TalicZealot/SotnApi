using SotnApi;
using System;
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
