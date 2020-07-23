using NUnit.Framework;
using FirstWorld.Model;

namespace FirstWorld.Logic
{
    class TestAgeable : IObject, IAgeable
    {
        public int Age { get; set; }
        public int MaxAge { get; set; }
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
            const int AGE_BEFORE_AGEING = 5;
            const int MAX_AGE = 10;

            TestAgeable ageable = new TestAgeable();
            ageable.Age = AGE_BEFORE_AGEING;
            ageable.MaxAge = MAX_AGE;

            aging.Apply(ageable, null);

            Assert.AreEqual(ageable.Age, AGE_BEFORE_AGEING + 1, "The age of IAgeable should be increased by 1 after aging.");
        }
    }
}
