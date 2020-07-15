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

        [Test]
        public void CanApply_WithNonIGrowableObject_ReturnsFalse()
        {
            IObject nongrowable = new TestNonGrowable();

            bool result = growing.CanApply(nongrowable, null);

            Assert.IsFalse(result, "Growing should not be able to handle an object not implementing IGrowable.");
        }

        [Test]
        public void Apply_WithIGrowableObject_ReturnsTrue()
        {
            const long AGE_BEFORE_GROWING = 5;

            TestGrowable growable = new TestGrowable();
            growable.Age = AGE_BEFORE_GROWING;

            growing.Apply(growable, null);

            Assert.AreEqual(growable.Age, AGE_BEFORE_GROWING + 1, "The age of IGrowable should be increased by 1 after growing.");
        }
    }
}
