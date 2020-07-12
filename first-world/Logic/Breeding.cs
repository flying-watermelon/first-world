using System;
using System.Numerics;
using FirstWorld.Model;

namespace FirstWorld.Logic
{
    public class Breeding : ILaw
    {
        public bool CanApply(IObject obj, World world)
        {
            return (obj is IBreedable breedable)
                && breedable.Age >= breedable.BreedingAge
                && (breedable.Age - breedable.BreedingAge) % breedable.BreedingPeriod == 0;
        }

        public void Apply(IObject obj, World world)
        {
            IBreedable breedable = obj as IBreedable;
            var rand = new Random();
            int breedNumber = rand.Next(1, breedable.MaxBreedingNumber + 1);

            for (int i = 0; i < breedNumber; i++)
            {
                float childPositionAngle = Convert.ToSingle(rand.NextDouble());
                if (obj is Plant plant)
                {
                    Plant childPlant = new Plant(); 
                    childPlant.Age = 0;
                    childPlant.Position = new Vector3(
                        (float)(breedable.Position.X + Math.Sin(childPositionAngle) * breedable.ChildSpreadingRadius),
                        (float)(breedable.Position.Y + Math.Cos(childPositionAngle) * breedable.ChildSpreadingRadius),
                        0.0f);
                    childPlant.BreedingAge = 50;
                    childPlant.BreedingPeriod = 25;
                    childPlant.MaxAge = 101;
                    childPlant.MaxBreedingNumber = 2;

                    world.Objects.Add(childPlant);
                }
                if (obj is Animal animal)
                {
                    Animal childAnimal = new Animal();
                    childAnimal.Age = 0;
                    world.Objects.Add(childAnimal);
                    childAnimal.BreedingAge = 50;
                    childAnimal.BreedingPeriod = 25;
                    childAnimal.MaxAge = 101;
                    childAnimal.MaxBreedingNumber = 2;
                    childAnimal.ChildSpreadingRadius = 0.05f;
                }
            }
        }
    }
}
