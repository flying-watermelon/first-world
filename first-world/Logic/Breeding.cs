using System;
using System.Numerics;
using FirstWorld.Model;

namespace FirstWorld.Logic
{
    public class Breeding : ILaw
    {
        public bool CanApply(IObject obj, World world)
        {
            return (obj is Plant plant)
                && plant.Age >= plant.BreedingAge
                && (plant.Age - plant.BreedingAge) % plant.BreedingPeriod == 0;
        }

        public void Apply(IObject obj, World world)
        {
            if (obj is Plant plant)
            {
                var rand = new Random();
                int breedNumber = rand.Next(1, plant.MaxBreedingNumber + 1);

                for (int i = 0; i < breedNumber; i++)
                {
                    float seedPositionAngle = Convert.ToSingle(rand.NextDouble());

                    Plant childPlant = new Plant();
                    childPlant.Age = 0;
                    childPlant.Position = new Vector3(
                        (float)(plant.Position.X + Math.Sin(seedPositionAngle) * plant.SeedSpreadingRadius),
                        (float)(plant.Position.Y + Math.Cos(seedPositionAngle) * plant.SeedSpreadingRadius),
                        0.0f);

                    world.Objects.Add(childPlant);
                }
            }
        }
    }
}
