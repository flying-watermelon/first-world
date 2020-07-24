using System;
using NUnit.Framework;
using FirstWorld.Model;
using System.Numerics;
using System.Collections.Generic;

namespace FirstWorld.Logic
{
    class TestBreedable : IObject, IBreedable
    {
        public int Age { set; get; }
        public int MaxBreedingNumber { set; get; }
        public int BreedingAge { set; get; }
        public int BreedingPeriod { set; get; }
        public Vector3 Position { set; get; }
        public float ChildSpreadingRadius { set; get; }
        public IList<IObject> newChilds { set; get; }
        public TestBreedable(){
            newChilds = new List<IObject>();
        }
        public IObject Breed()
        {
            TestBreedable child = new TestBreedable();
            newChilds.Add(child);
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
            const int CURRENT_AGE = 25;
            const int BREEDING_AGE = 20;
            const int BREEDING_PERIOD = 5;
            breedable.Age = CURRENT_AGE;
            breedable.BreedingAge = BREEDING_AGE;
            breedable.BreedingPeriod = BREEDING_PERIOD;
            bool result = breeding.CanApply(breedable, null);
            Assert.IsTrue(result, "breeding should be able to handle an object implementing IBreedable.");
        }

        [Test]
        public void CanApply_WithNonIBreedableObject_ReturnsFalse()
        {
            TestNonBreedable nonBreedable = new TestNonBreedable();
            bool result = breeding.CanApply(nonBreedable, null);
            Assert.IsFalse(result, "breeding should not be able to handle an object not implementing IBreedable.");
        }

        [Test]
        public void Apply_WithIBreedableObject_ReturnsBreeded()
        {
            const int CURRENT_AGE = 25;
            const int BREEDING_AGE = 20;
            const int BREEDING_PERIOD = 5;
            const int MAX_BREED_NUMBER = 10;
            TestBreedable breedable = new TestBreedable();
            breedable.Age = CURRENT_AGE;
            breedable.BreedingAge = BREEDING_AGE;
            breedable.BreedingPeriod = BREEDING_PERIOD;
            breedable.MaxBreedingNumber = MAX_BREED_NUMBER;

            World world = new World();
            world.Objects.Add(breedable);
            int oldWorldAmount = world.Objects.Count;
            breeding.Apply(breedable, world);
            int newWorldAmount = world.Objects.Count;
            bool breededAmountRight = MAX_BREED_NUMBER>=(newWorldAmount-oldWorldAmount) && (newWorldAmount-oldWorldAmount)>=1;
            Assert.IsTrue(breededAmountRight, "number of breeded objects should be in range [1,MAX_BREED_NUMBER]");

            for (int i = 0; i < breedable.newChilds.Count; i++)
            {
            bool contains = world.Objects.Contains(breedable.newChilds[i]);
            Assert.IsTrue(contains, "world should contains all new childs of this generation");
            }
        }
    }
}
