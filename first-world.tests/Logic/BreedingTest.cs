using System.Reflection;
using System;
using NUnit.Framework;
using FirstWorld.Model;
using System.Numerics;

namespace FirstWorld.Logic
{
    class TestBreedable : IObject, IBreedable
    {
        public long Age { set; get; }
        public int MaxBreedingNumber { set; get; }
        public long BreedingAge { set; get; }
        public long BreedingPeriod { set; get; }
        public Vector3 Position { set; get; }
        public float ChildSpreadingRadius { set; get; }
        public IObject Breed()
        {
            TestBreedable child = new TestBreedable();
            return child;
        }
    }

    class TestNonBreedable : IObject { }

    [TestFixture]
    public class BreedingTest
    {
        private Breeding breeding;

        [SetUp]
        public void SetUp()
        {
            breeding = new Breeding();
        }

        [Test]
        public void CanApply_WithIBreedableObject_ReturnsTrue()
        {
            TestBreedable breedable = new TestBreedable();
            const long CURRENT_AGE = 25;
            const long BREEDING_AGE = 20;
            const long BREEDING_PERIOD = 5;
            breedable.Age = CURRENT_AGE;
            breedable.BreedingAge = BREEDING_AGE;
            breedable.BreedingPeriod = BREEDING_PERIOD;
            bool result = breeding.CanApply(breedable, null);
            Assert.IsTrue(result, "breeding should be able to handle an object implementing IBreedable.");
        }

        [Test]
        public void CanNotApply_WithNonIBreedableObject_ReturnsFalse()
        {
            TestNonBreedable nonBreedable = new TestNonBreedable();
            bool result = breeding.CanApply(nonBreedable, null);
            Assert.IsFalse(result, "breeding should not be able to handle an object not implementing IBreedable.");
        }

        [Test]
        public void Apply_WithIBreedableObject_ReturnsTrue()
        {
            TestBreedable breedable = new TestBreedable();
            const long CURRENT_AGE = 25;
            const long BREEDING_AGE = 20;
            const long BREEDING_PERIOD = 5;
            breedable.Age = CURRENT_AGE;
            breedable.BreedingAge = BREEDING_AGE;
            breedable.BreedingPeriod = BREEDING_PERIOD;
            Assert.IsTrue(breeding.Apply(breedable, null) is TestBreedable, "breeded child should be the same class with parent");
        }
    }
}
