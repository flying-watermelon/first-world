using NUnit.Framework;
using FirstWorld.Model;

namespace FirstWorld.Logic
{
    class TestStarvable : IObject, IStarvable
    {
        public int FoodStorage { get; set; }
        public int FoodConsumption { get; set; }
    }

    class TestNonStarvable : IObject { }

    [TestFixture]
    public class StarvingTest
    {
        private Starving starving;

        [SetUp]
        public void SetUp()
        {
            starving = new Starving();
        }

        [Test]
        public void CanApply_WithIStarvableObject_ReturnsTrue()
        {
            IObject starvable = new TestStarvable();

            bool result = starving.CanApply(starvable, null);

            Assert.IsTrue(result, "Starving should be able to handle an object implementing IStarvable.");
        }

        [Test]
        public void CanApply_WithNonIStarvableObject_ReturnsFalse()
        {
            IObject nonStarvable = new TestNonAgeable();

            bool result = starving.CanApply(nonStarvable, null);

            Assert.IsFalse(result, "Starving should not be able to handle an object not implementing IStarvable.");
        }

        [Test]
        public void Apply_WithFoodStorageGreaterThanFoodConsumption_CalculateFoodStorageCorrectly()
        {
            const int FOOD_STORAGE_BEFORE_STARVING = 9;
            const int FOOD_CONSUMPTION = 5;
            const int FOOD_STORAGE_AFTER_STARVING = 4;

            TestStarvable starvable = new TestStarvable();
            starvable.FoodStorage = FOOD_STORAGE_BEFORE_STARVING;
            starvable.FoodConsumption = FOOD_CONSUMPTION;

            starving.Apply(starvable, null);

            Assert.AreEqual(starvable.FoodStorage, FOOD_STORAGE_AFTER_STARVING, "The food storage of IStarvable should be decreased by food consumption after starving.");
        }

        [Test]
        public void Apply_WithFoodStorageLessThanFoodConsumption_RemoveIStarvableFromWorld()
        {
            const int FOOD_STORAGE_BEFORE_STARVING = 4;
            const int FOOD_CONSUMPTION = 5;

            World world = new World();
            TestStarvable starvable = new TestStarvable();
            starvable.FoodStorage = FOOD_STORAGE_BEFORE_STARVING;
            starvable.FoodConsumption = FOOD_CONSUMPTION;
            world.Objects.Add(starvable);

            starving.Apply(starvable, world);

            Assert.IsFalse(world.Objects.Contains(starvable), "The IStarvable with food storage below 0 should be removed from world.");
        }
    }
}
