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
            // Random rand = new Random();
            // float positionAngle = Convert.ToSingle(rand.NextDouble() * Math.PI);
            // float positionRadius = Convert.ToSingle(rand.NextDouble());

            Plant child = new Plant();
            // child.Position = new Vector3(
            //     (float)(Position.X + Math.Sin(positionAngle) * ChildSpreadingRadius * positionRadius),
            //     (float)(Position.Y + Math.Cos(positionAngle) * ChildSpreadingRadius * positionRadius),
            //     0.0f);
            // child.Age = 0;
            // child.MaxBreedingNumber = MaxBreedingNumber;
            // child.BreedingAge = BreedingAge;
            // child.BreedingPeriod = BreedingPeriod;
            // child.ChildSpreadingRadius = ChildSpreadingRadius;
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
            breedable.Age = 25;
            breedable.BreedingAge = 20;
            breedable.BreedingPeriod = 5;
            bool result = breeding.CanApply(breedable, null);
            Assert.IsTrue(result, "breeding should be able to handle an object implementing IBreedable.");
        }
        [Test]
        public void CanNotApply_WithNonIBreedableObject_ReturnsFalse()
        {
            // TODO: fix this test
        }
    }
}
