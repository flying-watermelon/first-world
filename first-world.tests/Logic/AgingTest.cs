using NUnit.Framework;
using FirstWorld.Model;

namespace FirstWorld.Logic
{
    class TestAgeable : IObject, IAgeable
    {
        public long Age { get; set; }
        public long MaxAge { get; set; }
    }

    class TestNonAgeable : IObject { }

    [TestFixture]
    public class AgingTest
    {
        private Aging aging;

        [SetUp]
        public void SetUp()
        {
            aging = new Aging();
        }

        [Test]
        public void CanApply_WithIAgeableObject_ReturnsTrue()
        {
            IObject ageable = new TestAgeable();

            bool result = aging.CanApply(ageable, null);

            Assert.IsTrue(result, "Aging should be able to handle an object implementing IAgeable.");
        }

        [Test]
        public void CanApply_WithNonIAgeableObject_ReturnsFalse()
        {
            IObject nonAgeable = new TestNonAgeable();

            bool result = aging.CanApply(nonAgeable, null);

            Assert.IsFalse(result, "Aging should not be able to handle an object not implementing IAgeable.");
        }

        [Test]
        public void Apply_WithIAgeableObject_ReturnsTrue()
        {
            const long AGE_BEFORE_AGEING = 5;

            TestAgeable ageable = new TestAgeable();
            ageable.Age = AGE_BEFORE_AGEING;

            aging.Apply(ageable, null);

            Assert.AreEqual(ageable.Age, AGE_BEFORE_AGEING + 1, "The age of IAgeable should be increased by 1 after aging.");
        }
    }
}
