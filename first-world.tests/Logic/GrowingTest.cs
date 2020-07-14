using NUnit.Framework;
using FirstWorld.Model;

namespace FirstWorld.Logic
{
    class TestGrowable : IObject, IGrowable
    {
        public long Age { get; set; }
    }

    class TestNonGrowable : IObject { }

    [TestFixture]
    public class GrowingTest
    {
        private Growing growing;

        [SetUp]
        public void SetUp()
        {
            growing = new Growing();
        }

        [Test]
        public void CanApply_WithIGrowableObject_ReturnsTrue()
        {
            IObject growable = new TestGrowable();

            bool result = growing.CanApply(growable, null);

            Assert.IsTrue(result, "Growing should be able to handle an object implementing IGrowable.");
        }
    }
}
