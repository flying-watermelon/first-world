using NUnit.Framework;
using FirstWorld.Model;

namespace FirstWorld.Logic
{
    class TestDieable : IObject, IDieable
    {
        public long Age { set; get; }
        public long MaxAge { set; get; }
    }

    class TestNonDieable : IObject
    {
        public long Age { get; }
    }

    [TestFixture]
    public class DyingTest
    {
        private Dying dying;

        [SetUp]
        public void SetUp()
        {
            dying = new Dying();
        }

        [Test]
        public void CanApply_WithIDieableObject_Old_ReturnsTrue()
        {
            // IObject dieable = new TestDieable(); // can't assign age to IObject, error
            TestDieable dieable = new TestDieable();
            dieable.Age = 30;
            dieable.MaxAge = 29;
            bool result = dying.CanApply(dieable, null);
            Assert.IsTrue(result, "Dying should be able to handle an object implementing IDieable when age old.");
        }

        [Test]
        public void CanNotApply_WithIDieableObject_Young_ReturnsFalse()
        {
            TestDieable dieable = new TestDieable();
            dieable.Age = 30;
            dieable.MaxAge = 31;
            bool result = dying.CanApply(dieable, null);
            Assert.IsFalse(result, "Dying should not be able to handle an object implementing IDieable when age young.");
        }

        [Test]
        public void CanNotApply_WithNonIDieableObject_ReturnsFalse()
        {
            TestNonDieable non_dieable = new TestNonDieable();
            bool result = dying.CanApply(non_dieable, null);
            Assert.IsFalse(result, "Dying should not be able to handle an object NonIDieable.");
        }
    }
}
